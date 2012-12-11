using UnityEngine;
using System.Collections;

public class ScrollControl : MonoBehaviour {
	
	public float scrollAmount; 
	private Camera contentCamera; 
	private Vector3 newPosition; 
	
	public enum Direction
	{
		up,
		down,
		left,
		right
	}
	
	public Direction direction;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Clicked()
	{
				
			Camera[] cameras = 	FindObjectsOfType (typeof(Camera)) as Camera[];
			foreach(Camera cam in cameras)
			{
				
				if(cam.tag == "contentCamera")
				{
					contentCamera = cam;
				newPosition = contentCamera.transform.position;
				}
			}
		switch(direction)
		{
		case Direction.up:
			newPosition.y += scrollAmount;
			break;
		case Direction.down:
			newPosition.y -= scrollAmount;
			break;
		case Direction.left:
			newPosition.x -= scrollAmount;
			break;
		case Direction.right: 
			newPosition.x += scrollAmount;
			break;
		default:
			break;
		}
		if(contentCamera)
			contentCamera.transform.position = newPosition;
	}
}
