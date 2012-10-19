using UnityEngine;
using System.Collections;

public class WallsDown : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Clicked()
	{
		GameObject walls = GameObject.FindGameObjectWithTag ("wallup") as GameObject;
		Destroy (walls);
		WallsUp.wallsup = false;
	}
}
