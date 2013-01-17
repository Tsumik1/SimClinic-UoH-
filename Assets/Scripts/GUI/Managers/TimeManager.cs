using UnityEngine;
using System.Collections;
using System;
	[SerializeAll]
public class TimeManager : MonoBehaviour 
{
	public GameObject timeDisplay; 
	public GameObject dateDisplay;
	public float timeSpeed = 1f; 
	public static int openingTime = 9; 
	public static int closingTime = 17; 
	public static DateTime currentDate;
	public static DateTime endDate;
	public static int multiplyValue = 10;
	
	//public static int currentMonth; 
	public static Day currentDay; 
	public static Month currentMonth; 
	public static Year currentYear; 
	public static Hour currentHour;
	public static Minute currentMinute;
	public static int randomMinute;
	public static bool skip = false;
	
	public int randMin; 
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
		
		public Hour()
		{
			//default constructor, necessecary for serialization
			hour = 0;
		}
		
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
	
	public class Minute 
	{
		public int minute; 
		public Minute()
		{
			minute = 0;
		}
		public Minute(int theMinute)
		{
			minute = theMinute;
		}
	}
	void Awake() 
	{
		if(LevelSerializer.IsDeserializing)
		{
			return;
		}
		//Will use playerprefs here to sort this out but for testing purposes...
		currentDate = new DateTime(2012,10,18,6,0,0);
		Time.timeScale = timeSpeed; 
		//month = currentDate.Month;
		currentDay = new Day();
		currentMonth = new Month();
		currentYear = new Year();
		currentHour = new Hour(currentDate.Hour);
		currentMinute = new Minute(currentDate.Minute);
		currentDay.day = currentDate.Day;
		currentYear.year = currentDate.Year;
		currentMonth.month = currentDate.Month;
		RandomMinute ();
		//PerformMonthlyActions();
	}
	
	static void RandomMinute()
	{
		randomMinute = UnityEngine.Random.Range (0,59);
	}
	// Update is called once per frame
	void Update () 
	{
		//Time.timeScale = timeSpeed;
		
		currentDate = currentDate.AddSeconds (Time.deltaTime  * multiplyValue);
		//checks end of day. 
		if(currentDate != null)
		{
			CheckDay ();
			CheckMonth();
			CheckYear();
			CheckHour();
			CheckMinute();
		}
		randMin = randomMinute;
		
		//currentMonth = currentDate.Month;
		//currentDay.day = currentDate.Day;
		//print (currentDate.Day);
		
		
		//Output to Display
		dateDisplay.GetComponent<TextMesh>().text = currentDate.ToShortDateString();
		timeDisplay.GetComponent<TextMesh>().text = currentDate.ToShortTimeString ();
		
	}
	
	public static void AddMonth()
	{
		currentDate = currentDate.AddMonths (1);
		Helper.SimulateMonth();
		CheckMonth ();
	}
	
	public static void AddDay()
	{
		Helper.SimulateDay();
		currentDate = currentDate.AddDays (1);
		CheckDay();
//		for(int i = 0; i < 24; i++)
//		{
//			
//			AddHour ();
//			CheckHour ();
//		}
	}
	
	public static void AddHour()
	{
		//currentDate = currentDate.AddHours(1);
		for(int i = 0; i < 60; i++)
		{
			AddMinute ();
			CheckMinute ();
		}

	}
	
	public static void AddMinute()
	{
		currentDate = currentDate.AddMinutes (1);
	}
	
	public static void CheckHour()
	{
		//print(currentDate.Hour);
		if(currentDate.Hour > currentHour.hour || currentDate.Hour == 0 && currentHour.hour == 23)
		{
			currentHour.hour = currentDate.Hour;
			
			PerformHourlyActions();
		}
	}
	
	public static void CheckDay()
	{
		if(currentDate.Day > currentDay.day || currentDate.Day < currentDay.day && currentDay.isEndOfMonth(currentMonth.month))
		{
			currentDay.day = currentDate.Day;
			
			PerformDailyActions();
		}
	}
	
	public static void CheckMonth()
	{
		if (currentDate.Month > currentMonth.month|| currentDate.Month == 1 && currentMonth.month == 12)
		{
			currentMonth.month = currentDate.Month;
			
			PerformMonthlyActions();
		}
	}
	
	public static void CheckYear()
	{
		if(currentDate.Year > currentYear.year)
		{
			
		}
	}
	
	public static void CheckMinute()
	{
	  if(currentDate.Minute > currentMinute.minute || currentDate.Minute == 0 && currentMinute.minute == 59)
		{
			currentMinute.minute = currentDate.Minute;
			PerformMinuteActions();
		}
	}
	//Add Day
	
	public static void PerformMinuteActions()
	{
		if(currentMinute.minute == randomMinute)
		{
			Spawner2.SpawnPatient ();
			RandomMinute();
		}
		StaffManager.UpdateStaffTimeToNextWaypoint();
		PatientManager.MinutePassed();
	}
	
	public static void PerformHourlyActions()
	{
		if(currentHour.hour == openingTime)
		{
			StaffManager.StartWork();
			return;
		}
		if(currentHour.hour == closingTime)
		{
			StaffManager.GoHome();	
			PatientManager.AllGoHome();
			return;
		}
		//StaffManager.UpdateStaffActions();
		//print(currentHour.hour);
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
		PatientManager.AddPatientTotal (currentMonth.month-1);
		PatientManager.monthlyPatients = 0;
	}
	
	//Daily Actions
	public static void PerformDailyActions()
	{
		ObjectManager.SimulateWearAndTear(1);
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
		int hoursRemaining; 
		switch(currentHour.hour)
		{
		case 0:
			hoursRemaining = openingTime;
			break;
		case 1:
			hoursRemaining = openingTime -1;
			break;
		case 2: 
			hoursRemaining = openingTime -2; 
			break;
		case 3: 
			hoursRemaining = openingTime -3; 
			break;
		case 4: 
			hoursRemaining = openingTime -4; 
			break;
		case 5: 
			hoursRemaining = openingTime -5;
			break;
		case 6: 
			hoursRemaining = openingTime - 6; 
			break; 
		case 7: 
			hoursRemaining = openingTime -7;
			break;
		case 8: 
			hoursRemaining = openingTime -8; 
			break;
		case 9: 
			hoursRemaining = openingTime -9; 
			break;
		default: 
			hoursRemaining = 9; 
			break;
		}
		if (currentHour.hour == openingTime)
		{
			hoursRemaining = 0; 
		}
		if(currentHour.hour == closingTime)
		{
			hoursRemaining = 24 - (closingTime - openingTime);
		}
		if(hoursRemaining < 0)
			hoursRemaining = 0; 
	return hoursRemaining;
	}
	
	public static int TimeTillClosingTimeInMinutes()
	{
		int closingTimeInMinutes = closingTime * 60;
		int currentTimeInMinutes = currentHour.hour * 60;
		closingTimeInMinutes -= currentTimeInMinutes; 
		print(closingTimeInMinutes);
		return closingTimeInMinutes;
	}
	
	public static bool IsOpen()
	{
		if(currentHour.hour >= openingTime && currentHour.hour <= closingTime)
			return true;
		else
			return false;
	}
}
