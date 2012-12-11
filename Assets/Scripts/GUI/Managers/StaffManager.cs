using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StaffManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	public static bool StaffHired(Staff.Role role)
	{
		bool b = false;
		foreach(Staff staff in FindObjectsOfType(typeof(Staff)))
		{
			if(staff.role == role)
			{
				b = true; 
				break; 
			}
			else
			{
				b  = false; 
			}
		}
		return b;
	}
	public static Staff GetStaff(Staff.Role role)
	{
		foreach(Staff staff in FindObjectsOfType(typeof(Staff)))
		{
			if(staff.role == role)
			{
				return staff;
			}			
		}
		return null;
	}
	public static void UpdateStaffTimeToNextWaypoint()
	{
		foreach(Staff staff in FindObjectsOfType(typeof(Staff)))
		{
			staff.MinutePassed();
		}
	}
	public static void UpdateStaffActions()
	{
		foreach(Staff staff in FindObjectsOfType(typeof(Staff)))
		{
			staff.HourPassed();
		}
	}
	
	public static int GetPatientCount()
	{
		int t = 0; 
				foreach(Staff staff in FindObjectsOfType(typeof(Staff)))
		{
			t+= staff.patientIncrease;
		}
		return t;
	}
	public static void ResetStaff()
	{
		foreach(Staff staff in FindObjectsOfType(typeof(Staff)))
		{
			staff.Reset();
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
	
	public static bool CheckForReceptionist()
	{
		bool r = false; 
		foreach(Staff staff in FindObjectsOfType(typeof(Staff)))
		{
			if(staff.role == Staff.Role.receptionist)
				r = true;
			else
				r = false;
		}
		return r; 
	}
	
	public static bool CheckForStaff(Staff.Role role)
	{
		bool r = false; 
		foreach(Staff staff in FindObjectsOfType(typeof(Staff)))
		{
			if(staff.role == role)
			{	
				r = true;
				break;
			}
			else
				r = false;
		}
		return r; 
	}
	
	public static Staff GetReceptionist()
	{
		Staff s = null; 
				foreach(Staff staff in FindObjectsOfType(typeof(Staff)))
		{
			if(staff.role == Staff.Role.receptionist)
			{
				s = staff;
				break;
			}
			else
			s = null;
		}
		return s;
	}
	
	public static int GetReceptionBookingTime()
	{
		int t = 0; 
		foreach(Staff staff in FindObjectsOfType(typeof(Staff)))
		{
			if(staff.role == Staff.Role.receptionist)
			{
				t = staff.bookingTime;
				break;
			}
			else
				t = 0;
		}
		return t;
	}
	public static bool AvailablePractictioner()
	{
		bool r = false; 
		foreach(Staff staff in FindObjectsOfType(typeof(Staff)))
		{
			if(staff.role == Staff.Role.practitioner)
			{
				if(staff.state == Staff.State.waitingAtDesk)
				{
					r = true;
				}
			}
			else
				r = false;
		}
		return r; 
	}
	public static Staff AssignPractitioner()
	{
		List<Staff> avaiable = new List<Staff>();
		Staff s = null; 
		foreach(Staff staff in FindObjectsOfType(typeof(Staff)))
		{
			if(staff.role == Staff.Role.practitioner)
			{
					avaiable.Add (staff);
					//s = staff;
					break;	
			}
			else
				s = null;
		}
		if(avaiable.Count > 0)
		{
			int randomNumber = Random.Range (0,avaiable.Count-1);
			s = avaiable[randomNumber];
		}
		return s;
	}
	public static int GetPracticeWaitingTime(Staff staff)
	{
		int i = 0; 
		
		
		return i;
	}
	public static Staff GetAvailablePractitioner()
	{
		List<Staff> avaiable = new List<Staff>();
		Staff s = null; 
		foreach(Staff staff in FindObjectsOfType(typeof(Staff)))
		{
			if(staff.role == Staff.Role.practitioner)
			{
				if(staff.state == Staff.State.waitingAtDesk)
				{
					avaiable.Add (staff);
					//s = staff;
					break;	
				}
			}
			else
				s = null;
		}
		if(avaiable.Count > 0)
		{
			int randomNumber = Random.Range (0,avaiable.Count-1);
			s = avaiable[randomNumber];
		}
		return s;
	}
}
