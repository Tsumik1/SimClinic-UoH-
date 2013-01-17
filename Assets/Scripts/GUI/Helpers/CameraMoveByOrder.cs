using UnityEngine;
using System.Collections;

public class CameraMoveByOrder : MonoBehaviour {
	
	public enum Direction
	{
		next,
		prev
	}
	
	public Direction dir; 
	
	
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	
	void Clicked()
	{
		if(dir == Direction.next)
		{
			CameraWaypointManager.NextWaypoint();
		}
		if(dir == Direction.prev)
		{
			CameraWaypointManager.PreviousWaypoint();
		}

	}
}
