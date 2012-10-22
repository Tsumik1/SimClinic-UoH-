using UnityEngine;
using System.Collections;

public class CameraBounds : MonoBehaviour {
	
	
	public float upperBound = 6f;
	public float lowerBound = -6f; 
	public float leftBound = -8f;
	public float rightBound = 10f;
	public float zoomInBound = 5.5f;
	public float zoomOutBound = 20f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 newPos = new Vector3(transform.position.x,transform.position.y,transform.position.z);
		if(transform.position.z > upperBound)
		{
			newPos.z = upperBound;
		}
		
		if(transform.position.z < lowerBound)
		{
			newPos.z = lowerBound;
		}
		
		if(transform.position.x < leftBound)
		{
			newPos.x = leftBound; 
		}
		
		if(transform.position.x > rightBound)
		{
			newPos.x = rightBound;
		}
		
		if(transform.position.y > zoomOutBound)
		{
			newPos.y = zoomOutBound;
		}
		
		if(transform.position.y < zoomInBound)
		{
			newPos.y = zoomInBound;
		}
		transform.position = newPos;
	}
}
