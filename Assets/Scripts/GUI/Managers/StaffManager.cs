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
	
	public static void UpdateStaffActions()
	{
		foreach(Staff staff in FindObjectsOfType(typeof(Staff)))
		{
			staff.HourPassed();
		}
	}
	
	public static void GoHome()
	{
		foreach(Staff staff in FindObjectsOfType(typeof(Staff)))
		{
			staff.GoHome();
		}
	}
	
	public static void StartWork()
	{
		foreach(Staff staff in FindObjectsOfType(typeof(Staff)))
		{
			staff.StartWork();
		}
	}
	
	public static int StaffWage()
	{
		int total = 0; 
		foreach(Staff staff in FindObjectsOfType(typeof(Staff)))
		{
			total += staff.salary;
		}
		return total;
	}
}
