using UnityEngine;
using System.Collections;

public class Patients : MonoBehaviour {
	
	
	
	public TextMesh patientsInClinic;
	public TextMesh patientsThisMonth;
	public TextMesh patientsThisYear;
	public TextMesh patientsAllTime;
	public TextMesh unsatisfiedPatients;
	public TextMesh satisfiedPatients; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		patientsInClinic.text = PatientManager.patientsInClinic.ToString();
		patientsThisMonth.text = PatientManager.monthlyPatients.ToString();
		patientsThisYear.text = PatientManager.yearlyPatients.ToString ();
		patientsAllTime.text = PatientManager.allTimePatients.ToString();
		unsatisfiedPatients.text = PatientManager.unsuccessfulPatients.ToString();
		satisfiedPatients.text = PatientManager.happyPatients.ToString();
	}
}
