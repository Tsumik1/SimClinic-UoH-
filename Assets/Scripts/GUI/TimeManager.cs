using UnityEngine;
using System.Collections;
using System;

public class TimeManager : MonoBehaviour 
{
	public GameObject timeDisplay; 
	public GameObject dateDisplay;
	public float timeSpeed = 1f; 
	
	public static DateTime currentDate;
	public static DateTime endDate;
	
	public int currentMonth; 
	
	private int month; 
	// Use this for initialization
	void Start () 
	{
		//Will use playerprefs here to sort this out but for testing purposes. 
		
		currentDate = new DateTime(2012,10,18);
		endDate = new DateTime(2012,10,20);
		Time.timeScale = timeSpeed; 
		month = currentDate.Month;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Time.timeScale = timeSpeed;
		currentDate = currentDate.AddSeconds(Time.deltaTime);
		
		if (currentMonth > month|| currentMonth == 1 && month == 12)
		{
			PerformMonthlyActions();
			month = currentMonth;
		}
		currentMonth = currentDate.Month;
		
		timeDisplay.GetComponent<TextMesh>().text = currentDate.ToString();
	}
	
	public static void AddMonth()
	{
		currentDate = currentDate.AddMonths (1);
	}
	
	public static void PerformMonthlyActions()
	{
		DeductCosts();
	}
	
	private static void DeductCosts()
	{
		//print ("hellow :P");
		BasicObject[] objects = FindObjectsOfType(typeof(BasicObject)) as BasicObject[];
		
		foreach(BasicObject item in objects)
		{
			print(item);
			MoneyManager.money -= item.costPerMonth;
		}
	}
}
