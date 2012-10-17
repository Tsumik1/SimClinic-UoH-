using UnityEngine;
using System.Collections;

public class InfoButton : MonoBehaviour {
	
	
	public GameObject popup; 
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Clicked()
	{
		ObjectManager.selectedObject.DisableHealth ();
		ObjectManager.selectedObject.DisableButtons();
		Instantiate (popup);
		Destroy (this);
	}
}
