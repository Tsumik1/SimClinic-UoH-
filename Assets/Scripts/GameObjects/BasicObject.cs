using UnityEngine;
using System.Collections;

public class BasicObject : MonoBehaviour {
		
	public string objectName; 
	public string objectDescription; 
	public int cost; 
	public int sellValue;  
	public int costPerDay; 
	public int repairCost; 
	public int patientIncrease; 
	
	public GameObject destruction;
	
	public bool isOn = false; 
	public bool selected = false;
	public bool needsRepair = true; 
	public bool degradable = false; 
	
	public float lifeSpanInSeconds = 1000f; 
	public float life; 
	
	public GameObject buttons; 
	public GameObject healthBar;
	
	private GameObject helper; 
	private GameObject healthy; 
	
	private Transform[] children;
	// Use this for initialization
	void Start () 
	{
		life = lifeSpanInSeconds;

		//helper.transform.position = new Vector3(transform.position.x,transform.position.y+0.6f,transform.position.z);
		//helper.transform.parent = transform;
		//children = helper.GetComponentsInChildren (typeof(Transform)) as Transform[];
			//GetComponentsInChildren(Transform); //as Transform[];
		//DisableButtons ();
		//helper.collider.enabled = true;
	}
	
	void GeneralAction()
	{
		if(isOn)
		{
			
		}

		else if(!isOn)
		{
			//Might need this some time. 
		}
	}
	
	public void EnableButtons()
	{ 
		
		helper = Instantiate (buttons, transform.position, Quaternion.identity) as GameObject;
		helper.transform.parent = transform;
	}
	
	
	
	public void EnableHealth()
	{
		if(healthBar)
		{
			healthy = Instantiate (healthBar,transform.position,Quaternion.identity) as GameObject;
			healthy.transform.parent = transform;
			
		}
	}
	
	public void DisableHealth()
	{
		if(healthy)
		{
			Destroy (healthy);
		}
	}
	
	
	public void DisableButtons()
	{
		if(helper)
			{
				Destroy (helper);
			}
	}
	
	
	// Update is called once per frame
	void Update () 
	{
		if(isOn)
		{
			if(degradable)
			{
				life -= Time.deltaTime;
				if(life <= 0)
				{
					if(destruction)
					{

						Instantiate (destruction,transform.position,Quaternion.identity);
						Destroy (gameObject);
					}
				}
			}
		}
	}
	
	public void EnableObject()
	{
		isOn = true; 
		Destroy (helper);
		Destroy (healthy);
		selected = false;
	
	}
	public bool GetSelected()
	{
		return selected;
	}
	
	void Clicked()
	{
		if(!selected)
		{
			BasicObject[] generalObjects = FindObjectsOfType (typeof(BasicObject)) as BasicObject[];
			
				for(int i = 0; i< generalObjects.Length;i++)
				{
					if(generalObjects[i].transform != transform)
					{
						generalObjects[i].DisableButtons(); 
						generalObjects[i].DisableHealth ();
						//Destroy (generalObjects[i].helper);	
						generalObjects[i].selected = false;
					}
				}
			EnableButtons ();
			EnableHealth ();
			ObjectManager.SetSelectedObject (this);
				selected = true; 
		}
		else
		{
			DisableHealth (); 
			DisableButtons ();
			selected = false; 
		}
		
		
		
	}
	
void OnGUI()
{

}
	
void OnDrawGizmos() {

}

}
