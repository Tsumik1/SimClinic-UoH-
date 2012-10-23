using UnityEngine;
using System.Collections;

public class CreateGraph : MonoBehaviour {
	
	
	public float startWidth = 0.5f; 
	public float endWidth = 0.5f;
	public int monthsToShow = 12; 
	public Material graphColour; 
	public Transform defaultPositionPoint; 
	
	private LineRenderer line; 
	
	private Vector3[] points; 
	
	// Use this for initialization
	void Start () 
	{
		points = new Vector3[monthsToShow];
		SetDefaultPoints();
		line = this.gameObject.AddComponent(typeof(LineRenderer)) as LineRenderer;
		line.SetWidth (startWidth,endWidth);
		line.SetVertexCount(monthsToShow);
		line.material = graphColour;
		line.renderer.enabled = true; 
	}
	
	public void SetDefaultPoints()
	{
		float xPos = defaultPositionPoint.position.x;
		for(int i = 0; i<points.Length;i++)
		{
			Vector3 position =  new Vector3(xPos, defaultPositionPoint.position.y, defaultPositionPoint.position.z);
			points[i] = position; 
			xPos +=0.5f;
		}
	}
	public void CalculatePoints()
	{
		for(int i = 0; i<points.Length;i++)
		{
			float newYPos = (float)MoneyManager.profits[i] * 0.001f;
			points[i].y = defaultPositionPoint.position.y + newYPos;
			//points[i].z = 2f;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		CalculatePoints();
		for(int i = 0; i<points.Length;i++)
		{
			line.SetPosition (i, points[i]);
		}
		
	}
}
