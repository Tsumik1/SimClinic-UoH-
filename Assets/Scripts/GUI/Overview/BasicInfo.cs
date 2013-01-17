using UnityEngine;
using System.Collections;

public class BasicInfo : MonoBehaviour {
	
	public TextMesh nameDisplay;
	public TextMesh clinicNameDisplay; 
	public TextMesh openDate; 
	
	public string name;
	public string cName; 
	// Use this for initialization
	void Start () 
	{
		name = PlayerPrefs.GetString ("PlayerName");
		cName = PlayerPrefs.GetString ("ClinicName");
	}
	
	// Update is called once per frame
	void Update () 
	{
		nameDisplay.text = name;
		clinicNameDisplay.text = cName; 
	}
}
