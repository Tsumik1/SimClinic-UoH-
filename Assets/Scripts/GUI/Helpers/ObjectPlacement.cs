/* 
 * Esse Script movimenta o GameObject quando você clica ou
 * mantém o botão esquerdo do mouse apertado.
 * 
 * Para usá-lo, adicione esse script ao gameObject que você quer mover
 * seja o Player ou outro
 * 
 * Autor: Vinicius Rezendrix - Brasil
 * Data: 11/08/2012
 * 
 * This script moves the GameObeject when you
 * click or click and hold the LeftMouseButton
 * 
 * Simply attach it to the gameObject you wanna move (player or not)
 * 
 * Autor: Vinicius Rezendrix - Brazil
 * Data: 11/08/2012 
 *
 */
 
using UnityEngine;
using System.Collections;
 
public class ObjectPlacement : MonoBehaviour {
	private Transform myTransform;				// this transform
	private Vector3 destinationPosition;		// The destination Point
	private float destinationDistance;			// The distance between myTransform and destinationPosition
 	private bool validPlace = true; 
	private bool isPlaced = false; 
	private Color defaultColour;
	private Material defaultMaterial; 
	private Vector3 defaultPosition;
	//private Component script;
	public float moveSpeed = 10000;	
	private float height; 
 	
	public enum Type
	{
		equipment = 0,
		furniture = 1,
		decoration = 2,
		desk = 3,
		deskTopObject = 4,
		outdoors = 5,
		
	}
	
	public Type type;
	
 
 
	void Start () {
		myTransform = transform;							// sets myTransform to this GameObject.transform
		destinationPosition = myTransform.position;			// prevents myTransform reset
		defaultColour = renderer.material.color; 
		defaultMaterial = renderer.material;
		defaultPosition = transform.position;
		
	}
	
	public void MoveAgain()
	{
		isPlaced = false;
		validPlace = true;
	}
 
	void Update () {
		Vector3 grounder = transform.position;
		BoxCollider objectCollider = GetComponent(typeof(BoxCollider)) as BoxCollider;
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
			 // renderer.material.color = Color.green; 
				renderer.material = ObjectColours.valid;
				if(renderer.materials.Length > 1)
				{
					renderer.materials[1] = ObjectColours.valid;
				}
			}
		else
			{
				//renderer.material.color = Color.red; 
				renderer.material = ObjectColours.invalid;
				if(renderer.materials.Length > 1)
				{
					renderer.materials[1] = ObjectColours.invalid;
				}
			}
		}
		
		if(Input.GetMouseButtonDown(0) && validPlace)
		{
			ObjectPlacementManager.placing = false; 
			//renderer.material.color = defaultColour; 
			renderer.material = defaultMaterial;
			isPlaced = true;
			BasicObject script = GetComponent(typeof(BasicObject)) as BasicObject;
			script.EnableObject();
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
	
	void PlaceToTopOfObject(Collision collision)
	{
		BoxCollider collider = collision.gameObject.GetComponent<BoxCollider>();
		Vector3 temp = collision.transform.position;
		
		temp.y = collision.gameObject.GetComponent<BoxCollider>().transform.position.y + collider.size.z;
		height = temp.y;
	}
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
	
	public void InvalidLocation(bool valid)
	{
		print("GOT HERE");
		validPlace = valid; 
	}
}