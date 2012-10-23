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
	
	public static int currentMonth; 
	public static Day currentDay; 
	
	//private int month; 
	// Use this for initialization
	void Start () 
	{
		//Will use playerprefs here to sort this out but for testing purposes...
		
		currentDate = new DateTime(2012,10,18);
		endDate = new DateTime(2012,10,20);
		Time.timeScale = timeSpeed; 
		//month = currentDate.Month;
		currentMonth = currentDate.Month; 
		currentDay = new Day();
		currentDay.day = currentDate.Day;
	}
	
	public class Day
	{
		//Simple class to help manage days. 
		public int day; 
		public bool endOfMonth;  
		
		
		public Day()
		{
			day = 0;
			endOfMonth = false; 
		}
		
		//checks if it's the end of the month. 
		public bool isEndOfMonth(int month)
		{
			bool result = false; 
			
			switch(month)
			{
			case 1:
				if(day == 31)
					result = true;
					break;
			case 2: 
				if(day == 28)
					result  =  true;
					break;
				
			case 3: 
				if(day == 31)
					result  =  true;
					break;
			case 4: 
				if(day == 30)
					result  =  true;
					break;
				
			case 5: 
				if(day == 31)
					result  =  true;
					break;
			case 6: 
				if(day == 30)
					result  =  true; 
					break;
			case 7: 
				if(day == 31)
					result  =  true; 
				break;
			case 8: 
				if(day == 31)
					result  =  true;
					break;
			case 9:
				if(day == 30)
					result  =  true;
					break;
			case 10:
				if(day == 31)
					result  =  true;
					break;
			case 11: 
				if(day == 30)
					result  =  true;
					break;
			case 12: 
				if(day == 31)
					result  =  true;
					break;
			default:
				result  =  false;
				break;
			}		
			return result;
		}
	}
	// Update is called once per frame
	void Update () 
	{
		//Time.timeScale = timeSpeed;
		
		currentDate = currentDate.AddSeconds (Time.deltaTime);
		//checks end of day. 
		CheckDay ();
		CheckMonth();
		//currentMonth = currentDate.Month;
		//currentDay.day = currentDate.Day;
		//print (currentDate.Day);
		
		
		//Output to Display
		timeDisplay.GetComponent<TextMesh>().text = currentDate.ToString();
		
	}
	
	public static void AddMonth()
	{
		
		while(!currentDay.isEndOfMonth(currentDate.Month))
		{
			print (currentDay.day);
			currentDate = currentDate.AddDays(1);
			CheckDay ();
			//currentDay.day = currentDate.Day;
			//PerformDailyActions();
		}
		currentDate = currentDate.AddDays (1);
	}
	
	public static void CheckDay()
	{
		if(currentDate.Day > currentDay.day || currentDate.Day < currentDay.day && currentDay.isEndOfMonth(currentMonth))
		{
			PerformDailyActions();
			currentDay.day = currentDate.Day;
		}
	}
	
	public static void CheckMonth()
	{
		if (currentDate.Month > currentMonth|| currentDate.Month == 1 && currentMonth == 12)
		{
			PerformMonthlyActions();
			currentMonth = currentDate.Month;
		}
	}
	
	//Add Day
	public static void AddDay()
	{
		currentDate = currentDate.AddDays (1);
	}
	
	//Monthly Actions
	public static void PerformMonthlyActions()
	{
		DeductCosts();
		for(int i = currentMonth; i < 12; i++)
		{MoneyManager.AddPoint (i);}
		CreateGraph graph = FindObjectOfType(typeof(CreateGraph)) as CreateGraph;
		graph.CalculatePoints();
	}
	
	//Daily Actions
	public static void PerformDailyActions()
	{
		BasicObject[] items = FindObjectsOfType (typeof(BasicObject)) as BasicObject[];
		
		foreach(BasicObject item in items)
		{
			item.life -= 1;
		}
		
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
