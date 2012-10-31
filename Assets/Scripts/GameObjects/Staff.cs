using UnityEngine;
using System.Collections;

public class Staff : MonoBehaviour {
	
	
	public enum Role
	{
		receptionist,
		caretaker,
		cleaner,
		gardener,
	}
	
	public Role role;
	public string staffName;
	public int salary;
	
	
	
	private NameGenerator nameGenerator;
	// Use this for initialization
	void Start () {
				nameGenerator = new NameGenerator();
		GenerateName();
		
	}
	
	
	void GenerateName()
	{
		if(name == "")
		{
			name = nameGenerator.GenerateName ();
		}
		
	}
	// Update is called once per frame
	void Update () {
	
	}
}
