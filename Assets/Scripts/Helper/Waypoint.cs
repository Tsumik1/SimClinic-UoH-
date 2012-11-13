using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {
	
	public enum Action
	{
		work, 
		wait,
		book,
		enter,
		exit,
		pace,
		staff,
		patient, 
		reception, 
		plant, 
		fire, 
		receptionAction,
		
	}
	
	public Action defaultAction;
	public Action action{get;set;}
	public bool visited = false; 
	public int timeToStayAtWaypoint;
	public GameObject point;
	public Staff owner; 
	public string ownerName; 
	// Use this for initialization
	void Awake () 
	{
		action = defaultAction;
		switch(action)
		{
		case Action.work:
			timeToStayAtWaypoint = 4;
			break;
		case Action.reception:
			timeToStayAtWaypoint = 0;
			break;
		case Action.wait:
			timeToStayAtWaypoint = 1;
			break;
		case Action.book:
			timeToStayAtWaypoint = 1;
			break;
		default:
			timeToStayAtWaypoint = 0;
			break;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(owner)
		{
			ownerName = owner.staffName;
		}
	}
	
	public int GetWaitTime()
	{
		return timeToStayAtWaypoint;
	}
	
	public void WaypointHit(bool hit)
	{
		visited = hit;
	}
}
