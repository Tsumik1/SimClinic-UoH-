using UnityEngine;
using System.Collections;

public class ConfirmBuildingButton : MonoBehaviour {
	
	
	public TextMesh availableCashDisplay; 
	
	
	private float availableCash; 
	// Use this for initialization
	void Start ()
	{
		availableCash = PlayerPrefs.GetFloat ("AvailableCash");
		availableCashDisplay.text = availableCash.ToString ("f0");
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void Clicked()
	{
		string levelToLoad = ""; 
		int buildingNumber = 0;
		switch(CameraWaypointManager.GetWaypointNumber())
		{
		case 0: 
			buildingNumber = 0; 
			levelToLoad = "BasicBuilding";
			break;
		case 1: 
			buildingNumber = 1;
			levelToLoad = "StandardBuilding";
			break;
		case 2: 
			buildingNumber = 2;
			levelToLoad = "gunnagetmessy";
			break; 
		}
		foreach(Building b in FindObjectsOfType(typeof(Building)))
		{
			if(buildingNumber == b.buildingNumber)
			{
				availableCash -= b.deposit;
			}
		}
		PlayerPrefs.SetInt ("BuildingNumber",buildingNumber);
		PlayerPrefs.SetFloat ("AvailableCash", availableCash);
		PlayerPrefs.Save ();
		Application.LoadLevel(levelToLoad);
	}
}
