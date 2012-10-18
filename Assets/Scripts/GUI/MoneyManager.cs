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
		moneyDisplay.GetComponent<TextMesh>().text = "$" + money.ToString();
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
}
