using UnityEngine;
using System.Collections;

public class PositionButtons : MonoBehaviour {
	
	
	
	public enum DIRECTION
	{
		up = 0,
		down = 1,
		right = 2,
		left = 3, 
	}
	
	public DIRECTION pointing;
	
	private Vector3 newPosition; 
	private BoxCollider col;
	// Use this for initialization
	void Start () {
					col = transform.parent.parent.GetComponent(typeof(BoxCollider)) as BoxCollider; 
				switch(pointing)
		{
			case DIRECTION.up:
				Vector3 upPosition = new Vector3(transform.parent.position.x, 1f,transform.parent.position.z);
				upPosition.z += col.size.y/2f +0.4f;
				newPosition = upPosition;
				break;
			case DIRECTION.down:
				Vector3 downPosition = new Vector3(transform.parent.position.x, 1f,transform.parent.position.z);
				downPosition.z -= col.size.y/2 + 0.8f;
				newPosition = downPosition;
				break;
			case DIRECTION.left:
				Vector3 leftPosition = new Vector3(transform.parent.position.x - 0.8f, 1f,col.transform.position.z);
				leftPosition.x -= col.size.x/2;
				newPosition = leftPosition;
				//newPosition = new Vector3(col.transform.position.x - 2f, 1f, col.transform.position.z);
				break;
			case DIRECTION.right:
				Vector3 rightPosition = new Vector3(transform.parent.position.x + 0.8f, 1f,col.transform.position.z);
				rightPosition.x += col.size.x/2;
				newPosition = rightPosition;
				//newPosition = new Vector3(col.transform.position.x + 2f, 1f, col.transform.position.z);
				break;
			default:
				newPosition = Vector3.zero; 
				break;
		}
			transform.position = newPosition; 

	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	
	void OnCollisionEnter(Collision other)
	{

				
	}
}
