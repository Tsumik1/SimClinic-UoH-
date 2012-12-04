using UnityEngine;
using System.Collections;

public class ReStockableObject : BasicObject {
	
	
	public int stockLevel;
	public int initialStockLevel;
	public int maxStockLevel;
	public int increment;
	public int timeTillNextLevel;
	public double restockCost;
	
	public Transform spawnPoint;
	public GameObject empty; 
	public GameObject full;
	public GameObject inBetween;
	public GameObject current;
	
	// Use this for initialization
	void Start () 
	{
		UpdateGraphic (initialStockLevel);
		timeTillNextLevel = increment; 
		stockLevel = initialStockLevel;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(timeTillNextLevel <= 0)
		{
			timeTillNextLevel = increment; 
			stockLevel--; 
			if(stockLevel < 1 )
			{
				stockLevel = 1;
			}
			Destroy (current.gameObject);
			UpdateGraphic (stockLevel);
		}
	}
	
	public void ReStock()
	{
		stockLevel = maxStockLevel;
		Destroy (current.gameObject);
		UpdateGraphic(stockLevel);
		MoneyManager.money -= restockCost;
	}
	public void SpawnButton()
	{
		Vector3 newPos = transform.position; 
		newPos.x += 0f; 
		newPos.z += 3f; 
		newPos.y -= 0f;
		GameObject restockButton = Instantiate(EffectsManager.restock) as GameObject;
		restockButton.transform.parent = transform; 
	}
	public void UpdateGraphic(int lvl)
	{
		if(current)
		{
			Destroy (current.gameObject);
		}
		switch(lvl)
		{
		case 1: 
			current = Instantiate (empty, spawnPoint.position, spawnPoint.rotation) as GameObject;
			SpawnButton();
			break;
		case 2: 
			current = Instantiate (inBetween,spawnPoint.position, spawnPoint.rotation) as GameObject;
			break;
		case 3: 
			current = Instantiate(inBetween,spawnPoint.position, spawnPoint.rotation) as GameObject;
			break;
		case 4: 
			current = Instantiate(full,spawnPoint.position, spawnPoint.rotation) as GameObject;
			break;
		}
		if(current)
		{
			current.transform.parent = transform;
			Vector3 newPosition = Vector3.zero;
			foreach(Transform child in current.transform)
			{
				child.transform.localPosition = Vector3.zero;
			}
			current.transform.localPosition = Vector3.zero;
			newPosition.z = (GetComponent<BoxCollider>().size.z /2) ;//+ (current.GetComponentInChildren<BoxCollider>().size.y /2);
			current.transform.localPosition = newPosition; 
			print ("HI!");
		}
	}
	
	public string GetLevel()
	{
		string s = ""; 
		switch(stockLevel)
		{
		case 1: 
			s = "Empty";
			break;
		case 2: 
			s = "Low";
			break;
		case 3: 
			s = "Medium";
			break;
		case 4: 
			s = "High";
			break;
		}
		if(s != "")
		{
			return s;
		}
		else
		{
			return "ERROR!";
		}
	}
}
