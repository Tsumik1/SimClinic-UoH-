using UnityEngine;
using System.Collections;

public class SellConfirm : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void Clicked()
	{
		GUIManager.popUpSmall = false; 
		GUIManager.popUpMain = false;
		MoneyManager.money += ObjectManager.GetSelectedObject ().sellValue;
		Destroy(ObjectManager.GetSelectedObject().gameObject);
		Destroy(transform.parent.gameObject);
	}
}
