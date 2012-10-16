using UnityEngine;
using System.Collections;

public class MoneyManager : MonoBehaviour 
{
	public int initialMoney; 
	public GameObject moneyDisplay; 
	
	public static int money; 
	// Use this for initialization
	void Start () 
	{
		money = initialMoney;
	}
	
	// Update is called once per frame
	void Update () 
	{
		moneyDisplay.GetComponent<TextMesh>().text = money.ToString();
	}
}
