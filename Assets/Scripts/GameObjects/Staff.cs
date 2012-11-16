using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;

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
	public Waypoint[] waypoints;
	
	private NameGenerator nameGenerator;
	private bool assignedWorkplace = false;
	private AIPath myPath; 
	 
	// Use this for initialization
	public void Start ()
	{
		SetRole (defaultRole);
		nameGenerator = new NameGenerator ();
		GenerateName ();
		TakeOwnership (); 
		myPath = GetComponent<AIPath>();
	}
	void TakeReceptionOwnership ()
	{
		foreach (Waypoint point in FindObjectsOfType(typeof(Waypoint))) {
			if (point.action == Waypoint.Action.reception) {
				if (point.owner == null) {
					point.owner = this;
					assignedWorkplace = true; 
				} else {
					print ("No Objects To Own :(. Staff without purpose!");
				}
			}
		}
	}
	
	void TakeOwnership ()
	{

		switch (role) {
		case Role.receptionist:
			TakeReceptionOwnership ();
			break;
		default:
			break;
		}

	}

	public void Update()
	{
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
		if(TimeManager.currentHour.hour >= TimeManager.openingTime && TimeManager.currentHour.hour <= TimeManager.closingTime)
		{
			if(timeToStayAtWaypoint <= 0)
			{
				NextWaypoint();
			}
		}
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
				ReturnToDesk();
				waypointNumber = waypoints.Length - 1;
			}
		}
		else
		{
			waypoints = WaypointManager.FindStaffWaypoints(this);
		}

	}
	
	public void ReturnToDesk()
	{
		if(waypoints != null || waypoints.Length >=1)
		{
			myPath.target = waypoints[0].transform;
			timeToStayAtWaypoint = TimeManager.TimeTillClosingTimeInMinutes();
		}
	}
	void GenerateName ()
	{
		if (staffName == "") {
			staffName = nameGenerator.CreateName (male, Random.Range (2, 3));
		}
	}
	
	public void GoHome()
	{
		Waypoint point = WaypointManager.FindExitWaypoint();
		myPath.target = point.transform;
		timeToStayAtWaypoint = point.timeToStayAtWaypoint;
	}

	public void StartWork()
	{
		Waypoint point = WaypointManager.FindStartWaypoint();
		myPath.target = point.transform;
		timeToStayAtWaypoint = point.timeToStayAtWaypoint;
		waypoints = WaypointManager.FindStaffWaypoints(this);
		waypointNumber = 0; 
	}
	

}
