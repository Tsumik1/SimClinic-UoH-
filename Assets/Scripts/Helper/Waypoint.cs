using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {
	
	
	
	public enum Action
	{
		work, 
		wait,
		book,
	}
	
	public Action action;
	public GameObject point;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
