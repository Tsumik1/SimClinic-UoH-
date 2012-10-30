using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;
public class Overview : MonoBehaviour {

	
	public GameObject moneyText; 
	public GameObject actualMoneyText;
	public GameObject profitText; 
	public GameObject lossText; 
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		moneyText.GetComponent<TextMesh>().text = MoneyManager.money.ToString();
		actualMoneyText.GetComponent<TextMesh>().text = MoneyManager.actualMoney.ToString();
	}
}
