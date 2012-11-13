using UnityEngine;
using System.Collections;

public class LookAtMouse : MonoBehaviour {
	
	// speed is the rate at which the object will rotate
	public float speed;
 	public Camera UICam; 
	
	
	private Vector3 screenMouse;
	private Vector3 buttonPos; 
	private Vector3 worldMouse; 
	void Update () 
	{
		screenMouse.x = Input.mousePosition.x; 
		screenMouse.y = Input.mousePosition.y;
		screenMouse.z = 1; 
		
		worldMouse = Camera.main.ScreenToWorldPoint (screenMouse);
		
		buttonPos = transform.position; 
		
		float angle = Mathf.Atan2(buttonPos.z-worldMouse.z, buttonPos.x -worldMouse.x) * 180/ Mathf.PI;
		
		transform.localEulerAngles = new Vector3(0,0,-angle * 50000);
		
		
	}
}