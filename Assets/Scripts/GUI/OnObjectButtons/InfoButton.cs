using UnityEngine;
using System.Collections;

public class InfoButton : MonoBehaviour {
	
	
	public GameObject popup; 
	
	
	private GameObject pop; 
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
		if(GUIManager.popUpSmall == false)
		{
		  Instantiate (popup);
		  GUIManager.popUpSmall = true;
		}
		Destroy (this);
	}
}
