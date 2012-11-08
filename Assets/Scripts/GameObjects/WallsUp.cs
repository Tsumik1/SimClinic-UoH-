using UnityEngine;
using System.Collections;

public class WallsUp : MonoBehaviour {
	
	
	public GameObject walls;
	
	
	public static bool wallsup = false; 
	
	private GameObject wallObject;
	public Transform defaultTransform; 
		// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Clicked()
	{
		if(!wallsup)
		{	
			wallObject = Instantiate (walls, defaultTransform.position, defaultTransform.rotation) as GameObject;

			wallsup = true;
			GameObject wall = GameObject.FindGameObjectWithTag ("walldown") as GameObject;
			Destroy (wall);
			WallsDown.walldown = false;
			
		}
		else
		{
			//wallsup = false;
			//Destroy(wallObject);
		}
	}
}
