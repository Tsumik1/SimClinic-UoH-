using UnityEngine;
using System.Collections;

public class DefaultTab : MonoBehaviour {

	public Material downMaterial; 
	// Use this for initialization
	void Start () 
	{
			Tab[] tabs = FindObjectsOfType(typeof(Tab)) as Tab[];
			foreach(Tab tab in tabs)
			{
			if(tab.isDefault)
			{	
				tab.selectedMaterial = downMaterial;
				tab.EnableContent ();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
