using UnityEngine;
using System.Collections;

public class Helper : MonoBehaviour {
	
	
	private static NameGenerator nameGen; 
	
	static void Awake () 
	{
		nameGen = new NameGenerator();
	}
	
	public static bool RandomBool()
	{
		int flag = Random.Range (0,1);
		if(flag == 0)
		{
			return false;
		}
		if(flag == 1)
		{
			return true;
		}
		else
		{
			return false;
		}
		return false;
	}
	
	public static string GenerateName(bool gender, int length)
	{
		nameGen = new NameGenerator();
		return nameGen.CreateName(gender, length);
	}
	// Use this for initialization

	public static string GenerateConditionName()
	{
		nameGen = new NameGenerator();
		return nameGen.CreateCondition();
	}
	
	public static void DisableGraphics()
	{
		MeshRenderer[] meshes = FindObjectsOfType(typeof(MeshRenderer)) as MeshRenderer[];
		foreach(MeshRenderer m in meshes)
		{
			m.enabled = false;
		}
	}
	
	public static void SimulateMonth()
	{
		PatientManager.DestroyPatients();
		PatientManager.SimulateMonth ();
		StaffManager.ResetStaff();
		if(StaffManager.StaffHired (Staff.Role.practitioner))
		{
			MoneyManager.SimulateMonthlyIncome();
		}
		if(StaffManager.StaffHired (Staff.Role.caretaker))
		{
			ObjectManager.SimulateWearAndTear (14);
		}
		else
		{
			ObjectManager.SimulateWearAndTear(28);
		}
	}
	
	public static void SimulateDay()
	{
		PatientManager.DestroyPatients ();
		PatientManager.SimulateDay();
		StaffManager.ResetStaff();
		MoneyManager.SimulateDailyIncome();
		//ObjectManager.SimulateWearAndTear(1);
	}

	// Update is called once per frame
	void Update () {
	
	}
	
	public static string FormatString(string txt, int maxChars)
	{
		string t = "";
		int currentLine = 1; 
		int charCount = 0;
		string[] words = txt.Split (" " [0]);
		string result = "";
		
		for(int i = 0; i < words.Length; i++)
		{
			string word = words[i].Trim ();
			if(i==0)
			{
				result = words[0];
				t = result; 
				
			}
			if(i>0)
			{
				charCount += word.Length +1; 
				if(charCount <= maxChars)
				{
					result += " " + word;
				}
				else
				{
					charCount = 0;
					result += "\n" + word;
				}
			}
			
			t = result;
		}
		return t;
	}
}
