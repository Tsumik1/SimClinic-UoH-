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
		practice,
		practiceAction,
		sit, 
		queue,
		clinic,
		
	}
	
	public Action defaultAction;
	public Action action{get;set;}
	public bool visited = false; 
	public int timeToStayAtWaypoint;
	public bool occupied = false; 
	//public GameObject point;
	public Staff owner; 
	public string ownerName; 
	// Use this for initialization
	void Awake () 
	{
		action = defaultAction;
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
		//Debug.Log ("I'm Hit");
	}
	
	public void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "patient")
		{
			occupied = true; 
		}
	}
	
	public void OnCollisionExit(Collision col)
	{
		if(col.gameObject.tag == "patient")
		{
			occupied = false; 
		}
	}
}
