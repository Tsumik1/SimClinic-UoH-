using UnityEngine;
using System.Collections;

public class PatientManager : MonoBehaviour {
	
	public int initialSatisfaction;
	
	static int patientSatisfaction; //Out of 100, dictates patient satisfaction and quality of treatment. If this number falls below 20 the clinic is in trouble!
	static int numberOfPatients; 
	
	
	
	public static int GetPatientSatisfaction()
	{
		return patientSatisfaction;
	}
	
	public static void IncreasePatientSatisfaction(int value)
	{
		patientSatisfaction += value;
	}
	
	public static void DecreasePatientSatisfaction(int value)
	{
		patientSatisfaction -= value; 
	}
	// Use this for initialization
	void Start () 
	{
		patientSatisfaction = initialSatisfaction; //depends on difficulty :). 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
