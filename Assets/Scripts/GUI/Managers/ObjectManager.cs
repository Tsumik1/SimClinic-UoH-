using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ObjectManager : MonoBehaviour {
	
	
	public List<GameObject> handEquipment;
	
	public static List<GameObject> handheldEquipment;
	
	public static BasicObject selectedObject;
	
	
	public static void SetSelectedObject(BasicObject selected)
	{
		selectedObject = selected as BasicObject;
	}
	public static bool HasShop()
	{
		bool r = false;
		foreach(BasicObject item in FindObjectsOfType(typeof(BasicObject)))
		{
			if(item.shop)
			{
				r = true;
				break;
			}
			else
			{
				r = false;
			}
		}
		return r;
	}
	public static BasicObject GetSelectedObject()
	{
		return selectedObject;
	}
	
	public static void SimulateWearAndTear(int loss)
	{
		foreach(BasicObject item in FindObjectsOfType(typeof(BasicObject)))
		{
			item.TakeLife(loss);
		}
		ReStockableObject[] otherItems = FindObjectsOfType (typeof(ReStockableObject)) as ReStockableObject[];
		foreach(ReStockableObject r in otherItems)
		{
			r.timeTillNextLevel -= loss;
		}
		

	}
	
	public static int GetCapacity()
	{
		StockableObject sel = selectedObject as StockableObject;
		return sel.capacity;
	}
	
	public static int GetPatientCount()
	{
		int t = 0;
		foreach(BasicObject item in FindObjectsOfType(typeof(BasicObject)))
		{
			t += item.patientIncrease;
		}
		return t;
	}
	
	public static StorageSpace GetNextFreeSpace()
	{
		StockableObject sel = selectedObject as StockableObject;
		foreach(StorageSpace s in sel.spaces)
		{
			if(!s.inUse)
			{
				s.inUse = true;
				return s;
			}
		}
		return null;
	}
	
	public static int GetNumberOfItemsStored()
	{
		StockableObject sel = selectedObject as StockableObject;
		return sel.numberOfItemsStored;
	}
	
	public static int numberOfItems()
	{
		int total = 0; 
		foreach(BasicObject item in FindObjectsOfType(typeof(BasicObject)))
		{
			total++; 
		}
		return total;
	}
	
	public static int numberOfDegradableItems()
	{
		int total = 0 ; 
		foreach(BasicObject item in FindObjectsOfType(typeof(BasicObject)))
		{
			if(item.degradable)
			{
				total++; 
			}
		}
		return total;
	}
	
	public static int Count(BasicObject o)
	{
		int i = 0;
		foreach(BasicObject a in FindObjectsOfType(typeof(BasicObject)))
		{
			if(a.objectName == o.objectName)
			{
				i++;
			}
		}
		return i;
	}
	
	// Use this for initialization
	void Awake () 
	{
		handheldEquipment = handEquipment;
	}
	
	// Update is called once per frame
	void Update () 
	{
		handEquipment = handheldEquipment;
	}
	

}
