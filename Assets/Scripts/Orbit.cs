using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour {
	
	
	public Transform target; 
	
	private Vector3 angles; 
	public bool movement = false; 
	// Use this for initialization
	void Start () {
		angles = transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		if(movement)
		{
		if(angles.y + 90 == transform.eulerAngles.y)
		{
			angles = transform.eulerAngles;
				movement = false;
		}
		else
		{
			Camera.main.transform.LookAt (target);
			Camera.main.transform.Translate (Vector3.right * Time.deltaTime);
		}
		}
	}
	
	void Clicked()
	{
		if(movement)
		{movement = false;}
		else
		{
		  movement = true;
		}
	}
}
