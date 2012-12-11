using UnityEngine;
using System.Collections;

public class LoadGame : MonoBehaviour {
	
	
	public int slotNumber;
	public TextMesh text;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(slotNumber < LevelSerializer.SavedGames[LevelSerializer.PlayerName].Count)
		{
			if(LevelSerializer.SavedGames[LevelSerializer.PlayerName][slotNumber] != null)
				text.text = LevelSerializer.SavedGames[LevelSerializer.PlayerName][slotNumber].Caption;
		}
		else
		{
			text.text = "-Empty Slot :(-";
		}

	}
	
	void Clicked()
	{
		LevelSerializer.SavedGames[LevelSerializer.PlayerName][slotNumber].Load ();
	}
}
