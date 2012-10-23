using UnityEngine;
using System.Collections;

public class MoneyManager : MonoBehaviour 
{
	public int initialMoney; 
	public GameObject moneyDisplay; 
	public string currency = "£";
	
	public static double money; 
	
	public static double actualMoney;
	
	public static double outstandingLoanAmount; 
	
	public static double loanIncremental = 1000; 
	public static int initialInterestRate; 
	private static int percentage = 6;
	
	public static double[] profits;
	// Use this for initialization
	void Start () 
	{
		profits = new double[12];
		for(int i = 0; i < 12; i++)
		{
			profits[i] = initialMoney;
		}
		money = initialMoney;
		actualMoney = money; 
		outstandingLoanAmount = 0; // At least until we sort it out in playerprefs... 
		percentage = initialInterestRate / 10;
	}
	
	// Update is called once per frame
	void Update () 
	{
		moneyDisplay.GetComponent<TextMesh>().text = currency + money.ToString();
	}
	
	public static void IncrementLoan()
	{
		money += loanIncremental;
		outstandingLoanAmount += CalculateInterest(loanIncremental, percentage);
		actualMoney = money - outstandingLoanAmount;
	}
	
	public static double CalculateInterest(double amount, int percent)
	{
		double interest = amount * percent;
		return interest;
	}
	
	public static bool Purchase(int amount)
	{
		if (money - amount < 0)
			return false;
		else
			{
				money = money - amount;
				return true;
			}
	}
	
	public static void AddPoint(int month)
	{
		profits[month] = money;
	}
}
