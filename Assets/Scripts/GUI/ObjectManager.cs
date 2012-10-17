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
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
