using UnityEngine;
using System.Collections;


/* Name: NewGameButton
 * Description: This is applied to the confirm new game button on the review screen on initial setup.
 * The data is then sent to playerprefs to be called when the game begins.
 * Author: Blake Kendrick 
 * Date: 09/01/2012
 * */


public class NewGameButton : MonoBehaviour {
	
	
	public TextBox playerNameBox;
	public TextBox clinicNameBox; 
	public Slider  playerInvestmentSlider;
	public Slider  playerLoanSlider;
	
	public TextMesh playerNameDisplay;
	public TextMesh clinicNameDisplay; 
	public TextMesh playerInvestmentDisplay;
	public TextMesh playerLoanDisplay; 
	public TextMesh availableMoneyDisplay; 
	
	private string playerName;
	private string clinicName;
	private float playerInvestment; 
	private float playerLoan; 
	private float availableMoney; 
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		playerName = playerNameBox.text;
		clinicName = clinicNameBox.text; 
		playerInvestment = playerInvestmentSlider.GetValue();
		playerLoan = playerLoanSlider.GetValue (); 
		availableMoney = playerInvestment + playerLoan; 
		SetDisplays(); 
	}
	
	void Clicked()
	{
		SaveInitialSettings ();
		Application.LoadLevel ("BuildingSelect");
	}
	
	private void SaveInitialSettings()
	{
		PlayerPrefs.SetString ("PlayerName", playerName);
		PlayerPrefs.SetString ("ClinicName", clinicName);
		PlayerPrefs.SetFloat ("PlayerInvestment", playerInvestment);
		PlayerPrefs.SetFloat ("PlayerLoan", playerLoan);
		PlayerPrefs.SetFloat ("AvailableCash", availableMoney);
		PlayerPrefs.Save (); 
	}
	
	private void SetDisplays()
	{
		playerNameDisplay.text = playerName; 
		clinicNameDisplay.text = clinicName; 
		string currency = "£"; 
		playerInvestmentDisplay.text = currency + playerInvestment.ToString("f" + playerInvestmentSlider.roundValue); 
		playerLoanDisplay.text = currency + playerLoan.ToString("f" + playerLoanSlider.roundValue); 
		availableMoneyDisplay.text = currency + availableMoney.ToString ("f0"); 
	}
}
