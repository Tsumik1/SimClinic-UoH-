using UnityEngine;
using System.Collections;

public class Confirm : MonoBehaviour {
	
	
		private BasicObject current; 
		public TextMesh val;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		current = ObjectManager.GetSelectedObject();
		val.text = current.sellValue.ToString ();;
	}
	
	
	
}
