using UnityEngine;
using System.Collections;

public class GetQualityLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		int qualityLevel = QualitySettings.GetQualityLevel();
		string text = ""; 
		switch(qualityLevel)
		{
		case 0:
			text = "Lowest";
			break;
		case 1: 
			text = "Low";
			break;
		case 2: 
			text = "Standard";
			break;
		case 3: 
			text = "High";
			break;
		case 4:
			text = "Higher";
			break;
		case 5: 
			text = "Highest";
			break;
		}
		GetComponent<TextMesh>().text = text;
	}
}
