using UnityEngine;
using System.Collections;

public class Popup : MonoBehaviour {

	
	private BasicObject current; 
	public GameObject nameDisplay;
	public GameObject descriptionDisplay;
	public GameObject lifeDisplay;
	public GameObject sellValueDisplay;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		current = ObjectManager.GetSelectedObject();
		if(current)
		{	
			string description = current.objectDescription;
			nameDisplay.GetComponent<TextMesh>().text = current.objectName;
			descriptionDisplay.GetComponent<TextMesh>().text = description;
			if(current.degradable)
			{
			lifeDisplay.GetComponent<TextMesh>().text = current.life.ToString ("f0");
				
			}
			else
			{
			lifeDisplay.GetComponent<TextMesh>().text = "N/A";
				
			}
			sellValueDisplay.GetComponent<TextMesh>().text = current.sellValue.ToString ("f0");
			
						SendMessage ("FormatString", description);
		}

	}
}
