using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {
	
	
	public enum PopulationDensity
	{
		high,
		med,
		low
	}
	
	public PopulationDensity populationDensity; // This dictates how frequently the clinic is likely to have patients, the higher the better.
	public string buildingName; 
	public int buildingNumber; 
	public int numberOfRooms; 
	public float deposit;
	public float monthlyCost; 
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public Building GetBuilding()
	{
		return this;
	}
}
