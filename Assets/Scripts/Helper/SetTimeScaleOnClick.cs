using UnityEngine;
using System.Collections;

public class SetTimeScaleOnClick : MonoBehaviour {

	
	public float timeSpeed = 1f; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void Clicked()
	{
		Time.timeScale = timeSpeed;
	}
}
