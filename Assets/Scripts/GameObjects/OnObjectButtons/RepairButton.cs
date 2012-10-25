using UnityEngine;
using System.Collections;

public class RepairButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		BasicObject master = transform.parent.parent.GetComponent (typeof(BasicObject)) as BasicObject;
		if(!master.degradable)
		{
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void Clicked()
	{
		
		BasicObject master = transform.parent.parent.GetComponent (typeof(BasicObject)) as BasicObject;
		MoneyManager.money -= master.repairCost; 
		MoneyManager.AddToRepairCost ((double)master.repairCost);
		master.life = master.lifeSpanInDays;
	}
}
