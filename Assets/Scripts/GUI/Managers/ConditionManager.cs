using UnityEngine;
using System.Collections;

public class ConditionManager : MonoBehaviour {
	
	
	public double minimumConditionCost;
	public double maxConditionCost;
	
	public static double minCost; 
	public static double maxCost; 
	
	// Use this for initialization
	void Start () 
	{
		minCost = minimumConditionCost;
		maxCost = maxConditionCost;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
