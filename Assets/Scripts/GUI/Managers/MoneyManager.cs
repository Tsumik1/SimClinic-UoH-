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
	public double initialInterestRate; 
	private static double percentage = 6;
	
	public static double[] profits;
	// Use this for initialization
	void Awake () 
	{
		profits = new double[12];
		for(int i = 0; i < 12; i++)
		{
			profits[i] = initialMoney;
		}
		money = initialMoney;
		actualMoney = money; 
		outstandingLoanAmount = 0; // At least until we sort it out in playerprefs... 
		percentage = initialInterestRate / 100;
		print("PER : " + percentage);
	}
	
	// Update is called once per frame
	void Update () 
	{
		moneyDisplay.GetComponent<TextMesh>().text = currency + money.ToString();
	}
	
	public static void IncrementLoan()
	{
		money += loanIncremental;
		outstandingLoanAmount += loanIncremental + CalculateInterest(loanIncremental, percentage);
		print(outstandingLoanAmount);
		//print (outstandingLoanAmount);
		actualMoney = money - outstandingLoanAmount;
	}
	
	public static void PayBackLoan()
	{
		
		if(outstandingLoanAmount >= loanIncremental)
		{
			money -= loanIncremental;
			outstandingLoanAmount -= loanIncremental;
		}
		if(outstandingLoanAmount <loanIncremental && outstandingLoanAmount > 0)
		{
			
			money = money - outstandingLoanAmount;
			outstandingLoanAmount = 0;
		}
		actualMoney = money - outstandingLoanAmount;
	}
	
	public static double CalculateInterest(double amount, double percent)
	{
		
		print (amount);
		print (percent);
		double interest = amount * percent;
		//print (interest);
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
