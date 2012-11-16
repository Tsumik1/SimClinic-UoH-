using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaypointManager : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
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
	
	public static Waypoint[] FindStaffWaypoints(Staff staff)
	{
		switch(staff.role)
		{
		case Staff.Role.receptionist:
			return FindReceptionWaypoints(staff);
		default:
			return null;
		}
	}
	
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
			waypoints[0] = desk;
		}
		return waypoints;
	}
	
	public static Waypoint[] FindAllWaypoints()
	{
		return FindObjectsOfType(typeof(Waypoint)) as Waypoint[];
	}
}
