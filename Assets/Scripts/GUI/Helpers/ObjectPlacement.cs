using UnityEngine;
using System.Collections;


/* Name: Object Placement Script 
 * Description: This script controls the movement and placement of the game objects. This class is crucial
 * to the drag and drop mentality through the game system.  
 * Author: Blake Kendrick 
 * Date: 01/10/2012
 * */
public class ObjectPlacement : MonoBehaviour 
{	
	private Transform myTransform;				// this transform
	private Vector3 destinationPosition;		// The destination Point
	private float destinationDistance;			// The distance between myTransform and destinationPosition
 	private bool validPlace = true;  			// Flag for correct placement 
	private bool isPlaced = false; 				// Flag that checks if it is placed. 
	private Color defaultColour;				// the objects default colour...NOW OBSOLETE
	private Material defaultMaterial; 		// the objects default material...NOW OBSOLETE
	private Vector3 defaultPosition;			//A deault position generated at runtime. 
	//private Component script;	
	public float moveSpeed = 10000;				//How fast the objects move to the mouse. Default value SHOULD be fine. 	
	private float height; 						//How high off the ground objects are, this can be altered to create a floating effect. 
 	
	public enum Type
	{
		equipment = 0,
		furniture = 1,
		decoration = 2,
		desk = 3,
		deskTopObject = 4,
		outdoors = 5,
	}
	
	public Type type;						//The type of object to be placed
	
	void Awake()
	{
		gameObject.StoreStandardColour();   //Store Colours 
		
		foreach(Transform child in transform)
		{
			child.gameObject.StoreStandardColour();
		}
	}
	//Initialisation 
	void Start () {
		myTransform = transform;							// sets myTransform to this GameObject.transform
		destinationPosition = myTransform.position;			// prevents myTransform reset
		defaultColour = renderer.material.color; 
		defaultMaterial = renderer.material;
		defaultPosition = transform.position;
	}
	
	public void MoveAgain() //Sets flags to move the object again. 
	{
		isPlaced = false;
		validPlace = true;
	}
 
	void Update () {
		Vector3 grounder = transform.position; //references ground. 
		BoxCollider objectCollider = GetComponent(typeof(BoxCollider)) as BoxCollider; // Gets BoxCollider attached to object. 
		float temp = 0f + objectCollider.size.z / 2f;
		grounder.y = temp; 
		transform.position = grounder; 
		
		if (Input.GetKeyDown (KeyCode.LeftShift))
		{
			Vector3 rotator = new Vector3(0,90,0);
			transform.eulerAngles += rotator;
		}
 		if(!isPlaced)
		{
			// keep track of the distance between this gameObject and destinationPosition
			destinationDistance = Vector3.Distance(destinationPosition, myTransform.position);
	 
			if(destinationDistance < .5f){		// To prevent shaking behavior when near destination
				moveSpeed = 0;
			}
			else if(destinationDistance > .5f){			// To Reset Speed to default
				moveSpeed = 100;
			}
	
				Plane playerPlane = new Plane(Vector3.up, myTransform.position);
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				float hitdist = 0.0f;
	 
				if (playerPlane.Raycast(ray, out hitdist)) {
					Vector3 targetPoint = ray.GetPoint(hitdist);
					destinationPosition = ray.GetPoint(hitdist);
					Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
				}
			if(destinationDistance > .2f){
				myTransform.position = Vector3.MoveTowards(myTransform.position, destinationPosition, (moveSpeed ) * 2);
				if(type == Type.deskTopObject)
				{
					Vector3 temps = myTransform.position;
					temps.y = height;
					myTransform.position = temps;
				}
			}
			
		if(validPlace)
			{
				ChangeColour(Color.green);
			}
		else
			{
				ChangeColour(Color.red);
			}
		}
		
		if(Input.GetMouseButtonDown(0) && validPlace)
		{
			ObjectPlacementManager.placing = false; 
			//renderer.material.color = defaultColour; 
			//renderer.material = defaultMaterial;
			//ChangeColour(Color.white);
			RevertColor();
			isPlaced = true;
			BasicObject script = GetComponent(typeof(BasicObject)) as BasicObject;
			script.EnableObject();
			AstarPath path = FindObjectOfType (typeof(AstarPath)) as AstarPath;
			path.Scan();
			script.enabled = true;
			this.enabled = false;
		}
		
		if(Input.GetMouseButtonDown (1))
		{
			ObjectPlacementManager.placing = false;
			MoneyManager.money += GetComponent<BasicObject>().cost;
			Destroy (gameObject);
		}
	}
	
	//Changes the Colour of gameObject. 
	void ChangeColour(Color col)
	{
		gameObject.ChangeColour(col);
	}
	
	
	//reverts the colour. 
	void RevertColor()
	{
		gameObject.RevertColour();
		foreach(Transform child in transform)
		{
			child.gameObject.RevertColour();
		}
	}
	
	//Checks if it's a valid place to put the object. 
	void CheckValid(Collision collision)
	{
		
		ObjectPlacement other = collision.transform.GetComponent<ObjectPlacement>() as ObjectPlacement;
		if(other)
		{
		switch(type)
		{
		case Type.furniture:
			validPlace = false;
			break;
		case Type.decoration:
			validPlace = false;
			break;
			
		case Type.outdoors:
			validPlace = false;
			break;
			
		case Type.equipment:
			validPlace = false;
			break;
				
		case Type.desk:
			validPlace = false;
			break;
			
		case Type.deskTopObject:
			if(other.type == Type.desk)
			{
				validPlace = true;
				PlaceToTopOfObject(collision);
				break;
			}
			else
			{
				validPlace = false;
				break;
			}
			break;
		default: 
			validPlace = false;
			break;
		}
		}
		else validPlace = false;
	}
	
	
	//Moves the object to the top of the collision. 
	void PlaceToTopOfObject(Collision collision)
	{
		BoxCollider collider = collision.gameObject.GetComponent<BoxCollider>();
		Vector3 temp = collision.transform.position;
		
		temp.y = collision.gameObject.GetComponent<BoxCollider>().transform.position.y + collider.size.z;
		height = temp.y;
	}
	
	
	//Collision Checks, pass through to the Validty check to ensure they are valid collisions. 
	void OnCollisionEnter(Collision collision)
	{ 
		CheckValid (collision);
	}
	 
	void OnCollisionStay(Collision collision)
	{
		CheckValid (collision);
	}
	
	void OnCollisionExit(Collision collision) {

			validPlace = true;
    }
	
	
	//Invalid Location...
	public void InvalidLocation(bool valid)
	{
		print("GOT HERE");
		validPlace = valid; 
	}
}