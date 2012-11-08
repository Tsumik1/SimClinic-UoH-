using UnityEngine;
using System.Collections;

public class ObjectColours : MonoBehaviour {
	
	public Material validMaterial; 
	public Material invalidMaterial; 
	
	public static Material valid; 
	public static Material invalid; 
	
	// Use this for initialization
	void Awake () 
	{
		if(validMaterial)
		{
			valid = validMaterial;
		}
		if(invalidMaterial)
		{
			invalid = invalidMaterial;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
