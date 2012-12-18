using UnityEngine;
using System.Collections;

public class AlterQuality : MonoBehaviour {

	
	public enum ButtonType
	{
		increase,
		decrease
	}
	
	public ButtonType t = ButtonType.increase; 
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void Clicked()
	{
		if(t == ButtonType.increase)
		{
			QualitySettings.IncreaseLevel ();
		}
		if(t == ButtonType.decrease)
		{
			QualitySettings.DecreaseLevel ();
		}
	}
}
