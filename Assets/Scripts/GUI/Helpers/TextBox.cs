using UnityEngine;
using System.Collections;

public class TextBox : MonoBehaviour {

	
	public string text; 
	public TextMesh display; 
	public bool active; 
	public float blinkTime; 
	private float lastKeyTime;
	
	private bool blinking = false;
	// Use this for initialization
	void Start () 
	{
		text = ""; 
		lastKeyTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(active)
		{
			if(Input.anyKey && !Input.GetKey (KeyCode.Backspace))
			{
				text += Input.inputString.ToString ();
				lastKeyTime = Time.time;
			}
			if(Input.GetKeyDown(KeyCode.Backspace))
			{
				DeleteCharacter();
			}
			//print (Time.time - lastKeyTime);
			if(Time.time - lastKeyTime > blinkTime)
			{
				if(!blinking)
				{
					Blink();
					lastKeyTime = Time.time;
				}
			}
			display.text = text;
		}
	}
	
	void Blink()
	{
		blinking = true;
		if(Input.anyKey)
		{
			return;
			blinking = false;
		}
		text += "|";
		Invoke ("DeleteCharacter",0.5f);
		
	}
	
	void DeleteCharacter()
	{
		if(text.Length >0)
		{
			text = text.Substring (0, text.Length-1);
		if(blinking)
			{
				blinking = false;
			}
		}
		
	}
	void Clicked()
	{

		//this.enabled = true;
		foreach(TextBox t in FindObjectsOfType(typeof(TextBox)))
		{
			t.active = false;
		}
				active = true; 
	}
}
