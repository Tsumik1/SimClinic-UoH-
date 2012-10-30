using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class DegradableManager : MonoBehaviour {
	
	public BasicObject[] basicObjects;
	public static List<BasicObject> degradableObjects;
	// Use this for initialization
	void Start ()
	{
		degradableObjects = new List<BasicObject>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		basicObjects =FindObjectsOfType(typeof(BasicObject)) as BasicObject[];
		
		foreach(BasicObject o in basicObjects)
		{
			if(o.degradable && !degradableObjects.Contains(o))
			{
				degradableObjects.Add(o);
			}
		}
	}
	
	public static void Remove(BasicObject g)
	{
		degradableObjects.Remove(g);
	}
	
	public static List<BasicObject> GetList()
	{
		return degradableObjects;
	}
}
