using UnityEngine;
using System.Collections;


public class CheckFields : MonoBehaviour {
	
	
	public TextBox[] fieldsToCheck;
	public bool valid; 
	
	public GameObject message;
	
	private GotoOptions gto;
	// Use this for initialization
	void Start () 
	{
		if(!message)
		{
			message = Resources.Load ("DefaultText") as GameObject;
		}
		valid = false; 
		gto = GetComponent<GotoOptions>();	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void Clicked()
	{
		if(fieldsToCheck.Length > 0)
		{
			valid = true; 
			foreach(TextBox tb in fieldsToCheck)
			{
				if(tb.text == "" || tb.text == "|")
				{
					valid = false; 
					Vector3 newPosition = tb.transform.position; 
					newPosition.x += tb.GetComponent<BoxCollider>().size.x /4f;
					Instantiate (message, newPosition, message.transform.rotation);
				}
			}
		}
		if(valid)
		{
			print ("HIT!");
			gto.enabled = true;
			gto.active = true;
			gto.Invoke ("Clicked",0f);
		}
		else
		{
			
		}
	}
}
