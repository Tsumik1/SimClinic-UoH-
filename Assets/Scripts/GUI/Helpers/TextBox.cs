using UnityEngine;
using System.Collections;

public class TextBox : MonoBehaviour {

	
	public string text; 
	public TextMesh display; 
	public bool active; 
	public float blinkTime; 
	public int maxLineChars; 
	private float lastKeyTime;
	
	private bool blinking = false;
	private string[] words; 
	private string result = ""; 
	private int charCount = 0; 
	private Vector3 baseScale; 
	private Vector3 textPosition; 
	// Use this for initialization
	void Start () 
	{
		text = ""; 
		lastKeyTime = Time.time;
		baseScale = transform.localScale;
		textPosition = display.transform.position;
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
			display.text = Helper.FormatString (text, maxLineChars);
			if(!blinking)
			{
				//CheckBounds ();
			}
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
	
	void UpdateCharacters()
	{
		
	}
	
	public void CheckBounds()
	{
		char[] c = text.ToCharArray();
		int currentChar = 0;
		int numberOfLines = 0; 
		
		for(int i = 0; i < c.Length; i++)
		{
			currentChar++; 
			if(currentChar >= maxLineChars-1)
			{
				numberOfLines++;
				display.transform.parent = null; 
				Vector3 newScale = baseScale;
				newScale.z = baseScale.z * numberOfLines;
				transform.localScale = newScale;
				currentChar = 0;
				display.transform.parent = transform;
			}
		}
		Vector3 newTextPosition = textPosition; 
		for(int i = 0; i <= numberOfLines;i++)
		{
			newTextPosition.y += baseScale.z * numberOfLines - (display.characterSize);
		}
		display.transform.position = newTextPosition;
	}
}
