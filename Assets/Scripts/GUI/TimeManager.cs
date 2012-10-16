using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour 
{
	public GameObject timeDisplay; 
	
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		timeDisplay.GetComponent<TextMesh>().text = Time.time.ToString ("f1");
	}
}
