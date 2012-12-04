using UnityEngine;
using System.Collections;

public class Load : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Clicked()
	{
		LevelSerializer.LoadNow ("saveOne");
		print ("Saving...");
	}
}
