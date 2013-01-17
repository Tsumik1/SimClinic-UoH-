using UnityEngine;
using System.Collections;

public class BuildingSelectPopup : MonoBehaviour {
	
	public TextMesh nameLabel; 
	public TextMesh densityLabel; 
	public TextMesh roomLabel;
	public TextMesh depositLabel;
	public TextMesh costLabel;
	public Building currentBuilding; 
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		foreach(Building b in FindObjectsOfType(typeof(Building)))
		{
			if(b.buildingNumber == CameraWaypointManager.GetWaypointNumber())
			{
				currentBuilding = b; 
			}
		}
		if(currentBuilding)
		{
			nameLabel.text = currentBuilding.buildingName;
			densityLabel.text = currentBuilding.populationDensity.ToString ();
			roomLabel.text = currentBuilding.numberOfRooms.ToString();
			depositLabel.text = currentBuilding.deposit.ToString();
			costLabel.text = currentBuilding.monthlyCost.ToString ();
		}
	}
}
