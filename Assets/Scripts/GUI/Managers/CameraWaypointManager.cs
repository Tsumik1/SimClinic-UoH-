using UnityEngine;
using System.Collections;

public class CameraWaypointManager : MonoBehaviour {
	
	public static int waypointNumber = 0;
	
	public static CameraWaypoint gotoLocation; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(gotoLocation)
		{
			Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, gotoLocation.transform.position, Time.deltaTime);
			Camera.main.transform.rotation = Quaternion.Lerp (Camera.main.transform.rotation, gotoLocation.transform.rotation, Time.deltaTime);
		}
	}
	public static int GetWaypointNumber()
	{
		return waypointNumber;
	}
	
	public static CameraWaypoint FindCameraWaypoint(int i)
	{
		CameraWaypoint a = null; 
		foreach(CameraWaypoint c in FindObjectsOfType(typeof(CameraWaypoint)))
		{
			if(c.waypointNumber == i)
			{
				a = c;
			}
		}
		return a; 
	}
	
	public static int GetMaximum()
	{
		return FindObjectsOfType (typeof(CameraWaypoint)).Length - 1;
	}
	
	public static void NextWaypoint()
	{
		waypointNumber++;
		if(waypointNumber > GetMaximum ())
		{
			waypointNumber = GetMaximum();
		}
		gotoLocation = FindCameraWaypoint (waypointNumber);
	}
	
	public static void PreviousWaypoint()
	{
		waypointNumber--;
		if(waypointNumber < 0)
		{
			waypointNumber = 0;
		}
		gotoLocation = FindCameraWaypoint(waypointNumber);
	}
}
