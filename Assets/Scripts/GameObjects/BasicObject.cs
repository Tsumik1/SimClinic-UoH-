using UnityEngine;
using System.Collections;

public class BasicObject : MonoBehaviour
{
		
	public string objectName;
	public string objectDescription;
	public int cost;
	public int sellValue;
	public int costPerDay;
	public int costPerMonth;
	public int repairCost;
	public int patientIncrease;
	public GameObject destruction;
	public bool isOn = false;
	public bool needsRepair = true;
	public bool degradable = false;
	public int lifeSpanInDays = 30;
	public int life;
	public GameObject buttons;
	public GameObject healthBar;
	
	private GameObject helper;
	private GameObject healthy;
	private Transform[] children;
	private bool selected = false;
	
	// Use this for initialization
	void Start ()
	{
		life = lifeSpanInDays;

		//helper.transform.position = new Vector3(transform.position.x,transform.position.y+0.6f,transform.position.z);
		//helper.transform.parent = transform;
		//children = helper.GetComponentsInChildren (typeof(Transform)) as Transform[];
		//GetComponentsInChildren(Transform); //as Transform[];
		//DisableButtons ();
		//helper.collider.enabled = true;
	}
	
	void GeneralAction ()
	{
		if (isOn) {
			
		} else if (!isOn) {
			//Might need this some time. 
		}
	}
	
	public void EnableButtons ()
	{ 
		if (buttons) {
			helper = Instantiate (buttons, transform.position, Quaternion.identity) as GameObject;
			helper.transform.parent = transform;
		}
	}
	
	public void EnableHealth ()
	{
		if (degradable) {
			if (healthBar) {
				healthy = Instantiate (healthBar, transform.position, Quaternion.identity) as GameObject;
				healthy.transform.parent = transform;
			}
		}
	}
	
	public void DisableHealth ()
	{
		if (healthy) {
			Destroy (healthy);
		}
	}
	
	public GameObject GetHealthBar()
	{
		//healthy = healthBar;
		healthy = Instantiate (healthBar, transform.position, Quaternion.identity) as GameObject;
		healthy.renderer.enabled = false;
		healthy.transform.parent = transform; 
		return healthy; 
	}
	
	public void DisableButtons ()
	{
		if (helper) {
			Destroy (helper);
		}
	}
	
	public void DestroyChildren()
	{
		if(healthy)
		{
			Destroy (healthy);
		}
		if(transform.Find("RepairButtonUI").gameObject != null)
			Destroy(transform.Find("RepairButtonUI").gameObject);
		if(transform.Find ("HealthBar").gameObject != null)
			Destroy (transform.Find ("HealthBar").gameObject);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isOn) {
			if (degradable) {
				//life -= Time.deltaTime;
				if (life <= 0) {
					if (destruction) {

						Instantiate (destruction, transform.position, Quaternion.identity);
						Destroy (gameObject);
					}
				}
			}
		}
	}
	
	public void EnableObject ()
	{
		isOn = true; 
		Destroy (helper);
		Destroy (healthy);
		selected = false;
	
	}

	public bool GetSelected ()
	{
		return selected;
	}
	
	
	public void SetSelected(bool s)
	{
		if(s)
		{
			ObjectManager.SetSelectedObject (this);
			selected = true; 
		}
		else
		{
			selected = false;
		}
	}
	
	void Clicked ()
	{
			if (isOn && ObjectPlacementManager.placing == false) {
				if (!selected) {
					DisableOthers ();
					EnableButtons ();
					EnableHealth ();
					SetSelected (true);
					
				} else {
					DisableHealth (); 
					DisableButtons ();
					SetSelected (false);
				}
			}
	}
	
	void DisableOthers()
	{
		BasicObject[] generalObjects = FindObjectsOfType (typeof(BasicObject)) as BasicObject[];
					for (int i = 0; i< generalObjects.Length; i++) {
						if (generalObjects [i].transform != transform) {
							generalObjects [i].DisableButtons (); 
							generalObjects [i].DisableHealth ();
							//Destroy (generalObjects[i].helper);	
							generalObjects [i].selected = false;
						}
					}
	}
	void OnGUI ()
	{

	}
	
	void OnDrawGizmos ()
	{

	}
	
	void OnDestroy()
	{
		if(degradable)
		{
			DegradableManager.Remove (this);
		}
	}
}
