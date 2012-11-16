using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
public class StaffOld : MonoBehaviour {
	
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
	public Role role{get;set;}
	public State state{get;set;} 
	public Route path;
	public Route blankRoute; 
	public List<Waypoint>waypoints;
	public string staffName;
	public int salary;
	public int hoursUntilNextAction;
	public int patientIncrease; 
	public int waypointTracker;
	public string currentState; 
	public Vector3 targetPosition; 
	
	public Waypoint currentWaypoint; 
	public Waypoint nextWaypoint;
	private Vector3 movementDirection ;
	private NameGenerator nameGenerator;
	public int waypointNumber = 0; 
	public int nextWayPointNumber = 0;
	private bool assignedWorkplace = false; 

	// Use this for initialization
	public void Start () {
		SetRole(defaultRole);
		nameGenerator = new NameGenerator();
		GenerateName();
		TakeOwnership(); 
		Seeker seeker = GetComponent<Seeker>();
		seeker.StartPath (transform.position, targetPosition,OnPathComplete);
	}
	
	public void OnPathComplete(Path p)
	{
		Debug.Log ("SUCCESS");
	}
	
void TakeReceptionOwnership()
	{
		foreach(Waypoint point in FindObjectsOfType(typeof(Waypoint)))
		{
			if(point.action == Waypoint.Action.reception)
			{
				if(point.owner == null)
				{
					//point.owner = this;
					assignedWorkplace = true; 
				}
				else
				{
					print ("No Objects To Own :(. Staff without purpose!");
				}
			}
		}
	}
	
	void TakeOwnership()
	{

			switch(role)
			{
			case Role.receptionist:
				TakeReceptionOwnership();
				break;
			default:
				break;
			}

	}
	void FindWorkPlace()
	{
		
	}
	void SetRole(Role newRole)
	{
		role = newRole;
	}
	void FindWorkplace()
	{
		switch(role)
			{
			case Role.receptionist:
				break;
			case Role.caretaker:
				break;
			case Role.cleaner:
				break;
			case Role.gardener:
				break;
			case Role.practitioner:
				break;
			}
		
	}
	void NextWaypoint()
	{
		if(nextWaypoint.visited)
		{
			
		currentWaypoint = nextWaypoint;
		

		nextWayPointNumber++;
		waypointNumber = nextWayPointNumber -1;
		if(waypoints.Count == 1)
		{
			waypointNumber = 0;
			nextWayPointNumber =0;
		}
		if(nextWayPointNumber < waypoints.Count)
		{

			nextWaypoint = waypoints[nextWayPointNumber];	
		}
		else
			{
			hoursUntilNextAction = currentWaypoint.GetWaitTime ();
			if(waypointNumber == waypoints.Count - 1)
					{
						CheckIfNewRouteNeeded ();
					}

			}
		//SetState();
		}

	}
	
	void CheckIfNewRouteNeeded()
	{
		if(currentWaypoint.action == Waypoint.Action.enter)
		{
				SelectRoute();
		}
		else
		{
			
		}
			//Do Nothing for now.

	}
	void BreakPath()
	{
		path = null; 
	}
	
	void BuildWaypoints()
	{if(path != null)
		{
			
		
		if(state == State.waiting)
		{
			return;
		}
		waypointNumber = 0;
		nextWayPointNumber = 0;
		if(waypoints != null)
		{
			waypoints.Clear ();
			waypoints.TrimExcess ();
			waypoints = new List<Waypoint>();
		}
		else
		{
			waypoints = new List<Waypoint>();
		}
		if(currentWaypoint != null)
			waypoints.Add(currentWaypoint);
		foreach(Waypoint point in path.GetWayPoints ())
		{
			waypoints.Add (point);
		}
		currentWaypoint = waypoints[waypointNumber];
		nextWayPointNumber = waypointNumber + 1; 
		if(nextWayPointNumber < waypoints.Count)
		{
			if(waypoints[nextWayPointNumber] != null)
				nextWaypoint = waypoints[nextWayPointNumber];
		}
			hoursUntilNextAction = nextWaypoint.timeToStayAtWaypoint;
		}
		else
			Debug.Log ("NoPATH!");
		
	}
	
