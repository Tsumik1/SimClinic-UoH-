using UnityEngine;
using System.Collections;

public class SellValue : MonoBehaviour {
	
	
	public int moneyBonus; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnDestroy()
	{
			MoneyManager.money += moneyBonus; 
	}
}
