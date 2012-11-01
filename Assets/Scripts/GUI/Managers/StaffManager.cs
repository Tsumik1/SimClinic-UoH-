using UnityEngine;
using System.Collections;

public class StaffManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void UpdateStaffActions()
	{
		foreach(Staff staff in FindObjectsOfType(typeof(Staff)))
		{
			staff.hoursUntilNextAction--;
		}
	}
}