	void SetState()
	{
		switch(currentWaypoint.action)
		{
		case Waypoint.Action.work:
			state = State.working;
			break;
		case Waypoint.Action.book:
			state = State.booking;
			break;
		case Waypoint.Action.wait:
			state = State.waiting;
			break;
		case Waypoint.Action.enter:
			state = State.entering;
			break;
		case Waypoint.Action.exit:
			state = State.leaving; 
			break; 
		case Waypoint.Action.reception:
			state = State.working;
			break;
		case Waypoint.Action.receptionAction:
			state = State.working;
			break;
			
		default:
			state = State.entering;
			break;
		}
	}
	
	public State GetState()
	{
		return state; 
	}
	
	void MoveToStart()
	{
		transform.position = currentWaypoint.point.transform.position;
	}
	public void HourPassed()
	{
		hoursUntilNextAction--;
		if(hoursUntilNextAction < 0)
			hoursUntilNextAction = 0;
	}
	
	void GenerateName()
	{
		if(staffName == "")
		{
			staffName = nameGenerator.CreateName (male,Random.Range (2,3));
		}
	}
	// Update is called once per frame
	void Update () 
	{
		
//		currentState = state.ToString ();
//		
		if(!assignedWorkplace)
		{
		TakeOwnership();
	}
//			if(hoursUntilNextAction == 0)
//			{
//				NextWaypoint ();
//			}
//			if(hoursUntilNextAction > 0)
//			{
//				transform.position = Vector3.Lerp (transform.position, currentWaypoint.transform.position, Time.deltaTime);
//			}
//			else
//			{
//				Vector3 destination = transform.position; 
//				destination.x = Mathfx2.Berp(transform.position.x, nextWaypoint.transform.position.x, Time.deltaTime * 0.5f);
//				destination.y = 0.5f;
//				destination.z = Mathfx2.Berp(transform.position.z, nextWaypoint.transform.position.z, Time.deltaTime * 0.5f);
//				transform.position = destination;//Vector3.Lerp (transform.position, destination, Time.deltaTime * 0.5f);
//				transform.LookAt (nextWaypoint.point.transform);
//			}
//			waypointTracker = nextWayPointNumber;
	}
	
	
	void SelectRoute()
	{
		//path = new Route();
		hoursUntilNextAction = 0;
		
	 	Route[] routes = FindObjectsOfType(typeof(Route)) as Route[];
		List<Route> avaliableRoutes = new List<Route>();
			switch(role)
			{
			case Role.receptionist:
					//path.CreateReceptionPath(this);
						BuildWaypoints ();
				break;
			case Role.caretaker:
				break;
			case Role.cleaner:
				break;
			case Role.gardener:
				break;
			case Role.practitioner:
				break;
			}
		
		

	}
	
	void GetExitRoute()
	{
		Route[] routes = FindObjectsOfType (typeof(Route)) as Route[];
		foreach(Route route in routes)
		{
			if(route.type == Route.Type.exit)
			{
				path = route;
			}
		}
		BuildWaypoints();
	}
	public void GoHome()
	{
		state = State.leaving;
		GetExitRoute(); 
		hoursUntilNextAction = 0;

	}
	public void StartWork()
	{
		state = State.entering;
		MoveToStart ();
		GetDefaultRoute(); 
		hoursUntilNextAction = 0;
		
	}
	void GetDefaultRoute()
	{
		Route[] routes = FindObjectsOfType (typeof(Route)) as Route[];
		foreach(Route route in routes)
		{
			if(route.type == Route.Type.entry)
			{
				path = route;
			}
		}
		BuildWaypoints();
	}
	void OnCollisionEnter(Collision other)
	{
		if(other.transform.GetComponent(typeof(Waypoint)))
		{
			other.transform.GetComponent<Waypoint>().WaypointHit(true);
		}
	}
	
	void OnCollisionExit(Collision other)
	{
		if(other.transform.GetComponent(typeof(Waypoint)))
		{
			other.transform.GetComponent<Waypoint>().WaypointHit(false);
		}
	}

}
