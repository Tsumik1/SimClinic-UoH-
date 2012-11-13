using UnityEngine;
using System.Collections;

public class ButtonBehaviour: MonoBehaviour {

	
	public enum ButtonType
	{
		Image, 
		Default, 
		Unique
	}
	
	public ButtonType type; 
	public Material mouseOver; 
	public Color defaultHoverColor; 
	
	
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
	void Update () {
	
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
