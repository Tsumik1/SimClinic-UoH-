using UnityEngine;
using System.Collections;

public class Save : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
	
	void Clicked()
	{
		LevelSerializer.SaveGame ("saveOne");
		print ("Saving...");
	}
}