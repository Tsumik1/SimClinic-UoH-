using UnityEngine;
using System.Collections;

/* Name: Slider
 * Description: Class that controls a slider in the bespoke GUI system.
 * Author: Blake Kendrick 
 * Date: 17/12/2012
 * */
public class Slider : MonoBehaviour {

	
	public int min;
	public int max;
	public int defaultValue;
	public int[] snaps;
	public int roundValue; 
	public TextMesh minDisplay; //displays min value
	public TextMesh maxDisplay; //displays max value. 
	public TextMesh valDisplay;
	public GameObject point;
	private float sliderValue;
	private bool moving = false; 
	private BoxCollider myCol; //collider
	private BoxCollider pointCol; //collider
	private Vector3 minPosition;
	private Vector3 maxPosition;
	private string roundControl;
	// Use this for initialization
	void Start () 
	{
		//Make sure the snaps are valid. 
		for(int i = 0; i < snaps.Length; i++)
		{
			if(snaps[i]>max)
			{
				snaps[i] = max;
			}
			if(snaps[i]<min)
			{
				snaps[i] = min;
			}
		}
		roundControl = "f" + roundValue;
		minPosition = transform.position;
		minPosition.x = minPosition.x - (renderer.bounds.size.x /2f)  + (point.renderer.bounds.size.x/2f);
		//minPosition.x = minPosition.x - (parentCol.size.x / transform.parent.lossyScale.x) - (myCol.size.x * transform.localScale.x * 2);
		maxPosition = transform.position;
		//maxPosition.x += parentCol.size.x - (myCol.size.x * transform.lossyScale.x) - (myCol.size.x* transform.localScale.x * 2); 
		maxPosition.x = maxPosition.x +(renderer.bounds.size.x / 2f) - (point.renderer.bounds.size.x/2f);
		if(defaultValue == 0 || defaultValue == null)
		{
			defaultValue = max/2;
		}
		sliderValue = defaultValue;
		Vector3 neat = point.transform.localPosition;
		neat.x = 0; 
		point.transform.localPosition = neat; 
	}
	
	public float GetValue()
	{
		return sliderValue;
	}
	// Update is called once per frame
	void Update () 
	{
		//Update the text displays. 
		if(minDisplay)
		{
			minDisplay.text = min.ToString();
		}
		if(maxDisplay)
		{
			maxDisplay.text = max.ToString();
		}
		if(valDisplay)
		{
			valDisplay.text = sliderValue.ToString(roundControl);
		}
	}
	
	//Locks the mouse to the object. 
	void OnMouseDown()
	{
		if(!moving)
		{
			moving = true;
		}
	}
	
	//Bespoke click method. 
	void Clicked()
	{
		if(!moving)
		{
			moving = true; 
		}
	}
	
	
	void OnMouseUp()
	{
		moving = false; 
	}
	
	void FixedUpdate()
	{
		if(!moving)
		{
			return;
		}
		Vector3 mPos = Input.mousePosition; //Get mouse position.
		Vector3 move = Camera.main.ScreenToWorldPoint (new Vector3(mPos.x, mPos.y, Camera.main.transform.position.y));
		move.y = point.transform.position.y;
		move.z = point.transform.position.z; 
		
		point.transform.position = move; 
		point.transform.position = new Vector3(Mathf.Clamp (point.transform.position.x,minPosition.x,maxPosition.x),move.y,move.z);
						//currentLife = (currentLife - min)/(max - min);
		sliderValue = Vector3.Distance (minPosition, point.transform.position) / Vector3.Distance (minPosition,maxPosition) * max;
		//print (sliderValue);
		//sliderValue = Mathf.Round (sliderValue);
		sliderValue = Mathf.Clamp (sliderValue,min,max);
		
	}
	
}
