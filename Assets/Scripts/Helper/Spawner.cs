using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] pathPoints; 
	public GameObject[] spawnList;
	
	private int spawnIndex = 0; 
	private int currentPathIndex = 0; 
	private Vector3 movementDirection ;
	
	public GameObject arrow;
	public float spawnTime = 1.0f; 
	public float initialSpawn = 10.0f; 
	// Use this for initialization
	void Start () 
	{
		//CreateGraphicalPathObjects();
		//drawFullPath ();
		InvokeRepeating ("Spawn", initialSpawn, spawnTime);
	}
	
	void CreateGraphicalPathObjects()
	{
		Vector3 midPoint = ((pathPoints[0].transform.position - transform.position)*0.5f) + transform.position;
		midPoint.y -= 0.01f;
		Quaternion facing = Quaternion.LookRotation (pathPoints[0].transform.position - transform.position);
		GameObject pathArrow = Instantiate(arrow, midPoint, facing)as GameObject;
		Vector3 newScale = Vector3.one;
		newScale.y = 0.01f;
		newScale.z = (pathPoints[currentPathIndex].transform.position - transform.position).magnitude; 
		pathArrow.transform.localScale +=	newScale;
		//pathArrow.transform.localScale *= 3; 
		Vector2 tileX = Vector2.one;
		tileX.y = (pathPoints[0].transform.position - transform.position).magnitude;
		pathArrow.renderer.material.mainTextureScale = tileX;
		
		for(int i = 1; i <pathPoints.Length; i++)
		{
		 midPoint = ((pathPoints[i].transform.position - pathPoints[i-1].transform.position)*0.5f) + pathPoints[i-1].transform.position;
					midPoint.y -= 0.01f;
		 facing = Quaternion.LookRotation (pathPoints[i].transform.position - pathPoints[i-1].transform.position);
		 pathArrow = Instantiate(arrow, midPoint, facing)as GameObject;
		 newScale = Vector3.one;
		newScale.y = 0.01f;
		newScale.z = (pathPoints[i].transform.position - pathPoints[i-1].transform.position).magnitude; 
		pathArrow.transform.localScale +=	newScale;
		//pathArrow.transform.localScale *= 3; 
		 tileX = Vector2.one;
		tileX.y = (pathPoints[i].transform.position - pathPoints[i-1].transform.position).magnitude;
		pathArrow.renderer.material.mainTextureScale = tileX;
		}
	}	
	
	void drawFullPath()
	{

	}
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void Spawn()
	{
		GameObject newEnemy = Instantiate (spawnList[spawnIndex], transform.position, transform.rotation) as GameObject;
		newEnemy.SendMessage ("SetPathPoints", pathPoints);
		spawnIndex++; 
		if(spawnIndex >= spawnList.Length)
		{
			print("No more enemies");
			spawnIndex = 0;
			spawnTime = spawnTime / 2;
			//CancelInvoke ("Spawn");
		}
		else
		{

		}
	}
	
	void SetPathPoints(GameObject[] inputPathPoints)
	{
		pathPoints = inputPathPoints; 
	}
	
	void OnDrawGizmos()
	{
		Gizmos.DrawLine (transform.position, pathPoints[0].transform.position);
		
		for(int i = 1; i < pathPoints.Length;i++)
		{
			Gizmos.DrawLine(pathPoints[i-1].transform.position, pathPoints[i].transform.position);
		}
	}
}
