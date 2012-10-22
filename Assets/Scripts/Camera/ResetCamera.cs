using UnityEngine;
using System.Collections;

public class ResetCamera : MonoBehaviour {
	
	
	private Vector3 defaultCameraPosition;
	private Vector3 defaultAngles;
	// Use this for initialization
	void Start () 
	{
		 defaultCameraPosition = Camera.main.transform.position;
		 defaultAngles = Camera.main.transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Clicked()
	{
		Camera.main.transform.position = defaultCameraPosition; 
		Camera.main.transform.eulerAngles = defaultAngles;
	}
}
