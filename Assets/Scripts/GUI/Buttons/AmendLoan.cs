using UnityEngine;
using System.Collections;

public class AmendLoan : MonoBehaviour {
	
	
	public int loanIncrement;
	
	public enum condition
	{
		increase,
		decrease
	}
	
	public condition conditions;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Clicked()
	{
		if(conditions == condition.increase)
			MoneyManager.IncrementLoan();
		if(conditions==condition.decrease)
			MoneyManager.PayBackLoan();
	}
}
