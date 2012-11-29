using UnityEngine;
using System.Collections;

public class SellButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Clicked()
	{
		if(ObjectManager.selectedObject)
			
		{ObjectManager.selectedObject.DisableHealth ();
		ObjectManager.selectedObject.DisableButtons();}
		if(GUIManager.popUpSmall == false)
		{
			Instantiate(PopupManager.sellConfirmer);
		  GUIManager.popUpSmall = true;
		}

		//Destroy(transform.parent.parent.gameObject);
	}
}
