using UnityEngine;
using System.Collections;

public class RevertToMainCamera : MonoBehaviour {

	
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown (KeyCode.Escape))
		{
						//Camera.main.enabled = false; 
			this.camera.enabled = false;
			this.GetComponent<MouseLook>().enabled = false;
			Camera[] cameras = 	FindObjectsOfType (typeof(Camera)) as Camera[];
			foreach(Camera cam in cameras)
			{
				
				cam.enabled = false; 
				if(cam.tag == "primaryCamera" || cam.tag == "MainCamera")
				{
					cam.enabled = true;
					cam.GetComponent<DetectClicksAndTouches>().enabled = true;
				}
			}
			

			GUIManager.popUpSmall = false;
			GUIManager.popUpMain = false;
		}
	
	}
	
	void Clicked()
	{

	}
}
