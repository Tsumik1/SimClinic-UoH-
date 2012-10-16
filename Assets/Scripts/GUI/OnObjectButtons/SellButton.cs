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
		BasicObject master = transform.parent.parent.GetComponent (typeof(BasicObject)) as BasicObject;
		MoneyManager.money += master.sellValue;
		Destroy(transform.parent.parent.gameObject);
	}
}
