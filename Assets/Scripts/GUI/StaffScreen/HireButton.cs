using UnityEngine;
using System.Collections;

public class HireButton : MonoBehaviour {
	
	
	public Staff.Role role; 
	public GameObject practitioner;
	public GameObject receptionist;
	public GameObject gardener;
	public GameObject caretaker;
	public Transform spawnPoint;
	// Use this for initialization
	void Start () 
	{
		GameObject a = GameObject.FindGameObjectWithTag("staffspawn");
		spawnPoint = a.transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void Clicked()
	{
		GameObject newStaff = null;
		switch(role)
		{
		case Staff.Role.practitioner:
			newStaff = practitioner;
			break;
		case Staff.Role.receptionist:
			newStaff = receptionist;
			break;
		case Staff.Role.gardener:
			newStaff = gardener;
			break;
		case Staff.Role.caretaker:
			newStaff = caretaker;
			break; 
		}
		if(newStaff != null)
		{
			Instantiate (newStaff,spawnPoint.position, Quaternion.identity);
		}

		Destroy (this.gameObject);

			
	}	
}
