using UnityEngine;
using System.Collections;

public class RepairButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Clicked()
	{
		BasicObject master = transform.parent.parent.GetComponent (typeof(BasicObject)) as BasicObject;
		MoneyManager.money -= master.repairCost; 
		master.life = master.lifeSpanInSeconds;
		//HealthBar health = transform.parent.parent.GetComponent(typeof(HealthBar)) as HealthBar; 
		//health.ResetHealthBar ();
	}
}
