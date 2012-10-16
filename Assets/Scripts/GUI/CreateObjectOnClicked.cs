using UnityEngine;
using System.Collections;

public class CreateObjectOnClicked : MonoBehaviour {

	public ObjectSelect objectSelector;
	public Transform spawnNode; 
	void Clicked(Vector3 position)
	{
		if(MoneyManager.money >= objectSelector.GetSelectedObjectCost())
		{
					GameObject item = objectSelector.GetSelectedObject();
									BasicObject[] generalObjects = FindObjectsOfType (typeof(BasicObject)) as BasicObject[];
							for(int i = 0; i< generalObjects.Length;i++)
				{
					generalObjects[i].DisableButtons ();	
					generalObjects[i].selected = false;
				}
			GameObject newObject = Instantiate (item, spawnNode.position + Vector3.up, item.transform.rotation) as GameObject;

			
			BasicObject newItem = newObject.GetComponent (typeof(BasicObject)) as BasicObject; 
			MoneyManager.money -= newItem.cost;
		}

	}
}
