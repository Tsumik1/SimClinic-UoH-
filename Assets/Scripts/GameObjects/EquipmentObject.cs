using UnityEngine;
using System.Collections;

public class EquipmentObject : BasicObject {
	
	public StorageSpace ownerPlace = null; 
	
	void Start()
	{
		base.EnableObject();
	}
	void Clicked()
	{
		//DoNothing;
	}
	
	public void SetOwnerPlace(StorageSpace place)
	{
		ownerPlace = place;
	}
}
