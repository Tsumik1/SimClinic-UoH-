using UnityEngine;
using System.Collections;

public class ButtonMove : MonoBehaviour {

	
	public Vector3 newPosition; 
	// Use this for initialization
	void Start () {
	    newPosition = transform.position;
		newPosition.x += 5; 
	}
	
	// Update is called once per frame
	void Update () 
	{

	transform.position = Vector3.Lerp (transform.position,newPosition, Time.deltaTime * 1.0f);
	
	}
}
