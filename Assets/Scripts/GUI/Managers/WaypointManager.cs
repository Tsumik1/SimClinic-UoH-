using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class WaypointManager : MonoBehaviour {
	
	
	public static Waypoint[] waypoints; 
	public static Waypoint[] queueWaypoints;
	public  Waypoint referenceWaypoint;
	public static int queueNumber = 0; 
	public static int maxQueueSize = 10;
	public static bool queueMade;
	
	private static Waypoint reference; 
	// Use this for initialization
	void Start () 
	{
	if(referenceWaypoint)
		{
			reference = referenceWaypoint;
		}
	queueWaypoints = null;
		queueMade = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	public static bool IsClinicSeat()
	{
		bool r = false; // variable to return. 
		foreach(Waypoint point in FindObjectsOfType(typeof(Waypoint)))
		{
			if(point.action == Waypoint.Action.clinic)
			{
				r = true; 
				break; // break out of the loop if condition found
			}
			else
			{
				r = false;
			}
		}
		return r;
	}
	public static Waypoint GetClinicWaypoint()
	{
		Waypoint it = new Waypoint();
		foreach(Waypoint point in FindObjectsOfType(typeof(Waypoint)))
		{
			if(point.action == Waypoint.Action.clinic)
			{
				it = point;
				break;
			}
			else
				it = null;
		}
		return it;
	}
	
		public static Waypoint GetPracticeWaypoint()
	{
		Waypoint it = null;
		foreach(Waypoint point in FindObjectsOfType(typeof(Waypoint)))
		{
			if(point.action == Waypoint.Action.practice)
			{
				it = point;
				break;
			}
			else
				it = null;
		}
		return it;
	}
	public static Waypoint FindStartWaypoint()
	{
		foreach(Waypoint point in FindObjectsOfType(typeof(Waypoint)))
		{
			if(point.action == Waypoint.Action.enter)
			{
				return point;
			}
		}
		
		return null;
	}
	
	public static Waypoint FindExitWaypoint()
	{
		foreach(Waypoint point in FindObjectsOfType(typeof(Waypoint)))
		{
			if(point.action == Waypoint.Action.exit)
			{
				return point;
			}
		}
		
		return null;
	}
	
	public static Waypoint FindStaff(Staff staff)
	{
		return staff.GetComponentInChildren<Waypoint>();
	}
	
	public static Waypoint[] FindStaffWaypoints(Staff staff)
	{
		switch(staff.role)
		{
		case Staff.Role.receptionist:
			return FindWaypoints(staff, Waypoint.Action.reception, Waypoint.Action.receptionAction);
		case Staff.Role.practitioner:
			return FindWaypoints(staff, Waypoint.Action.practice, Waypoint.Action.practiceAction);
		default:
			return null;
		}
	}
	
	
	public static Waypoint[] FindWaypoints(Staff staff, Waypoint.Action type, Waypoint.Action action)
	{
		Waypoint desk = null; 
		List<Waypoint> availableWaypoints = new List<Waypoint>();
		foreach(Waypoint point in FindObjectsOfType(typeof(Waypoint)))
		{
			if(point.action == type && point.owner == staff)
			{
				desk = point; 
			}
			if(point.action == action)
			{
				availableWaypoints.Add (point);
			}
		}
		if(desk)
		{
			availableWaypoints.Add (desk);
		}
		//availableWaypoints.Shuffle();
		Waypoint[] waypoints;
		waypoints = availableWaypoints.ToArray ();
		if(waypoints.Length >= 1)
		{
			waypoints[0] = desk;  // always puts the desk to the front of the array so the ReturnToDesk() function in the Staff class can actually work.
		}
		return waypoints;	
	}
	public static Waypoint[] FindPracticeWaypoints(Staff staff)
	{
		Waypoint desk = null; 
		List<Waypoint> availableWaypoints = new List<Waypoint>();
		foreach(Waypoint point in FindObjectsOfType(typeof(Waypoint)))
		{
			if(point.action == Waypoint.Action.practice && point.owner == staff)
			{
				desk = point; 
			}
			if(point.action == Waypoint.Action.practiceAction)
			{
				availableWaypoints.Add (point);
			}
		}
		if(desk)
		{
			availableWaypoints.Add (desk);
		}
		availableWaypoints.Shuffle();
		Waypoint[] waypoints;
		waypoints = availableWaypoints.ToArray ();
		if(waypoints.Length >= 1)
		{
			waypoints[0] = desk;  // always puts the desk to the front of the array so the ReturnToDesk() function in the Staff class can actually work.
		}
		return waypoints;
	}
	
	//finds the relevant waypoints for a receptionist. 
	public static Waypoint[] FindReceptionWaypoints(Staff staff)
	{
		Waypoint desk = null; 
		List<Waypoint> availableWaypoints = new List<Waypoint>();
		foreach(Waypoint point in FindObjectsOfType(typeof(Waypoint)))
		{
			if(point.action == Waypoint.Action.reception && point.owner == staff)
			{
				desk = point; 
			}
			if(point.action == Waypoint.Action.receptionAction)
			{
				availableWaypoints.Add (point);
			}
		}
		if(desk)
		{
			availableWaypoints.Add (desk);
		}
		availableWaypoints.Shuffle();
		Waypoint[] waypoints;
		waypoints = availableWaypoints.ToArray ();
		if(waypoints.Length >= 1)
		{
			waypoints[0] = desk;  // always puts the desk to the front of the array so the ReturnToDesk() function in the Staff class can actually work.
		}
		return waypoints;
	}
	
	public static Waypoint[] FindAllWaypoints()
	{
		return FindObjectsOfType(typeof(Waypoint)) as Waypoint[];
	}
	
	
	//Method to check if seating is available for the patient.
	public static bool IsSeating()
	{
		bool r = false; // variable to return. 
		foreach(Waypoint point in FindObjectsOfType(typeof(Waypoint)))
		{
			if(point.action == Waypoint.Action.sit)
			{
				r = true; 
				break; // break out of the loop if condition found
			}
			else
			{
				r = false;
			}
		}
		return r;
		
	}
	
	public static bool IsReception()
	{
		bool r = false; // variable to return. 
		foreach(Waypoint point in FindObjectsOfType(typeof(Waypoint)))
		{
			if(point.action == Waypoint.Action.reception)
			{
				r = true; 
				break; // break out of the loop if condition found
			}
			else
			{
				r = false;
			}
		}
		return r;
	}
	
	//checks if a queue exists. 
	public static bool IsQueue()
	{
		if(queueMade)
		{
			return true;
		}
		else
		{
				return false;
		}
	}
	
	public static void BuildQueue()
	{
		bool receptionPresent = false; 
		
		queueWaypoints = new Waypoint[maxQueueSize];
		foreach(Waypoint point in FindObjectsOfType(typeof(Waypoint)))
		{
			if(point.action == Waypoint.Action.reception)
			{
				Vector3 newPosition = point.transform.position;
				newPosition.x += 1f; 
				queueWaypoints[0] = Instantiate (reference, newPosition, Quaternion.identity) as Waypoint;
				receptionPresent = true; 
				queueMade = true;
				break;
			}
		}
		
		if(receptionPresent)
		{
			for(int i = 1; i < maxQueueSize; i++)
			{
				Vector3 newPosition = queueWaypoints[i-1].transform.position; 
				newPosition.x += 1f;
				queueWaypoints[i] = Instantiate (reference, newPosition, Quaternion.identity) as Waypoint;
				
			}
			queueMade = true;
		}
		else
		{
			queueWaypoints = null;
			queueMade = false;
		}
	}
	
	public static Waypoint GetNextQueuePoint()
	{
		AddToQueue();
		return queueWaypoints[queueNumber];
		
	}
	
	public static void AddToQueue()
	{
		PatientManager.AddPatientToQueue(); //Will add some queue shit here. 
		queueNumber ++; 
	}
	
	public static void RemoveFromQueue()
	{
		queueNumber --;
	}
	
	public static int GetQueueTime()
	{
		int bookingTime = StaffManager.GetReceptionBookingTime();
		int waitTime = bookingTime * queueNumber + 2;
		return waitTime;
	}
}
