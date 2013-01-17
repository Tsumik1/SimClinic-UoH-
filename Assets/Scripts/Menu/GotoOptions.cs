using UnityEngine;
using System.Collections;

public class GotoOptions : MonoBehaviour {
	
	
	public Transform location;
	public Transform snapshot; 
	public bool active = false; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
			if(active)
		{
			Camera.main.transform.position = Vector3.Lerp (Camera.main.transform.position, location.position, Time.deltaTime);
		}
	}
	
	void Clicked()
	{
		foreach(GotoOptions g in FindObjectsOfType(typeof(GotoOptions)))
		{
			g.active = false; 
		}
			active = true;
	}
}
