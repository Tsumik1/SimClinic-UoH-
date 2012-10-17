using UnityEngine;
using System.Collections;

public class ObjectSelect : MonoBehaviour {
	
	
	public GameObject[] objectIcons;
	public GameObject[] objects;
	public int[] objectCosts;
	
	public float iconRotateRate =1.0f; 
	
	private int selectedObject = 0; 
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//objectIcons[selectedObject].transform.Rotate (Vector3.up, iconRotateRate * Time.deltaTime);
	}
	
	
	public int GetSelectedObjectCost()
	{
		return 10;
		//return objectCosts[selectedObject];
	}

	public GameObject GetSelectedObject()
	{
		return objects[selectedObject];
	}
	void SetSelectedObject(GameObject inputObject)
	{
		int index = 0 ; 
		foreach(GameObject objectItem in objectIcons)
		{
			if(inputObject == objectItem)
			{
				selectedObject = index; 
			}
			index++;
		}
	}
}