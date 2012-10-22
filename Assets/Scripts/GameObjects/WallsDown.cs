using UnityEngine;
using System.Collections;

public class WallsDown : MonoBehaviour {
	
	public GameObject walls;
	
	private GameObject wallObject;
	
	public static bool walldown;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Clicked()
	{
		if(WallsUp.wallsup)
		{
			wallObject = Instantiate (walls, new Vector3(0,0,0), Quaternion.identity) as GameObject;
						wallObject.transform.eulerAngles= new Vector3(270,90,0);
			walldown = true;
			GameObject wall = GameObject.FindGameObjectWithTag ("wallup") as GameObject;
			Destroy (wall);
			WallsUp.wallsup = false;
		}
	}
}
