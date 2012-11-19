using UnityEngine;
using System.Collections;

public class Helper : MonoBehaviour {
	
	
	private static NameGenerator nameGen; 
	
	static void Awake () 
	{
		nameGen = new NameGenerator();
	}
	
	public static bool RandomBool()
	{
		int flag = Random.Range (0,1);
		if(flag == 0)
		{
			return false;
		}
		if(flag == 1)
		{
			return true;
		}
		else
		{
			return false;
		}
		return false;
	}
	
	public static string GenerateName(bool gender, int length)
	{
		nameGen = new NameGenerator();
		return nameGen.CreateName(gender, length);
	}
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
	
	}
}
