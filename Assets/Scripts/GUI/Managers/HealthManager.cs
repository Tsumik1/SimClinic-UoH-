using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour {
	public int initialHealth; 
	public GameObject healthDisplay; 
	
	public static int health; 
	// Use this for initialization
	void Start () 
	{
		health = initialHealth;
	}
	
	// Update is called once per frame
	void Update () 
	{
		healthDisplay.GetComponent<TextMesh>().text = health.ToString();
		
		if(health <= 0 )
		{
			Application.LoadLevel ("GameOver");
		}
	}
}
