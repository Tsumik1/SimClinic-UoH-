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
	
	public Role role;
	public State state; 
	public Route path;
	public string staffName;
	public int salary;
	public int hoursUntilNextAction;
	
	private GameObject currentWaypoint; 
	
	private NameGenerator nameGenerator;
	// Use this for initialization
	void Start () {
				nameGenerator = new NameGenerator();
		GenerateName();
		
	}
	
	
	void BuildWaypoints(Transform[] waypoints)
	{
		
	}
	
	
	void MoveToNextWaypoint()
	{
		
	}
	
	
	void GenerateName()
	{
		if(staffName == "")
		{
			staffName = nameGenerator.GenerateName ();
		}
		
	}
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void SelectRoute()
	{
	 	Route[] routes = FindObjectsOfType(typeof(Route)) as Route[];
		List<Route> avaliableRoutes = new List<Route>();
		foreach(Route route in routes)
		{
			switch(role)
			{
			case Role.receptionist:
				if(route.type == Route.Type.receptionist)
				{
					
				}
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
		
	}
}
