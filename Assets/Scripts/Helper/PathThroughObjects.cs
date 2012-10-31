using UnityEngine;
using System.Collections;

public class PathThroughObjects : MonoBehaviour 
{
	public GameObject[] pathPoints; 
	//public Path path; 
	public float speed = 1.0f; 
	public bool destroyAtEnd = false;
	
	private int currentPathIndex = 0; 
	private Vector3 movementDirection ;
	
	public GameObject arrow;  //graphicalPathObject;
	
	// Use this for initialization
	void Start () 
	{
		movementDirection = (pathPoints[currentPathIndex].gameObject.transform.position - transform.position).normalized;
	}
	
	void SetPathPoints(GameObject[] inputPathPoints)
	{
		pathPoints = inputPathPoints; 
	}

	// Update is called once per frame
	void Update () 
	{
		transform.position += movementDirection * speed * Time.deltaTime;

	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name == pathPoints[currentPathIndex].name)
		{
			transform.position = pathPoints[currentPathIndex].transform.position;
			currentPathIndex++;

			if(currentPathIndex >= pathPoints.Length)
			{
				if(destroyAtEnd)
				{
					Destroy (gameObject);
				}
				else
				{
					print("I messed up...");
				}
			}
			else
			{
			  movementDirection = (pathPoints[currentPathIndex].transform.position - transform.position).normalized;
			}
		}
	}
	
	void SetSpeed(float newSpeed)
	{
		speed *= newSpeed; 
	}
}
