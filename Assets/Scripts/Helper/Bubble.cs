using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour {
	
	
	public TextMesh textField;
	public int timeDisplayed = 4;
	// Use this for initialization
	void Start () 
	{
		InvokeRepeating ("Display",1f,1f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	public void SetText(string message)
	{
		textField.text = message;
	}
	
	public void Display()
	{
		timeDisplayed--;
		if(timeDisplayed == 0)
		{
			Destroy(gameObject);
		}
	}
}
