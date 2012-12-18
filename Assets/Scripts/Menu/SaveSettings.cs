using UnityEngine;
using System.Collections;

public class SaveSettings : MonoBehaviour {
	
	
	public int qualityLevel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Clicked()
	{
		qualityLevel = QualitySettings.GetQualityLevel();
		QualitySettings.SetQualityLevel(qualityLevel,true);
	}
}
