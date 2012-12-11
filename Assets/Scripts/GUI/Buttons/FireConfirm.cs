using UnityEngine;
using System.Collections;

public class FireConfirm : MonoBehaviour {
	
	
	public Staff s;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void SetStaff(Staff staff)
	{
		s= staff;
	}
	void Clicked()
	{
				GUIManager.popUpSmall = false; 
		GUIManager.popUpMain = false;
		//MoneyManager.money += ObjectManager.GetSelectedObject ().sellValue;
		Destroy(s.gameObject);
		Destroy(transform.parent.gameObject);
	}
}
