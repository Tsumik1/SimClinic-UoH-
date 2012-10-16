using UnityEngine;
using System.Collections;

public class ButtonBehaviour : MonoBehaviour {

	
	public Material mouseOver; 
	
	private Material standard; 
	// Use this for initialization
	void Start () 
	{
		standard = renderer.material; 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	public void OnMouseEnter ()
	{
 		renderer.material = mouseOver; 
	}

	public void OnMouseExit ()
	{
    	renderer.material = standard; 
	}

}
