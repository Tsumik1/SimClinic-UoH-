using UnityEngine;
using System.Collections;
using System;

public class TimeManager : MonoBehaviour 
{
	public GameObject timeDisplay; 
	public GameObject dateDisplay;
	public float timeSpeed = 1f; 
	
	public DateTime startDate;
	public static DateTime endDate;
	// Use this for initialization
	void Start () 
	{
		//Will use playerprefs here to sort this out but for testing purposes. 
		
		startDate = new DateTime(2012,10,18);
		endDate = new DateTime(2012,10,20);
		Time.timeScale = timeSpeed; 
	}
	
	// Update is called once per frame
	void Update () 
	{
		Time.timeScale = timeSpeed;
		startDate = startDate.AddSeconds(Time.deltaTime);
		timeDisplay.GetComponent<TextMesh>().text = startDate.ToString();
	}
}
