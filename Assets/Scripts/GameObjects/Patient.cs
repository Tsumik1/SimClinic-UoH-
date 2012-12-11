using UnityEngine;
using System.Collections;

public class Patient : MonoBehaviour {
	
	
	public enum State
	{
		entering, 
		talking, 
		booking,
		waiting,
		leaving,
		queuing,
		inAppointment,
		
	}
	
	public enum ReasonForVisit
	{
		//Add Conditions etc.	
	}
	
	public bool male;

	public State state{ get; set; }

	public string patientName;
	public int timeToStayAtWaypoint; 
	public int waypointNumber; 
	public string currentState;
	public int patientSatisfaction = 5; 
	public int conditionTime; 
	public string conditionName;
	public double conditionCost;
	public GameObject bubble;
	//public Waypoint[] waypoints;
	public Waypoint targetPoint;
	private AIPath myPath; 
	private Staff staffTarget; 
	public bool bookedIn;
	
	// Use this for initialization
	void Start () 
	{
		male = Helper.RandomBool ();
		patientName = Helper.GenerateName (male, Random.Range (2,3));
		RandomCondition ();
		myPath = GetComponent<AIPath>();
		EnterClinic();
	}
	
	public void SetStaffTarget(Staff staff)
	{
		staffTarget = staff;
	}
	
	void RandomCondition()
	{
		//This method will be replaced by XML before christmas. 
		conditionName = Helper.GenerateConditionName();
		conditionTime = conditionName.Length;
		conditionCost =(double) conditionName.Length * 10;
	}
	
	void CheckReception()
	{		
		if(WaypointManager.IsReception())
		{
			if(!StaffManager.CheckForReceptionist())
			{
				GoHomePissed ("No Receptionist! " + RandomMessages.GetAngryHomeMessage());
			}
			else
			{
				state = State.booking;
				staffTarget = StaffManager.GetReceptionist();
				if(staffTarget.state == Staff.State.waitingAtDesk)
				{
					targetPoint = WaypointManager.FindStaff(staffTarget);
					myPath.target = targetPoint.transform;	
					staffTarget.MakeBooking (this);
				}
				else
				{
					//state = State.waiting; 
					JoinQueue();
				}
			}
		}
		else
		{
			GoHomePissed("This place has no reception!!!! " + RandomMessages.GetAngryHomeMessage());
		}
	}
	
	public void MinutePassed ()
	{
		timeToStayAtWaypoint--;
		if(timeToStayAtWaypoint < 0)
		{
			timeToStayAtWaypoint = 0;
		}
	}	
	
	void EnterClinic()
	{
		if(TimeManager.IsOpen ())
		{
			targetPoint = WaypointManager.FindStartWaypoint();
			myPath.target = targetPoint.transform;
			state = State.entering;
			PatientManager.IncreaseInClinicCount();
		}
		else
		{
			GoHome(RandomMessages.GetClosedMessage());	
		}
	}
	
	void FindASeat()
	{
		if(WaypointManager.IsSeating())
		{
			
		}
		else
		{
			print (patientName + ": There's no seating in this clinic...terrible!!!");
			SetWaypoint (WaypointManager.FindStartWaypoint (),timeToStayAtWaypoint);
			patientSatisfaction -= 5;
		}
	   timeToStayAtWaypoint = staffTarget.timeToNextPatient;
	}
	
	void JoinQueue()
	{
		if(WaypointManager.IsQueue() == true)
		{
			SetWaypoint (WaypointManager.GetNextQueuePoint(),WaypointManager.GetQueueTime());
			if(WaypointManager.GetQueueTime() > 30)
			{
				patientSatisfaction -= 10;
				Speak(RandomMessages.GetImpatientMessage());
			}
			if(WaypointManager.GetQueueTime() > 60)
			{
				patientSatisfaction -=20; 
				GoHomePissed (RandomMessages.GetLongQueue());
			}
			state = State.queuing;
		}
		else
		{
			if(WaypointManager.IsQueue() == false)
			{
				Speak(RandomMessages.GetFirstMessage());
				WaypointManager.BuildQueue();
				JoinQueue();
			}

		}
	}
	// Update is called once per frame
	public void ForceComplete()
	{
		if(patientSatisfaction > 0)
		{
			Pay ();
			GoHomeHappy (RandomMessages.GetHappyHomeMessage());
		}
		else
		{
			GoHomePissed(RandomMessages.GetAngryHomeMessage());
		}
	}
	void Update () 
	{
		currentState = state.ToString ();
		if(myPath.TargetReached && timeToStayAtWaypoint == 0)
		{
			NextWaypoint();
		}
		//myPath.repathRate = timeToStayAtWaypoint;
	}
    public void SetWaypoint(Waypoint point, int time)
	{
		targetPoint = point;
		myPath.target = targetPoint.transform;
		timeToStayAtWaypoint = time;
	}
	
	void NextWaypoint()
	{
		if(!bookedIn && state == State.entering)
		{
			CheckReception ();
		}
		if(state == State.waiting)
		{
			//Logic to be called :). 
		}
		if(!bookedIn && state == State.queuing)
		{
			staffTarget.MakeBooking (this);
			//timeToStayAtWaypoint = StaffManager.GetReceptionBookingTime();
			bookedIn = true;
			WaypointManager.RemoveFromQueue();
		}
		if(bookedIn && state == State.booking)
		{
			FindASeat();
			state = State.waiting;
		}
		if(state == State.leaving)
		{
			if(myPath.TargetReached)
				Destroy (this.gameObject);
		}
		if(state == State.inAppointment)
		{
			Pay();
			GoHomeHappy(RandomMessages.GetHappyHomeMessage());
			PatientManager.DecreaseInClinicCount();
		}
	}
	public void Pay()
	{
		MoneyManager.ReceivePayment(conditionCost);
	}
	
	public void Speak(string message)
	{
		print (patientName + ": " + message);
		if(!TimeManager.skip)
		{
			GameObject newBubble = Instantiate (bubble,transform.position,Quaternion.identity) as GameObject;
			Vector3 newPos = transform.position;
			newPos.y += 4f;
			newPos.x += 3f;
			newPos.z -= 1.5f;
			newBubble.transform.position = newPos;
			Quaternion standardRot = newBubble.transform.rotation;
			newBubble.GetComponent<Bubble>().SetText (message);
			newBubble.transform.parent = this.transform;
		}
	}
	public void GoHomePissed(string message)
	{
		patientSatisfaction -= 20; 
		PatientManager.unsuccessfulPatients++;
		GoHome (message);
	}
	
	public void GoHome(string message)
	{
		Speak (message);
		targetPoint = WaypointManager.FindExitWaypoint();
		if(targetPoint && myPath)
		{
			myPath.target = targetPoint.transform;
			timeToStayAtWaypoint = 10;
			state = State.leaving;
		}
		else 
		{
			Debug.Log ("Can't find anywhere to go!");
		}
		PatientManager.AddPatient();
	}
	
	public void GoHomeHappy(string message)
	{
		patientSatisfaction += 10;
		PatientManager.happyPatients++;
		GoHome (message);
		
	}
	
	void OnDestroy()
	{
		PatientManager.IncreasePatientSatisfaction(patientSatisfaction);
	}
}
