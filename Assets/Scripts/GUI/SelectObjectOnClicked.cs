using UnityEngine;
using System.Collections;

public class SelectObjectOnClicked : MonoBehaviour {

	
	public GameObject objectSelector; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Clicked()
	{
		objectSelector.SendMessage ("SetSelectedObject",gameObject);
		//print (gameObject.name);
	}
	
	
}
