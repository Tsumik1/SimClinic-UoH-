using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Route : MonoBehaviour {
	
	public enum Type 
	{
		entry,
		receptionist,
		practitioner,
		caretaker,
		cleaner,
		gardener,
		patient,
		patientSpecificNeed,
		exit
	}
	
	public Waypoint[] waypoints; // Can be pre-defined
	public Type type {get; set;} 
	public Type defaultType; 
	public bool randomPath = false;
			public int currentIndex = 0; 
	// Use this for initialization
	void Awake () 
	{
		type = defaultType;
		if(randomPath)
		{
			CreateRandomPath();
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	public Waypoint[] GetWayPoints()
	{
		return waypoints; 
	}
	//Methods to create paths per type.
	public void CreateReceptionPath(Staff staffMember)
	{
	   Waypoint[] worldPoints = FindObjectsOfType(typeof(Waypoint)) as Waypoint[];
		List<Waypoint> avaliablePoints = new List<Waypoint>();
	   foreach(Waypoint point in worldPoints)
		{
			//If the staff member owns the waypoint(i.e the desk)
			if(point.owner == staffMember)
			{
				avaliablePoints.Add (point);
			}
			if(point.action == Waypoint.Action.receptionAction)
			{
				avaliablePoints.Add (point);
			}
		}
		if(avaliablePoints.Count == 1)
		{
			avaliablePoints[0].timeToStayAtWaypoint = 8;
		}
		if(avaliablePoints.Count >= 1)
		{
			waypoints = new Waypoint[avaliablePoints.Count];
			for(int i = 0; i  < avaliablePoints.Count; i++)
			{
				waypoints[i] = avaliablePoints[i];
			}
			staffMember.state = Staff.State.working;
			type = Type.receptionist;
		}
		else
		{
			staffMember.state = Staff.State.waiting;
		}
	}
	
	public void CreateGardenPath()
	{
		
	}
	
	public void CreateCleanPath()
	{
		
	}
	
	public void CreatePatientPath()
	{
		
	}
	
	public void CreatePracticePath()
	{
		
	}
	
	public void CreateRandomPath()
	{
		currentIndex = 0;
		//Path MUST contain at least one enter node and one exit node, minimum of 3 nodes. 
		Waypoint[] worldPoints = FindObjectsOfType(typeof(Waypoint)) as Waypoint[];

		List<Waypoint> entryPoints = new List<Waypoint>();
		List<Waypoint> exitPoints = new List<Waypoint>(); 
		List<Waypoint> otherPoints = new List<Waypoint>(); 
		//initiate the StartNode
		foreach(Waypoint point in worldPoints)
		{
			if(IsEntry (point))
			{
				entryPoints.Add (point);
			}
			if(IsExit (point))
			{
				exitPoints.Add (point);
			}
			else
			{
				otherPoints.Add(point);
			}
		}
		int entryNodes = Random.Range(1, entryPoints.Count-1);
		int exitNodes = Random.Range (1, exitPoints.Count-1);
		int other = Random.Range (1, otherPoints.Count-1);
		int size = entryNodes + exitNodes + other; 
				waypoints = new Waypoint[size];
			for(int i = 0; i <= entryNodes; i++)
			{
				int E = Random.Range (0, entryPoints.Count);
				if(currentIndex < size)
					waypoints[currentIndex] = entryPoints[E];
					currentIndex++;
			}
			for(int i = 0; i <= other; i++)
			{
				int O = Random.Range (0,otherPoints.Count);
				if(currentIndex < size)
					waypoints[currentIndex] = otherPoints[O];	
					currentIndex++;
			}
			for(int i = 0; i <= exitNodes; i++)
			{
				int ex = Random.Range(0,exitPoints.Count);
				if(currentIndex < size)
					waypoints[currentIndex] = exitPoints[ex];
					currentIndex++;
			}

		SetParents ();

	}
	
	public void SetParents()
	{
		foreach(Waypoint w in waypoints)
		{
			//w.transform.parent = transform;
		}
	}
	
	public bool IsEntry(Waypoint point)
	{
		if(point.action == Waypoint.Action.enter)
			return true; 
		else
			return false; 
		
	}
	
	public bool IsExit(Waypoint point)
	{
		if(point.action == Waypoint.Action.exit)
			return true; 
		else
			return false; 
	}
	
	public bool IsWork(Waypoint point)
	{
		if(point.action == Waypoint.Action.work)
			return true; 
		else
			return false; 
	}
	
	public bool IsWait(Waypoint point)
	{
		if(point.action == Waypoint.Action.wait)
			return true; 
		else
			return false; 
	}
	
	public bool IsOther(Waypoint point)
	{
		return true;
	}
	
	void OnDrawGizmos()
	{
		try
		{
			if(randomPath)
			{
				//Gizmos.DrawLine (transform.position, waypoints[0].point.transform.position);
		
				for(int i = 1; i < waypoints.Length;i++)
				{
					Gizmos.DrawLine(waypoints[i-1].point.transform.position, waypoints[i].point.transform.position);
				}
			}
			else
			if(waypoints != null)
			{
				for(int i = 1; i < waypoints.Length;i++)
				{
					Gizmos.DrawLine(waypoints[i-1].point.transform.position, waypoints[i].point.transform.position);
				}
			}
		}
		catch
		{
			print ("No Nodes Found");
		}

	}
}
