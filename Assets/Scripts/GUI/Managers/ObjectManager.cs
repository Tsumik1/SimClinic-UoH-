using UnityEngine;
using System.Collections;

public class ObjectManager : MonoBehaviour {
	
	
	public static BasicObject selectedObject;
	
	
	public static void SetSelectedObject(BasicObject selected)
	{
		selectedObject = selected as BasicObject;
	}
	
	
	public static BasicObject GetSelectedObject()
	{
		return selectedObject;
	}
	
	public static int numberOfItems()
	{
		int total = 0; 
		foreach(BasicObject item in FindObjectsOfType(typeof(BasicObject)))
		{
			total++; 
		}
		return total;
	}
	
	public static int numberOfDegradableItems()
	{
		int total = 0 ; 
		foreach(BasicObject item in FindObjectsOfType(typeof(BasicObject)))
		{
			if(item.degradable)
			{
				total++; 
			}
		}
		return total;
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
