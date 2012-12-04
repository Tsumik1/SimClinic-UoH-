using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;
using Serialization;
using System.Net;

public class SaveAndReload : MonoBehaviour {
	
	// Use this for initialization
	void OnMouseDown()
	{
//		var data = JSONLevelSerializer.SaveObjectTree(gameObject);
		JSONLevelSerializer.SaveObjectTreeToServer("ftp://whydoidoit.net/Downloads/SavedData.json", gameObject, "whydoidoit", "W!ll14m1", (error)=>{
			Debug.Log("Uploaded!");
		});
		//data.WriteToFile("test_json.txt");
		Destroy(gameObject);
		Loom.QueueOnMainThread(()=>{
			JSONLevelSerializer.LoadObjectTreeFromServer("http://whydoidoit.net/Downloads/SavedData.json");
		},6f);
	}
	
	
}
