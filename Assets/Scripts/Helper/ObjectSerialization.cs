using UnityEngine;
using System.Collections;
using System;

public class ObjectSerialization : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Clicked()
	{
		BasicObject b = FindObjectOfType (typeof(BasicObject)) as BasicObject;
		GameObject a = b.gameObject; 
		System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(a.GetType());
		x.Serialize (Console.Out,a);
		Console.WriteLine ();
	}
}
