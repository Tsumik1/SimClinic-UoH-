using UnityEngine;
using System.Collections;

public class MoneyManager : MonoBehaviour 
{
	public int initialMoney; 
	public GameObject moneyDisplay; 
	public string currency = "£"; 
	public double initialInterestRate; 
	public double initialRent; 
	public double billCostPerMonth; // This will be determined from the player settings. Not sure how to do this yet...
	
	public static double money; 
	public static double actualMoney;
	
	public static double monthlyRent; 
	public static double bills;
	
	public static double monthlyBuildingCost; 
	
	public static double monthlyEquipmentCost;
	
	public static double monthlyRunningCosts;
	public static double monthlyRepairCosts; 
	public static double[] repairCosts;
	public static double totalRepairCosts;
	
	public static double monthlyIncome;
	public static double[] incomes; 
	public static double totalIncome; 
	
	public static double monthlyStaffCost;
	public static double[] staffCost;
	public static double monthlyTraining; 
	public static double monthlyWages; 
	public static double totalStaffCost;
	
	public static double outstandingLoanAmount; 
	public static double loanIncremental = 1000; 
	private static double percentage = 6;
	
	public static double[] profits;
	// Use this for initialization
	void Awake () 
	{
		profits = new double[12];
		repairCosts = new double[12];
		incomes = new double[12];
		staffCost = new double[12];
		for(int i = 0; i < 12; i++)
		{
			profits[i] = initialMoney;
			repairCosts[i] = 0;
			incomes[i] = 0; 
			staffCost[i] = 0;
		}
		monthlyRent = initialRent;
		bills = billCostPerMonth;
		money = initialMoney;
		actualMoney = money; 
		outstandingLoanAmount = 0; // At least until we sort it out in playerprefs... 
		percentage = initialInterestRate / 100;
		//print("PER : " + percentage);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		CalculateAll ();
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
		else
		{
		if(outstandingLoanAmount < loanIncremental && outstandingLoanAmount > 0)
		{
			
			money = money - outstandingLoanAmount;
			outstandingLoanAmount = 0;
		}
		}
		actualMoney = money - outstandingLoanAmount;
	}
	
	public static double CalculateInterest(double amount, double percent)
	{
		
		print (amount);
		print (percent);
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
	
	public static double CalculateRunningCosts()
	{			
	double monthlyCosts = 0; 
	  BasicObject[] equipment = FindObjectsOfType(typeof(BasicObject)) as BasicObject[];
		foreach(BasicObject item in equipment)
		{

			monthlyCosts += item.costPerMonth;
		}
		
	return monthlyCosts;	
	}
	public static void CalculateStaffCost()
	{
		CalculateWages ();
		monthlyStaffCost = monthlyWages + monthlyTraining; 
	}
	
	public static void CalculateWages()
	{
		monthlyWages = StaffManager.StaffWage(); 
	}
	
	public static void CalculateRepairCost()
	{
				
	}
	
	public static void CalculateIncome()
	{
		
	}
	
	public static void CalculateBuildingCost()
	{
		monthlyBuildingCost = monthlyRent + bills; 
	}
	public static void CalculateAll()
	{
		monthlyRunningCosts = CalculateRunningCosts();
		CalculateEquipmentCost();
		CalculateStaffCost ();
		CalculateBuildingCost();
	}
	
	public static void CalculateEquipmentCost()
	{
		monthlyEquipmentCost = monthlyRepairCosts + monthlyRunningCosts;
	}
	
	public static void AddToRepairCost(double price)
	{
		monthlyRepairCosts += price;
	}
	
	public static void AddPoint(int month)
	{
		profits[month] = money;
		incomes[month] = monthlyIncome;
		repairCosts[month] = monthlyRepairCosts;
		staffCost[month] = monthlyStaffCost;
	}
	
	public static void DeductMonthlyCosts()
	{
		CalculateAll ();
		double amount = (monthlyRepairCosts + monthlyStaffCost + monthlyRent + monthlyEquipmentCost + bills);
		money -= amount;
	}
	
	public static void AddIncome()
	{
		
	}
	
	public static double GetRepairCostAtMonth(int month)
	{
		return repairCosts[month];
	}
	
}
