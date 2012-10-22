using UnityEngine;
using System.Collections;

public class SwitchToFirstPerson : MonoBehaviour {
	
	
	public Camera firstPersonCamera; 
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Clicked()
	{
		if(firstPersonCamera)
		{
			Camera[] cameras = 	FindObjectsOfType (typeof(Camera)) as Camera[];
			foreach(Camera cam in cameras)
			{
				
				cam.enabled = false; 
				if(cam.tag == "primaryCamera" || cam.tag == "MainCamera")
				{
					cam.GetComponent<DetectClicksAndTouches>().enabled = false;
				}
			}
			
			//Camera.main.enabled = false; 
			firstPersonCamera.enabled = true;
			firstPersonCamera.GetComponent<MouseLook>().enabled = true;
			

		}
	}
}
