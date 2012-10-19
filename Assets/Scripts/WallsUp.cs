using UnityEngine;
using System.Collections;

public class WallsUp : MonoBehaviour {
	
	
	public GameObject walls;
	
	
	public bool wallsup = false; 
	
	private GameObject wallObject;
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
			wallObject = Instantiate (walls) as GameObject;
			wallsup = true;
		}
		else
		{
			wallsup = false;
			Destroy(wallObject);
		}
	}
}
