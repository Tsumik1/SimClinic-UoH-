using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class CreateTable : MonoBehaviour
{
	
	
	public BasicObject[] basicObjects;
	public List<BasicObject> degradableObjects;
	public GameObject button;
	public GameObject startTextPlace;
	public int numberOfColumns;
	public float columnSize;
	public float rowSize;
	public float currentRow;
	public Transform startPosition;
	private List<TableRow> rows;
	public TableRow[] rowArray;
	private List<float> column;
	private List<float> row;
	
	
	public class TableRow
	{
		//public GameObject blank; 
		public GameObject name;
		public GameObject life;
		public GameObject repairCost;
		public GameObject repairButton;
		public GameObject panel;
		//public int rowNumber;
		
		
		private BasicObject actualObject;
		
		public TableRow (string newName, GameObject health, string cost, GameObject button, BasicObject theObject, GameObject textStart, GameObject panelA)
		{
			panel = panelA;
			name = Instantiate (textStart, panel.transform.position, Quaternion.identity) as GameObject;
			name.GetComponent<TextMesh> ().text = newName;
			name.transform.parent = panel.transform;
			if(health)
			{
				life = Instantiate(health, panel.transform.position, Quaternion.identity) as GameObject;
				life.GetComponent<HealthBar> ().needsPositioning = false;
				life.name = "HealthBar";
				life.layer = 10;
			}
			repairCost = Instantiate (textStart, panel.transform.position, Quaternion.identity) as GameObject;
			repairCost.GetComponent<TextMesh> ().text = cost; 
			repairCost.gameObject.transform.parent = panel.transform;
			repairButton = Instantiate (button, panel.transform.position, Quaternion.identity) as GameObject;
			repairButton.gameObject.transform.parent = panel.transform;
			repairButton.name = "RepairButtonUI";
			actualObject = theObject;
			repairButton.layer = 10;
		}
		
		public void PlaceRow (Vector3 position, float columnSize)
		{

			name.transform.position = position; 
			name.renderer.enabled = true; 
						float nextX = name.transform.position.x;
			print(nextX);
			if(life)
			{
				life.transform.position = new Vector3 (nextX + columnSize, name.transform.position.y, name.transform.position.z);
				life.renderer.enabled = true; 
				nextX = life.transform.position.x;
			}
			else
			{
				nextX += columnSize;
				print(nextX);
			}
			repairCost.transform.position = new Vector3 (nextX + columnSize, name.transform.position.y, name.transform.position.z);
			nextX = repairCost.transform.position.x;
			print(nextX);
			repairCost.renderer.enabled = true; 
			repairButton.transform.position = new Vector3 (nextX + columnSize, name.transform.position.y, name.transform.position.z);
			Vector3 temp = new Vector3 (panel.transform.position.x, panel.transform.position.y, panel.transform.position.z);
			panel.transform.position = temp;
			repairButton.transform.parent = actualObject.transform;
			if(life)
			{
				life.transform.parent = actualObject.transform;
			life.transform.Rotate(new Vector3(-90,0,0));
			}
			repairButton.transform.Rotate (new Vector3(-90,0,0));
		}
		public void DestroyAssets ()
		{
			if(actualObject != null)
			{actualObject.DestroyChildren();}
			Destroy (name);
			if(life)
			{
				Destroy (life);
			}
			Destroy (repairCost);
			Destroy (repairButton);
		}
		
	}
	// Use this for initialization
	void Start ()
	{

		column = new List<float> ();
		row = new List<float> ();
		rows = new List<TableRow> ();
		column.Add (startPosition.position.x);
		for (int i = 1; i<=numberOfColumns; i++) {
			float temp = column [i - 1]; 
			temp += columnSize;
			column.Add (temp);
		}
		row.Add (startPosition.position.y);
		currentRow = startPosition.position.y;
		
	}
	
	void AddRow ()
	{
		currentRow += rowSize;
		row.Add (currentRow);
	}
	
	// Update is called once per frame
	void Update ()
	{

	}
	
	void OnEnable ()
	{
		degradableObjects = DegradableManager.GetList ();
		if (degradableObjects != null) {
			rowArray = new TableRow[degradableObjects.Count];
			Vector3 currentRow = startPosition.position;
			currentRow.y += rowSize;
			for (int i = 0; i<degradableObjects.Count; i++) {
				TableRow tempRow = new TableRow (degradableObjects [i].objectName, degradableObjects [i].GetHealthBar (),
							degradableObjects [i].repairCost.ToString (), button, degradableObjects [i], startTextPlace, this.gameObject);
				rowArray [i] = tempRow;
				rowArray [i].PlaceRow (currentRow, columnSize);
				currentRow.y += rowSize; 
			}
		}

	}
	
	void OnDisable ()
	{
		print ("Got this far");
			for (int i = 0; i<rowArray.Length; i++) {
				if (rowArray [i] != null) 
				{
					rowArray [i].DestroyAssets (); 	
				}
			}
		

	}
	
}
