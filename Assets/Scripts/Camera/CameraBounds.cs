using UnityEngine;
using System.Collections;

public class CameraBounds : MonoBehaviour {
	
	
	public float upperBound = 6f;
	public float lowerBound = -6f; 
	public float leftBound = -8f;
	public float rightBound = 10f;
	public float zoomInBound = 5.5f;
	public float zoomOutBound = 20f;
	public bool local; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(local)
		{
			MoveLocal ();
		}
		else
		{
			Move ();
		}
	}
	
	void Move()
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
	
	void MoveLocal()
	{
						Vector3 newPos = new Vector3(transform.localPosition.x,transform.localPosition.y,transform.localPosition.z);
		if(transform.localPosition.z > upperBound)
		{
			newPos.z = upperBound;
		}
		
		if(transform.localPosition.z < lowerBound)
		{
			newPos.z = lowerBound;
		}
		
		if(transform.localPosition.x < leftBound)
		{
			newPos.x = leftBound; 
		}
		
		if(transform.localPosition.x > rightBound)
		{
			newPos.x = rightBound;
		}
		
		if(transform.localPosition.y < zoomOutBound)
		{
			newPos.y = zoomOutBound;
		}
		
		if(transform.localPosition.y > zoomInBound)
		{
			newPos.y = zoomInBound;
		}
		transform.localPosition = newPos;
	}
}
