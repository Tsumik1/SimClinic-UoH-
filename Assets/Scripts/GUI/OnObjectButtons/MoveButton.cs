using UnityEngine;
using System.Collections;

public class MoveButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void Clicked()
	{
		BasicObject master = transform.parent.parent.GetComponent (typeof(BasicObject)) as BasicObject;
		master.isOn = false; 
		ObjectPlacement movement = transform.parent.parent.GetComponent (typeof(ObjectPlacement)) as ObjectPlacement;

		movement.enabled = true;
		movement.MoveAgain ();
		
		Destroy(transform.parent.gameObject);
		
	}
}
