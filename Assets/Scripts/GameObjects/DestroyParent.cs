using UnityEngine;
using System.Collections;

public class DestroyParent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void Clicked()
	{
		GUIManager.popUpSmall = false; 
		Destroy (transform.parent.gameObject);
	}
}
