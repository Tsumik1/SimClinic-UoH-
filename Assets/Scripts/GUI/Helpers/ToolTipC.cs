using UnityEngine;
using System.Collections;

public class ToolTipC : MonoBehaviour {
	
	public string toolTipText = ""; // set this in the Inspector

	private string currentToolTipText = "";
	private GUIStyle guiStyleFore;
	private GUIStyle guiStyleBack;

	// Use this for initialization
	void Start () 
	{
		  guiStyleFore = new GUIStyle();
	    guiStyleFore.normal.textColor = Color.white;  
	    guiStyleFore.alignment = TextAnchor.UpperCenter ;
	    guiStyleFore.wordWrap = true;
	    guiStyleBack = new GUIStyle();
	    guiStyleBack.normal.textColor = Color.black;  
	    guiStyleBack.alignment = TextAnchor.UpperCenter ;
	    guiStyleBack.wordWrap = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseEnter()
	{
		currentToolTipText = toolTipText;
	}
	
	void OnMouseExit()
	{
		currentToolTipText = "";
	}
	
	void OnGUI()
	{
		float x = Event.current.mousePosition.x;
        float y = Event.current.mousePosition.y;
        GUI.Label (new Rect (x-149,y-21,300,60), currentToolTipText, guiStyleBack);
        GUI.Label (new Rect (x-150,y-20,300,60), currentToolTipText, guiStyleFore);
	}
}
