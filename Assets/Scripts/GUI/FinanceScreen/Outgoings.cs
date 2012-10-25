using UnityEngine;
using System.Collections;

public class Outgoings : MonoBehaviour {

	
	public GameObject running;
	public GameObject repair;
	public GameObject other; 
	public GameObject totalEquip; 
	public GameObject rent;
	public GameObject bills;
	public GameObject totalBuilding; 
	public GameObject wage; 
	public GameObject training; 
	public GameObject totalStaff;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		running.GetComponent<TextMesh>().text = MoneyManager.monthlyRunningCosts.ToString();
		repair.GetComponent<TextMesh>().text = MoneyManager.monthlyRepairCosts.ToString ();
		totalEquip.GetComponent<TextMesh>().text = MoneyManager.monthlyEquipmentCost.ToString ();
		rent.GetComponent<TextMesh>().text = MoneyManager.monthlyRent.ToString ();
		bills.GetComponent<TextMesh>().text = MoneyManager.bills.ToString();
		totalBuilding.GetComponent<TextMesh>().text = MoneyManager.monthlyBuildingCost.ToString ();
		wage.GetComponent<TextMesh>().text = MoneyManager.monthlyWages.ToString ();
		training.GetComponent<TextMesh>().text = MoneyManager.monthlyTraining.ToString ();
		totalStaff.GetComponent<TextMesh>().text = MoneyManager.monthlyStaffCost.ToString();
	}
}
