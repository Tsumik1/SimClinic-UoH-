using UnityEngine;
using System.Collections;

public class CreateObjectOnClicked : MonoBehaviour {

	public ObjectSelect objectSelector;
	public Transform spawnNode; 
	
	void Clicked(Vector3 position)
	{
	if(!ObjectPlacementManager.placing)
		{
				ObjectPlacementManager.placing = true; 
					GameObject item = objectSelector.GetSelectedObject();
									BasicObject[] generalObjects = FindObjectsOfType (typeof(BasicObject)) as BasicObject[];
							for(int i = 0; i< generalObjects.Length;i++)
				{
					generalObjects[i].DisableButtons ();	
					generalObjects[i].DisableHealth ();
					generalObjects[i].selected = false;
				}
			
			
				Vector3 spawnLocation = new Vector3(spawnNode.position.x, spawnNode.position.y + item.collider.transform.lossyScale.z/2, spawnNode.position.z);
				print (spawnLocation.y);
				GameObject newObject = Instantiate (item, spawnLocation, item.transform.rotation) as GameObject;
				BasicObject newItem = newObject.GetComponent (typeof(BasicObject)) as BasicObject; 
			
				if(MoneyManager.Purchase(newItem.cost))
				{
					
				}
				else
			{
				Destroy (newObject);
			}
			}

	}
}
