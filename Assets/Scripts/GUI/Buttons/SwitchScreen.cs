using UnityEngine;
using System.Collections;

public class SwitchScreen : MonoBehaviour {

	// Use this for initialization
	
	public Camera UIStart; 
	public Camera UITarget; 
	
	private DetectClicksAndTouches touchStart;
	private DetectClicksAndTouches touchTarget;
	
	void Start () 
	{
		 touchStart = UIStart.GetComponent("DetectClicksAndTouches") as DetectClicksAndTouches;
		 touchTarget = UITarget.GetComponent("DetectClicksAndTouches") as DetectClicksAndTouches;	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Clicked()
	{

		UIStart.enabled = false;
		touchStart.enabled = false; 
		UITarget.enabled = true; 
		touchTarget.enabled = true;
	}
}
