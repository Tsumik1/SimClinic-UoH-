using UnityEngine;
using System.Collections;

public class Route : MonoBehaviour {
	
	public enum Type 
	{
		receptionist,
		practitioner,
		caretaker,
		cleaner,
		gardener
	}
	
	public Waypoint[] waypoints;
	public Type type {get; set;} 
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public Transform GetWayPoints()
	{
		
	}
}
