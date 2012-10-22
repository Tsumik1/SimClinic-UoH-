using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour {
	
	
	public Transform target; 
	
	private Vector3 angles; 
	public bool movement = false; 
	public enum Direction 
	{
		left = 0, 
		right = 1,
	}
	
	public Direction direction;
	// Use this for initialization
	
	void Start () {
		angles = transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void Clicked()
	{
		if(direction == Direction.left)
		{
			Vector3 newAngles = new Vector3(0,0,90);
			Camera.main.transform.Rotate (newAngles);
		}
		else
			if(direction==Direction.right)
		{
			Vector3 newAngles = new Vector3(0,0,-90);
			Camera.main.transform.Rotate (newAngles);
		}

	}
}
