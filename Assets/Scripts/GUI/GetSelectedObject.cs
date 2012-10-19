using UnityEngine;
using System.Collections;

public class GetSelectedObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		
		BasicObject[] objects = FindObjectsOfType (typeof(BasicObject)) as BasicObject[];
		
			for(int i = 0; i< objects.Length;i++)
			{
				if(objects[i].GetSelected())
				{
					//transform.GetComponent (MeshFilter).mesh = towers[i].GetComponent (MeshFilter).mesh;
					MeshFilter current = GetComponent (typeof(MeshFilter)) as MeshFilter; 
					MeshFilter replacement = objects[i].GetComponent (typeof(MeshFilter)) as MeshFilter; 
					current.mesh = replacement.mesh; 
					Vector3 newScale = new Vector3(0.09f,0.09f,0.09f);
					transform.localScale = newScale; 
				Vector3 newRotation = new Vector3(0f,90f,0f);
					transform.eulerAngles = newRotation;
					transform.renderer.material = objects[i].renderer.material; 
				}
			}
	}
}
