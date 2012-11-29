using UnityEngine;
using System.Collections;

public class EquipmentPopup : MonoBehaviour {

	
	
	public int tensCount; 
	public int dopCount; 
	
	public GameObject tensCountDisplay;
	public GameObject dopCountDisplay;
	public GameObject nameDisplay;
	public GameObject descriptionDisplay;
	public GameObject sellValueDisplay;
	public GameObject capacityDisplay;
	
	private GameObject tensUnit; 
	private GameObject doppler; 
	
	private StockableObject current;
	// Use this for initialization
	void Start () 
	{
		tensUnit = ObjectManager.handheldEquipment[0];
		doppler = ObjectManager.handheldEquipment[1];
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		current = ObjectManager.GetSelectedObject() as StockableObject;
		if(current)
		{	
			string description = current.objectDescription;
			nameDisplay.GetComponent<TextMesh>().text = current.objectName;
			descriptionDisplay.GetComponent<TextMesh>().text = description;
			capacityDisplay.GetComponent<TextMesh>().text = current.numberOfItemsStored + " / " + ObjectManager.GetCapacity().ToString();
			sellValueDisplay.GetComponent<TextMesh>().text = current.sellValue.ToString ("f0");
			SendMessage ("FormatString", description);
			tensCountDisplay.GetComponent<TextMesh>().text = current.tensCount.ToString() + " / " + tensCount.ToString ();
			dopCountDisplay.GetComponent<TextMesh>().text = current.dopCount.ToString () + " / " + dopCount.ToString();
		}

		
		
		tensCount = ObjectManager.Count(tensUnit.GetComponent<BasicObject>());
		dopCount = ObjectManager.Count (doppler.GetComponent<BasicObject>());

		
		
	}
}
