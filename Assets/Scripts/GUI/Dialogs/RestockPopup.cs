using UnityEngine;
using System.Collections;

public class RestockPopup : MonoBehaviour {
		public GameObject nameDisplay;
	public GameObject descriptionDisplay;
	public GameObject sellValueDisplay;
	public GameObject stockLevelDisplay;
	
	
		private ReStockableObject current;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
			current = ObjectManager.GetSelectedObject() as ReStockableObject;
		if(current)
		{	
			string description = current.objectDescription;
			nameDisplay.GetComponent<TextMesh>().text = current.objectName;
			descriptionDisplay.GetComponent<TextMesh>().text = description;
			sellValueDisplay.GetComponent<TextMesh>().text = current.sellValue.ToString ("f0");
			stockLevelDisplay.GetComponent<TextMesh>().text = current.GetLevel();
			SendMessage ("FormatString", description);
		}
	}
}
