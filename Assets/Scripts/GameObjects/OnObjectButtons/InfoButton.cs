using UnityEngine;
using System.Collections;

public class InfoButton : MonoBehaviour {
	
	
	public bool info;
	public bool finance;
	
	
	private GameObject pop; 
	// Use this for initialization
	void Start () 
	{
		pop = PopupManager.infoPopper;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Clicked()
	{
		if(finance && GUIManager.popUpSmall == false)
		{
			Instantiate (PopupManager.financePopup);
					  GUIManager.popUpSmall = true;
		}
		if(info && GUIManager.popUpSmall == false)
		{
			Instantiate(PopupManager.overPopup);
					  GUIManager.popUpSmall = true;
		}
		if(!finance && !info)
		{
		if(ObjectManager.selectedObject)
			
		{ObjectManager.selectedObject.DisableHealth ();
		ObjectManager.selectedObject.DisableButtons();}
		if(GUIManager.popUpSmall == false)
		{
		  if(ObjectManager.selectedObject.stockable)
			{
				Instantiate (PopupManager.stockPopup);
			}
			else
			{
		 	 Instantiate (pop);	
			}
		  GUIManager.popUpSmall = true;
		}
		}
	}
}
