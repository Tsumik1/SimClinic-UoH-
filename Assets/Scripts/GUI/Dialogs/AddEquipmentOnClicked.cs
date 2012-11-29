using UnityEngine;
using System.Collections;

public class AddEquipmentOnClicked : MonoBehaviour {
	
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
		if(ObjectManager.GetNumberOfItemsStored() + 1 > ObjectManager.GetCapacity())
		{
			Vector3 spawnPosition = transform.position; 
			//spawnPosition.z += 1f;
			spawnPosition.y += 0.3f;
			//spawnPosition.x += 0.3f;
			Instantiate(EffectsManager.capacityFull, spawnPosition,EffectsManager.capacityFull.transform.rotation);
		}
		else
		{
			AddEquipment(type);
		}
	}
	
	void AddEquipment(Equip t)
	{
		StockableObject current = ObjectManager.GetSelectedObject () as StockableObject;
		GameObject toSpawn = null;
		StorageSpace nextFreeSpace = ObjectManager.GetNextFreeSpace();
		Vector3 spawnSpace = nextFreeSpace.transform.position;
		switch(t)
		{
			case Equip.tens:
				toSpawn = ObjectManager.handheldEquipment[0];
				current.tensCount++;
				break;
			case Equip.dop:
				toSpawn = ObjectManager.handheldEquipment[1];
				current.dopCount++;
				break;
			default:
				Debug.LogError ("Nothing to add, button not assigned correct type.");
				break;
		}
		if(toSpawn != null)
		{
			toSpawn.GetComponent<EquipmentObject>().SetOwnerPlace (nextFreeSpace);
			Instantiate(toSpawn,spawnSpace, Quaternion.identity);
			current.numberOfItemsStored++;
		}
	}
}
