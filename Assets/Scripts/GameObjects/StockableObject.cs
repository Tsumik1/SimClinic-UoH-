using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class StockableObject: BasicObject {

	public List<StockObject> spawnableObjects;
	public int capacity;
	public int numberOfItemsStored;
	public int tensCount = 0; 
	public int dopCount = 0; 
	public StorageSpace[] spaces;
	// Use this for initialization
	void Start () 
	{
		spaces = GetComponentsInChildren<StorageSpace>();
		Debug.Log (this.objectName + spaces.Length);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	
	public StorageSpace GetFreeSpace()
	{
		foreach(StorageSpace s in spaces)
		{
			if(s.inUse == false)
			{
				return s;
			}
		}
		return null;
	}
	public List<StockObject> GetItems()
	{
		return spawnableObjects;
	}
}
