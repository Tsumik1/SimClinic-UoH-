using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {

	
	public string lvl;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Clicked()
	{
		if(!string.IsNullOrEmpty (lvl))
		{
			Application.LoadLevel (lvl);
		}
	}
}
