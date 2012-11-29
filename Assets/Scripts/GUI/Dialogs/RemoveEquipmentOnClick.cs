using UnityEngine;
using System.Collections;

public class RemoveEquipmentOnClick : MonoBehaviour {
	
	public enum Equip
	{
		tens = 0, 
		dop = 1,
	}
	
	public Equip type;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void Clicked()
	{
		if(ObjectManager.GetNumberOfItemsStored() - 1 < 0)
		{
					Vector3 spawnPosition = transform.position; 
			//spawnPosition.z += 1f;
			spawnPosition.y += 0.3f;
			//spawnPosition.x += 0.3f;
			Instantiate(EffectsManager.capacityEmpty,spawnPosition,EffectsManager.capacityEmpty.transform.rotation);
		}
		else
		{
			RemoveEquipment(type);
		}
	}
	
	void RemoveEquipment(Equip t)
	{
		StockableObject current = ObjectManager.GetSelectedObject () as StockableObject;
		bool complete = false; 
		foreach(StorageSpace s in current.spaces)
		{
			foreach(EquipmentObject e in FindObjectsOfType (typeof(EquipmentObject)))
			{
			switch(t)
			{
			case Equip.tens:
				if(e.objectName == ObjectManager.handheldEquipment[0].GetComponent<BasicObject>().objectName && e.ownerPlace == s)
					{
						s.inUse = false;
						MoneyManager.money += e.sellValue;
						current.numberOfItemsStored--;
						current.tensCount--;
						Destroy (e.gameObject);
						complete = true;
						break;
					}
				break;
				case Equip.dop:
				  if(e.objectName == ObjectManager.handheldEquipment[1].GetComponent<BasicObject>().objectName && e.ownerPlace == s)
					{
						s.inUse = false;
						MoneyManager.money += e.sellValue;
						current.numberOfItemsStored--;
						current.dopCount--;
						Destroy (e.gameObject);
						complete = true;
						break;
					}
				break; 
			}
			}
			if(complete)
				break;
		}
	}

}
