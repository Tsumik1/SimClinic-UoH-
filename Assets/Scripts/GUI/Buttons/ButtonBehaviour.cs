using UnityEngine;
using System.Collections;

public class ButtonBehaviour: MonoBehaviour {

	
	public enum ButtonType
	{
		Image, 
		Default, 
		Unique
	}
	
	public enum Action
	{
		standard, 
		radio
	}
	
	public ButtonType type; 
	public Action behaviour;
	public Material mouseOver; 
	public Material pressed;
	public Color defaultHoverColor; 
	public Color defaultPressedColor;
	public bool trueFalse;
	
	private Material standard; 
	private Color defaultColor;
	private Color standardColor;  
	// Use this for initialization
	void Start () 
	{
		standardColor = renderer.material.color; 
		standard = renderer.material;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(trueFalse)
		{
			renderer.material = mouseOver;
		}
		else
		{
			//renderer.material = standard;
		}
	}
	
	public void OnMouseDown()
	{
		//SendMessage("Clicked");
		print("Button Pressed!");
		if(type == ButtonType.Image)
		{
			renderer.material = pressed;
		}
		if(type == ButtonType.Default)
		{
			renderer.material.color = defaultPressedColor;
		}
		if(behaviour == Action.radio)
		{
			trueFalse = !trueFalse;
		}
	}
	
	public void OnMouseUp()
	{
		   renderer.material = standard;
		renderer.material.color = standardColor;
		
	}
	
	public void OnMouseEnter ()
	{
		if(type == ButtonType.Image)
		{renderer.material = mouseOver;}
		if(type == ButtonType.Default)
		{
			renderer.material.color = defaultHoverColor;
		}
	}

	public void OnMouseExit ()
	{
    	renderer.material = standard;
		renderer.material.color = standardColor;
	}

}
