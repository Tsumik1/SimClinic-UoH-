using UnityEngine;
using System.Collections;

/* Name: ColourSelector
 * Description: This class is used to create a colour selector which can be used to allow the user to select a colour for different objects.
 * Author: Blake Kendrick 
 * Date: 07/01/2012
 * */

public class ColourSelector : MonoBehaviour {
	
	public Slider redSlider; 
	public Slider blueSlider;
	public Slider greenSlider; 
	
	public GameObject colorDisplay; 
	
	private Color selectedColor; 
	// Use this for initialization
	void Start () 
	{
		selectedColor = new Color(0,0,0,255);
	}
	
	// Update is called once per frame
	void Update () 
	{
		selectedColor.r = redSlider.GetValue();
		selectedColor.g = greenSlider.GetValue();
		selectedColor.b = blueSlider.GetValue();
		
		colorDisplay.renderer.material.color = selectedColor;
	}
	
	
	//Returns the selected colour. 
	public Color GetColor()
	{
		return selectedColor;
	}
}
