using UnityEngine;
using System.Collections;

public class GotoOptions : MonoBehaviour {
	
	
	public Transform location;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Clicked()
	{
		Camera.main.transform.position = location.position;
	}
}
