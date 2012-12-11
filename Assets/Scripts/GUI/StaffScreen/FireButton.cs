using UnityEngine;
using System.Collections;

public class FireButton : MonoBehaviour {
	
	public Staff staffMember;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void Clicked()
	{
		GameObject o = Instantiate (PopupManager.fireConfirmer) as  GameObject;
		FireConfirm b = GameObject.FindObjectOfType (typeof(FireConfirm)) as FireConfirm;
		b.SetStaff(staffMember);
		Destroy (transform.parent.parent.gameObject);
		//Destroy(staffMember.gameObject);
	}
}
