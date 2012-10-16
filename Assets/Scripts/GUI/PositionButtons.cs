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
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision other)
	{
		switch(pointing)
		{
			case DIRECTION.up:
				newPosition = new Vector3(other.transform.position.x,1f,other.transform.position.z + 2f);
				break;
			case DIRECTION.down:
				newPosition = new Vector3(other.transform.position.x,1f,other.transform.position.z - 2f);
				break;
			case DIRECTION.left:
				newPosition = new Vector3(other.transform.position.x - 2f, 1f, other.transform.position.z);
				break;
			case DIRECTION.right:
				newPosition = new Vector3(other.transform.position.x + 2f, 1f, other.transform.position.z);
				break;
			default:
				newPosition = Vector3.zero; 
				break;
		}
	transform.position = newPosition; 
				
	}
}
