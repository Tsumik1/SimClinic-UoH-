using UnityEngine;
using System.Collections;

public class LoanScreen : MonoBehaviour {

	
	public GameObject loanText; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		loanText.GetComponent<TextMesh>().text = MoneyManager.outstandingLoanAmount.ToString();
	}
}
