using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Staff : MonoBehaviour {
	
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
	
	private Waypoint currentWaypoint; 
	private Waypoint nextWaypoint;
	private Vector3 movementDirection ;
	private NameGenerator nameGenerator;
	private int waypointNumber = 0; 
	private int nextWayPointNumber = 0;
	private bool assignedWorkplace = false; 

	// Use this for initialization
	void Start () {
		SetRole(defaultRole);
		nameGenerator = new NameGenerator();
		GenerateName();
		TakeOwnership(); 
		GetDefaultRoute();
		//SelectRoute (); //BuildWaypoints ();
		hoursUntilNextAction = TimeManager.HoursUntilOpeningTime();
		movementDirection = (transform.position).normalized;
	}
	
void TakeReceptionOwnership()
	{
		foreach(Waypoint point in FindObjectsOfType(typeof(Waypoint)))
		{
			if(point.action == Waypoint.Action.reception)
			{
				if(point.owner == null)
				{
					point.owner = this;
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
		if(!assignedWorkplace)
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
		if(nextWayPointNumber < waypoints.Count)
		{
			waypointNumber++;
			nextWaypoint = waypoints[nextWayPointNumber];	
		}
			else
			{
				nextWayPointNumber = waypointNumber;
				SelectRoute();
				print ("I have nowhere to go...");
				//END OF LINE...FOR NOW :). 
			}
		hoursUntilNextAction = currentWaypoint.GetWaitTime ();
		SetState();
		}
	}
	
	
	void BreakPath()
	{
		path = null; 
	}
	
	void BuildWaypoints()
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
		}
		else
		{
			waypoints = new List<Waypoint>();
		}
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
		default:
			state = State.entering;
			break;
		}
	}
	
	void GetState()
	{
		
	}
	
	void ForceExit()
	{
		nextWaypoint = waypoints[waypoints.Count-1];
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
		TakeOwnership();
		if(state == State.waiting)
		{
			SelectRoute ();
		}
		else
		{
			if(hoursUntilNextAction == 0)
			{
				NextWaypoint ();
			}
			if(hoursUntilNextAction > 0)
			{
				transform.position = Vector3.Lerp (transform.position, currentWaypoint.transform.position, Time.deltaTime);
			}
			else
			{
				Vector3 destination = transform.position; 
				destination.x = Mathfx.Berp(transform.position.x, nextWaypoint.transform.position.x, Time.deltaTime * 0.5f);
				destination.y = 0.5f;
				destination.z = Mathfx.Berp(transform.position.z, nextWaypoint.transform.position.z, Time.deltaTime * 0.5f);
				transform.position = destination;//Vector3.Lerp (transform.position, destination, Time.deltaTime * 0.5f);
				transform.LookAt (nextWaypoint.point.transform);
			}
			waypointTracker = nextWayPointNumber;
		}
	}
	
	
	void SelectRoute()
	{
		path = new Route();
	 	Route[] routes = FindObjectsOfType(typeof(Route)) as Route[];
		List<Route> avaliableRoutes = new List<Route>();
		foreach(Route route in routes)
		{
			switch(role)
			{
			case Role.receptionist:
				
				if(route.type == Route.Type.receptionist)
				{
					path.CreateReceptionPath(this);
				}
				break;
			case Role.caretaker:
				if(route.type == Route.Type.caretaker)
				{
					avaliableRoutes.Add (route);
				}
				break;
			case Role.cleaner:
				if(route.type == Route.Type.cleaner)
				{
					avaliableRoutes.Add (route);
				}
				break;
			case Role.gardener:
				if(route.type == Route.Type.gardener)
				{
					avaliableRoutes.Add (route);
				}
				break;
			case Role.practitioner:
				if(route.type == Route.Type.practitioner)
				{
					avaliableRoutes.Add (route);
				}
				break;
			}
		}
		
		BuildWaypoints ();
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
		GetExitRoute(); 
	}
	public void StartWork()
	{
		MoveToStart ();
		GetDefaultRoute(); 
		SetState();
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
		other.transform.SendMessage("WaypointHit", true);
	}
	
	void OnCollisionExit(Collision other)
	{
		other.transform.SendMessage ("WaypointHit", false);
	}

}
