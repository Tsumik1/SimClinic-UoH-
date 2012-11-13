using UnityEngine;
using System.Collections;
using System;

public class TimeManager : MonoBehaviour 
{
	public GameObject timeDisplay; 
	public GameObject dateDisplay;
	public float timeSpeed = 1f; 
	public static int openingTime = 9; 
	public static int closingTime = 17; 
	public static DateTime currentDate;
	public static DateTime endDate;
	
	//public static int currentMonth; 
	public static Day currentDay; 
	public static Month currentMonth; 
	public static Year currentYear; 
	public static Hour currentHour;
	
	//private int month; 
	// Use this for initialization
	
	//These are a bunch of helper support classes to better manage the time of day to be able to 
	//effectivly perform actions when needed in specific time frames.
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
	
	public class Month
	{
		public int month; 
		public string monthName; 
		
		public Month()
		{
			month = 1; 
			monthName = "January";
		}
		
		public string getCurrentMonthName()
		{
			return getMonthName(month);
		}
		
		public string getMonthName(int monthNumber)
		{
			string monthName; 
			switch(monthNumber)
			{
			case 1: 
				monthName = "January";
				break;
			case 2: 
				monthName = "Febuary";
				break;
			case 3: 
				monthName ="March";
				break;
			case 4:
				monthName  = "April";
				break; 
			case 5: 
				monthName = "May";
				break;
			case 6: 
				monthName = "June";
				break;
			case 7: 
				monthName = "July";
				break;
			case 8: 
				monthName = "August";
				break;
			case 9:
				monthName = "September";
				break;
			case 10:
				monthName = "October";
				break;
			case 11:
				monthName = "November";
				break;
			case 12:
				monthName = "December";
				break;
			default:
				monthName = "Error :)";
				break;
			}
			return monthName;
			
		}
	}
	
	public class Year
	{
		public int year; 
		
		public Year()
		{
			year = 2012;
		}
		
	}
	
	public class Hour
	{
		public int hour; 
		
		public bool endOfDay;
		
		public Hour(int theHour)
		{
			hour = theHour;
		}
		
		public bool IsPM()
		{
			if(hour > 11)
				return true;
			else
				return false;
		}
	}
	void Awake() 
	{
		//Will use playerprefs here to sort this out but for testing purposes...
		currentDate = new DateTime(2012,10,18);
		Time.timeScale = timeSpeed; 
		//month = currentDate.Month;
		currentDay = new Day();
		currentMonth = new Month();
		currentYear = new Year();
		currentHour = new Hour(currentDate.Hour);
		currentDay.day = currentDate.Day;
		currentYear.year = currentDate.Year;
		currentMonth.month = currentDate.Month;
		currentHour.hour = currentDate.Hour;
		//PerformMonthlyActions();
	}
	

	// Update is called once per frame
	void Update () 
	{
		//Time.timeScale = timeSpeed;
		
		currentDate = currentDate.AddSeconds (Time.deltaTime * 4);
		//checks end of day. 
		CheckDay ();
		CheckMonth();
		CheckYear();
		CheckHour();
		
		//currentMonth = currentDate.Month;
		//currentDay.day = currentDate.Day;
		//print (currentDate.Day);
		
		
		//Output to Display
		dateDisplay.GetComponent<TextMesh>().text = currentDate.ToShortDateString();
		timeDisplay.GetComponent<TextMesh>().text = currentDate.ToShortTimeString ();
		
	}
	
	public static void AddMonth()
	{
		
		while(!currentDay.isEndOfMonth(currentDate.Month))
		{
			//print (currentDay.day);
			AddDay ();
			CheckDay ();
			//currentDay.day = currentDate.Day;
			//PerformDailyActions();
		}
		currentDate = currentDate.AddDays (1);
	}
	
	public static void AddDay()
	{
		for(int i = 0; i < 24; i++)
		{
			AddHour ();
			CheckHour ();
		}
	}
	
	public static void AddHour()
	{

		currentDate = currentDate.AddHours (1);
	}
	public static void CheckHour()
	{
		if(currentDate.Hour > currentHour.hour || currentDate.Hour < currentHour.hour && currentHour.endOfDay)
		{
			PerformHourlyActions();
			currentHour.hour = currentDate.Hour;
		}
	}
	
	public static void CheckDay()
	{
		if(currentDate.Day > currentDay.day || currentDate.Day < currentDay.day && currentDay.isEndOfMonth(currentMonth.month))
		{
			PerformDailyActions();
			currentDay.day = currentDate.Day;
		}
	}
	
	public static void CheckMonth()
	{
		if (currentDate.Month > currentMonth.month|| currentDate.Month == 1 && currentMonth.month == 12)
		{
			PerformMonthlyActions();
			currentMonth.month = currentDate.Month;
		}
	}
	
	public static void CheckYear()
	{
		if(currentDate.Year > currentYear.year)
		{
			
		}
	}
	//Add Day

	public static void PerformHourlyActions()
	{
		if(currentHour.hour == openingTime)
		{
			StaffManager.StartWork();
		}
		if(currentHour.hour == closingTime)
		{
			StaffManager.GoHome();	
		}
		StaffManager.UpdateStaffActions();
	}
	
	//Yearly Actions
	public static void PerformYearlyActions()
	{
		
	}
	
	//Monthly Actions
	public static void PerformMonthlyActions()
	{
		for(int i = currentMonth.month; i <= 12; i++)
		{MoneyManager.AddPoint (i-1);}
		CreateGraph graph = FindObjectOfType(typeof(CreateGraph)) as CreateGraph;
		if(graph)
		{graph.CalculatePoints(currentMonth.month - 1);}
		DeductCosts();
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
		MoneyManager.DeductMonthlyCosts();
	}
	
	public static string GetMonthName(int i)
	{
		return currentMonth.getMonthName(i);
	}
	
	public static int HoursUntilOpeningTime()
	{
		switch(currentHour.hour)
		{
		case 0:
			return 9;
		case 1:
			return 8; 
		case 2: 
			return 7;
		case 3:
			return 6;
		case 4: 
			return 5;
		case 5: 
			return 4;
		}
	}
}
