using UnityEngine;
using System.Collections;

public class Patient : MonoBehaviour {
	
	
	public enum State
	{
		entering, 
		talking, 
		booking,
		waiting,
		leaving
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
	public int patientSatisfaction =0; 
	//public Waypoint[] waypoints;
	public Waypoint targetPoint;
	private NameGenerator nameGenerator;
	private AIPath myPath; 
	
	// Use this for initialization
	void Start () 
	{
		male = Helper.RandomBool ();
		nameGenerator = new NameGenerator();
		patientName = Helper.GenerateName (male, Random.Range (2,3));
		myPath = GetComponent<AIPath>();
		targetPoint = WaypointManager.FindReceptionist().transform;
		if(targetPoint == null)
		{
			targetPoint = WaypointManager.FindExitWaypoint();
			print (patientName + "This place has no receptionist, i'm going home.");
			patientSatisfaction -= 20; 
			
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
