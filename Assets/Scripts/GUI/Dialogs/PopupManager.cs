using UnityEngine;
using System.Collections;
public class PopupManager : MonoBehaviour {

	public GameObject sellConfirm; 
	public GameObject infoPop; 
	public GameObject stockPop;
	public GameObject financePop;
	public GameObject overPop;
	public GameObject leftButton;
	public GameObject rightButton; 
	public GameObject restockPop;
	
	public static GameObject sellConfirmer;
	public static GameObject infoPopper;
	public static GameObject stockPopup;
	public static GameObject lButton; 
	public static GameObject rButton;
	public static GameObject financePopup;
	public static GameObject overPopup;
	public static GameObject restockPopup;
	
	// Use this for initialization
	void Awake() 
	{
		sellConfirmer = sellConfirm; 
		infoPopper = infoPop;
		stockPopup = stockPop;
		overPopup = overPop;
		financePopup= financePop;
		restockPopup = restockPop;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
