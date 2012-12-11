using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;

[RequireComponent(typeof(AIPath))]
public class Staff : MonoBehaviour
{
	
	public enum Role
	{
		receptionist,
		practitioner,
		caretaker,
		cleaner,
		gardener
	}
	
	public enum State
	{
		entering, 
		talking, 
		booking,
		waiting,
		fired,
		onBreak,
		working,
		waitingAtDesk,
		leaving
	}
	
	public bool male = true;
	public Role defaultRole;

	public Role role{ get; set; }

	public State state{ get; set; }

	public string staffName;
	public int salary;
	public int patientIncrease;
	public int timeToStayAtWaypoint; 
	public int waypointNumber; 
	public string currentState;
	public int bookingTime = 5;
	public int timeToNextPatient = 5;
	public int cooldownTime = 5;
	public Waypoint[] waypoints;
	
	private NameGenerator nameGenerator;
	private bool assignedWorkplace = false;
	private AIPath myPath; 
	private StaffWaypoint myWaypoint;
	private Patient currentPatient; 
	
	// Use this for initialization
	public void Start ()
	{
		SetRole (defaultRole);
		nameGenerator = new NameGenerator ();
		staffName = Helper.GenerateName (male, Random.Range (2,3));
		TakeOwnership (); 
		myPath = GetComponent<AIPath>();
		myWaypoint = GetComponentInChildren<StaffWaypoint>();
	}
	
	
	void TakeDesk(Waypoint.Action action)
	{
			foreach (Waypoint point in FindObjectsOfType(typeof(Waypoint))) {
			if (point.action == action) {
				if (point.owner == null) {
					point.owner = this;
					assignedWorkplace = true; 
					if(TimeManager.IsOpen())
					{
						myPath.target = point.transform;
						timeToStayAtWaypoint = point.timeToStayAtWaypoint;
					}
				} else {
					//print ("No Objects To Own :(. Staff without purpose!"); // needs to add random message system here.
				}
			}
		}
	}
	void TakeOwnership ()
	{

		switch (role) {
		case Role.receptionist:
			TakeDesk(Waypoint.Action.reception);
			break;
		case Role.practitioner:
			TakeDesk(Waypoint.Action.practice);
			break;
		default:
			break;
		}

	}

	public void Update()
	{
		currentState = state.ToString();
		if(!assignedWorkplace)
		{
			TakeOwnership ();
		}
	}
	
	void SetRole (Role newRole)
	{
		role = newRole;
	}
	
	public void HourPassed()
	{
		//For now do nothing, but i'm sure I will find a use for this. 
	}
	public void MinutePassed ()
	{
		timeToStayAtWaypoint--;

		if(timeToStayAtWaypoint < 0)
		{
			timeToStayAtWaypoint = 0;
		}
		if(TimeManager.IsOpen ())
		{
			if(timeToStayAtWaypoint == 0)
			{
				NextWaypoint();
			}
		if(role == Role.practitioner)
		{
				if(PatientManager.PatientsWaiting())
				{
					timeToNextPatient--; 	
					if(timeToNextPatient == 0)
					{
						CallNextPatient();
					}
				}
				else
				{
					NoPatients();
				}
		}
		
		}
		else
		{
			GoHome();
		}
		if(timeToNextPatient < 0)
		{
			timeToNextPatient = 0;
		}

	}
	
	public void NoPatients()
	{
		print (staffName + ": No patients"); // need to add random messages. 
		timeToNextPatient = cooldownTime;
	}
	
	public void NextWaypoint()
	{
		if(waypoints.Length >= 1)
		{
			Waypoint point = waypoints[waypointNumber];
			myPath.target = point.transform;
			timeToStayAtWaypoint = point.timeToStayAtWaypoint;
			waypointNumber++; 
			if(waypointNumber >= waypoints.Length)
			{
				if(role != Role.gardener || role != Role.cleaner || role != Role.caretaker)
				{
					ReturnToDesk();
					waypointNumber = waypoints.Length - 1;
				}
				else
				{
					GoHome ();
				}
			}
		}
		else
		{
			timeToStayAtWaypoint = 0;
			//waypoints = WaypointManager.FindStaffWaypoints(this);
		}

	}
	
	public void ReturnToDesk()
	{
		if(waypoints != null || waypoints.Length >=1)
		{
			myPath.target = waypoints[0].transform;
			timeToStayAtWaypoint = TimeManager.TimeTillClosingTimeInMinutes();
			state = State.waitingAtDesk;
		}
	}
	
	public void SetState(Waypoint point)
	{
		switch(point.action)
		{
		case Waypoint.Action.book:
			state = State.booking;
			break;
		case Waypoint.Action.enter:
			state = State.entering;
			break;
		case Waypoint.Action.exit:
			state = State.leaving;
			break;
		case Waypoint.Action.fire:
			state = State.leaving;
			break;
		case Waypoint.Action.reception:
			state = State.waitingAtDesk;
			break;
		case Waypoint.Action.receptionAction:
			state = State.working;
			break;
		case Waypoint.Action.wait:
			state = State.waiting;
			break;
		case Waypoint.Action.work:
			state = State.working;
			break;
		}
	}
	
	public void GoHome()
	{
		Waypoint point = WaypointManager.FindExitWaypoint();
		myPath.target = point.transform;
		timeToStayAtWaypoint = point.timeToStayAtWaypoint;
		//SetState (point);
		state= State.leaving;
	}
	
	public void MakeBooking(Patient patient)
	{
		if(StaffManager.CheckForStaff(Role.practitioner))
		{
			if(!PatientManager.PatientsWaiting())
			{
				
			}
			state = State.booking;
			patient.state = Patient.State.booking;
			PatientManager.AddPatientToWaiting (patient);
			patient.timeToStayAtWaypoint = bookingTime;
			patient.SetStaffTarget(StaffManager.AssignPractitioner());
			
		}
		else
		{
			print (staffName + ": Sorry, for some reason we don't have a practitioner in the building."); // Need to add random messages here.
			state = State.waitingAtDesk;
			patient.GoHomePissed(RandomMessages.GetAngryHomeMessage()); //Need to add Random Messages for no practitioner.
		}

	}
	
	public void CallNextPatient()
	{
		currentPatient = PatientManager.GetNextWaiting();
		PatientManager.RemovePatientFromWaiting(currentPatient);
		currentPatient.state = Patient.State.inAppointment;
		state = State.working;
		if(WaypointManager.IsClinicSeat())
		{
			currentPatient.SetWaypoint(WaypointManager.GetClinicWaypoint(),currentPatient.conditionTime + 1);
		}
		else
		{
			currentPatient.SetWaypoint(WaypointManager.GetPracticeWaypoint(),currentPatient.conditionTime + 1);
			currentPatient.Speak ("No Clinic Seating..."); // needs random messaging system. 
			currentPatient.patientSatisfaction -= 5;
		}
		timeToStayAtWaypoint = currentPatient.conditionTime + cooldownTime;
		timeToNextPatient = currentPatient.conditionTime + cooldownTime;
	}
	
	public void StartWork()
	{
		Waypoint point = WaypointManager.FindStartWaypoint();
		myPath.target = point.transform;
		timeToStayAtWaypoint = point.timeToStayAtWaypoint;
		waypoints = WaypointManager.FindStaffWaypoints(this);
		waypointNumber = 0; 
		SetState (point);
		timeToNextPatient = cooldownTime;
		currentPatient = null;
	}
	
	public void Reset()
	{
		StartWork ();
	}
	
	public void HurryTask ()
	{
		timeToStayAtWaypoint = timeToStayAtWaypoint/2;
	}
	
}
