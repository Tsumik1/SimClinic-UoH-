using UnityEngine;
using System.Collections;

[SerializeAll]
public class Spawner2 : MonoBehaviourEx {
	
	
	public GameObject patient; 
	public Transform position; 
	
	public static GameObject defaultPatient;
	public static Transform spawnPosition;
	// Use this for initialization
	void Start () 
	{
		defaultPatient = patient;
		spawnPosition = position;
	}
	
	void Update()
	{
		
	}
	public static void SpawnPatient()
	{
		Instantiate (defaultPatient, spawnPosition.position, Quaternion.identity);
		PatientManager.AddRemovePatient();
	}
	
}
