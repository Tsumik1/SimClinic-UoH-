using UnityEngine;
using System.Collections;

public class GotoOptions : MonoBehaviour {
	
	
	public Transform location;
	public bool active = true; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Clicked()
	{
		if(active)
		{
			Camera.main.transform.position = location.position;
		}
	}
}
