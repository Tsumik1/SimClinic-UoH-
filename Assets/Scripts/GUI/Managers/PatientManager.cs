using UnityEngine;
using System.Collections;
using System.Collections.Generic;
	[SerializeAll]
public class PatientManager : MonoBehaviour {

	public int initialSatisfaction;
	
	public static int patientSatisfaction = 50; //Out of 100, dictates patient satisfaction and quality of treatment. If this number falls below 20 the clinic is in trouble!
	public static int numberOfPatients = 0; 
	public static int monthlyPatients = 0; 
	public static int yearlyPatients = 0;
	public static int allTimePatients = 0; 
	public static int unsuccessfulPatients = 0; 
	public static int numberOfPatientsWaitingToBeSeen = 0;
	public static int patientsInClinic = 0;
	public static int happyPatients = 0; 
	public static int[] patientsSeenPerMonth;
	public static Patient[] patients;
	public static List<Patient> waitingPatients;
	
	public static int GetPatientSatisfaction()
	{
		return patientSatisfaction;
	}
	
	public static int GetMonthlyPatients()
	{
		int m = 0;
		m += ObjectManager.GetPatientCount(); 
		m += StaffManager.GetPatientCount();
		return m;
	}
	
	public static void SimulateMonth()
	{
		float temp = Random.Range(0, (float)GetMonthlyPatients());
		allTimePatients += (int)temp; 
		float hap = Random.Range(1,temp);
		int un = (int)temp - (int)hap;
		happyPatients += (int)hap;
		unsuccessfulPatients += un;
	}
	
	public static void SimulateDay()
	{
		float temp = Random.Range (0, (float)GetMonthlyPatients ()/28);
		allTimePatients += (int)temp;
		float hap = Random.Range (1,temp);
		int un = (int)temp - (int)hap;
		happyPatients+= (int)hap;
		unsuccessfulPatients += un;
	}
	
	public static void AddPatient()
	{
		monthlyPatients++;
		yearlyPatients++;
		allTimePatients++;
	}
	public static void IncreaseInClinicCount()
	{
		patientsInClinic++;
	}
	public static void DecreaseInClinicCount()
	{
		patientsInClinic--;
	}
	
	public static void IncreasePatientSatisfaction(int value)
	{
		patientSatisfaction += value;
	}
	
	public static void DestroyPatients()
	{
		foreach(Patient pat in FindObjectsOfType(typeof(Patient)))
		{
			pat.ForceComplete();
			Destroy (pat.gameObject);
		}
	}
	
	public static void DecreasePatientSatisfaction(int value)
	{
		patientSatisfaction -= value; 
	}
	// Use this for initialization
	void Start () 
	{
		patientSatisfaction = initialSatisfaction; //depends on difficulty :). 
		waitingPatients = new List<Patient>();
		numberOfPatientsWaitingToBeSeen = 0;
		patientsSeenPerMonth = new int[12];
	}
	
	public static void AddPatientTotal(int month)
	{
		if(month < 12 && month >= 0)
		{
			patientsSeenPerMonth[month] = GetMonthlyPatients();
		}
	}
	public static void AddRemovePatient()
	{
		patients = FindObjectsOfType(typeof(Patient)) as Patient[];
	}
	public static void AddPatientToQueue()
	{
		
	}
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	
	public static bool PatientsWaiting()
	{
		if(waitingPatients.Count > 0)
			return true;
		else
			return false;
	}
	
	public static void MinutePassed()
	{
		foreach(Patient patient in FindObjectsOfType(typeof(Patient)))
		{
			patient.MinutePassed ();
			
		}
	}
	
	public static Patient GetNextWaiting()
	{
		return waitingPatients[waitingPatients.Count - 1];
	}
	public static void AddPatientToWaiting(Patient pat)
	{
		waitingPatients.Add (pat);
		numberOfPatientsWaitingToBeSeen = waitingPatients.Count;
	}
	
	public static void RemovePatientFromWaiting(Patient pat)
	{
		waitingPatients.Remove(pat);
		numberOfPatientsWaitingToBeSeen = waitingPatients.Count;
	}
	
	public static void AllGoHome()
	{
		foreach(Patient pat in FindObjectsOfType(typeof(Patient)))
		{
			pat.GoHome(RandomMessages.GetHomeMessage());
		}
	}
}
