using UnityEngine;
using System.Collections;

public class ObjectPlacementManager : MonoBehaviour {

	
	public static bool placing = false;
	
	// Use this for initialization
	void Awake () 
	{
		GameObject[] objects = FindObjectsOfType(typeof(GameObject)) as GameObject[];
		
		foreach(GameObject o  in objects)
		{
			o.StoreStandardColour();
		}
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
