using UnityEngine;
using System.Collections;

public class CreateGraph : MonoBehaviour {
	
	
	public float startWidth = 0.5f; 
	public float endWidth = 0.5f;
	public int monthsToShow = 12; 
	public Material graphColour; 
	public Transform defaultPositionPoint; 
	private	GameObject dot;
	public GameObject[] dots; 
	private LineRenderer line; 
	
	private Vector3[] points; 
	
	// Use this for initialization
	void Awake () 
	{
		points = new Vector3[monthsToShow];
		//dot = 
		//dot.transform.localScale = new Vector3(startWidth,startWidth,startWidth);
		dots = new GameObject[monthsToShow];
		line = this.gameObject.AddComponent(typeof(LineRenderer)) as LineRenderer;
		line.SetWidth (startWidth,endWidth);
		line.SetVertexCount(monthsToShow);
		line.material = graphColour;
		line.transform.parent = transform;
		line.renderer.enabled = true; 
		SetDefaultPoints();
				CalculatePoints(0);
	}
	
	public void SetDefaultPoints()
	{
		float xPos = defaultPositionPoint.position.x;
		for(int i = 0; i<points.Length;i++)
		{
			Vector3 position =  new Vector3(xPos, defaultPositionPoint.position.y, defaultPositionPoint.position.z);
			points[i] = position; 
			xPos +=0.75f;
			dots[i] = GameObject.CreatePrimitive (PrimitiveType.Sphere) as GameObject;
			dots[i].transform.localScale = new Vector3(startWidth,startWidth,startWidth);
			dots[i].transform.parent = line.transform;
			dots[i].transform.position = position;
			dots[i].renderer.enabled = true;

			ToolTipC tip = dots[i].AddComponent(typeof(ToolTipC)) as ToolTipC;
			//tip.toolTipText = 
			tip.toolTipText = TimeManager.GetMonthName(i+1) + MoneyManager.profits[i];
						
		}

	}
	public void CalculatePoints(int month)
	{
			
		//print (month);
			for(int i = month; i < points.Length;i++)
		{
		//print (month);
			//print(i);
			float newYPos = (float)MoneyManager.profits[i] * 0.001f;
			Vector3 newPosition = new Vector3(points[i].x,points[i].y,points[i].z);
			newPosition.y = defaultPositionPoint.position.y + newYPos;
			//print (newYPos);
			points[i].y = newPosition.y;
			dots[i].transform.position = newPosition;
			ToolTipC tip = dots[i].GetComponent(typeof(ToolTipC)) as ToolTipC;
			//tip.toolTipText = 
			tip.toolTipText = TimeManager.GetMonthName(i+1) + MoneyManager.profits[i];
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		CalculatePoints(TimeManager.currentMonth.month - 1);
		for(int i = 0; i<points.Length;i++)
		{
			line.SetPosition (i, points[i]);
		}
		
	}
}
