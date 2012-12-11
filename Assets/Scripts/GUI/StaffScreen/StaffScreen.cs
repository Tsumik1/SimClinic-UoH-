using UnityEngine;
using System.Collections;

public class StaffScreen : MonoBehaviour {
	
	
	public GameObject practice;
	public GameObject reception; 
	public GameObject garden;
	public GameObject care;
	public GameObject hireButton; 
	public GameObject fireButton; 
	public GameObject pSalary;
	public GameObject rSalary; 
	public GameObject gSalary; 
	public GameObject cSalary; 
	
	public GameObject[] headers; 
	
	private GameObject pHire;
	private GameObject rHire;
	private GameObject gHire;
	private GameObject cHire;
	
	private GameObject pFire;
	private GameObject rFire; 
	private GameObject gFire; 
	private GameObject cFire;
	// Use this for initialization
	void Start () 
	{
		practice.GetComponent<TextMesh>().text = "";
		reception.GetComponent<TextMesh>().text = "";
		garden.GetComponent<TextMesh>().text = "";
		care.GetComponent<TextMesh>().text = "";
		pSalary.GetComponent<TextMesh>().text = "";
		rSalary.GetComponent<TextMesh>().text = "";
		gSalary.GetComponent<TextMesh>().text = "";
		cSalary.GetComponent<TextMesh>().text = "";
		StaffDetail(practice,Staff.Role.practitioner,pHire,pFire,pSalary);
		StaffDetail(reception,Staff.Role.receptionist,rHire,rFire,rSalary);
		StaffDetail (garden,Staff.Role.gardener, gHire, gFire, gSalary);
		StaffDetail(care,Staff.Role.caretaker,cHire,cFire,cSalary);
	}
	
	// Update is called once per frame
	void Update () 
	{
				DestroyAll ();
		StaffDetail(practice,Staff.Role.practitioner,pHire,pFire,pSalary);
		StaffDetail(reception,Staff.Role.receptionist,rHire,rFire,rSalary);
		StaffDetail (garden,Staff.Role.gardener, gHire, gFire, gSalary);
		StaffDetail(care,Staff.Role.caretaker,cHire,cFire,cSalary);
	}
	
	public void Refresh()
	{

	}
	
	void DestroyAll()
	{
		practice.GetComponent<TextMesh>().text = "";
		reception.GetComponent<TextMesh>().text = "";
		garden.GetComponent<TextMesh>().text = "";
		care.GetComponent<TextMesh>().text = "";
		pSalary.GetComponent<TextMesh>().text = "";
		rSalary.GetComponent<TextMesh>().text = "";
		gSalary.GetComponent<TextMesh>().text = "";
		cSalary.GetComponent<TextMesh>().text = "";
		foreach(HireButton h in FindObjectsOfType(typeof(HireButton)))
		{
			Destroy(h.gameObject);
		}
		foreach(FireButton f in FindObjectsOfType(typeof(FireButton)))
		{
			Destroy(f.gameObject);
		}
	}
	void StaffDetail(GameObject nameField, Staff.Role role, GameObject hire, GameObject fire, GameObject salary)
	{
		if(StaffManager.StaffHired (role))
		{
			Staff s = StaffManager.GetStaff(role);
			nameField.GetComponent<TextMesh>().text = s.staffName; 
			if(fireButton)
			{
				if(!fire)
				{
					fire = Instantiate (fireButton, headers[2].transform.position, transform.rotation) as GameObject;
					fire.GetComponent<FireButton>().staffMember = s;
					Vector3 newPos = nameField.transform.position;
					newPos.x = headers[2].transform.position.x + .6f;
					newPos.z = headers[2].transform.position.z - 1f;
					newPos.y = nameField.transform.position.y - .3f;
					fire.transform.position = newPos;
					fire.transform.parent = transform;
				}
			}
			salary.GetComponent<TextMesh>().text = s.salary.ToString();
			
		}
		else
		{
			nameField.GetComponent<TextMesh>().text = "";
			if(!hire)
			{
							hire = Instantiate (hireButton,nameField.transform.position, transform.rotation) as GameObject;
			hire.GetComponent<HireButton>().role = role;
			Vector3 newPos = nameField.transform.position;
			newPos.x = headers[1].transform.position.x + .6f;
			newPos.z = headers[1].transform.position.z - 1f;
			newPos.y = nameField.transform.position.y - .3f;
			hire.transform.position = newPos;
			hire.transform.parent = transform;
			}

		}
	}
}
