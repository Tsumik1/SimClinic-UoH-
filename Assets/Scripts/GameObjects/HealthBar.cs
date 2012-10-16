using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
	
	
	
	
	private Vector3 defaultPosition;
	private Vector3 defaultScale; 
	private Vector3 newPosition;
	private BasicObject master; //= transform.parent.GetComponent(typeof(BasicObject)) as BasicObject;
	// Use this for initialization
	void Start () {
		master = transform.parent.GetComponent(typeof(BasicObject)) as BasicObject;
		defaultPosition = transform.parent.transform.position;
		defaultPosition.y += 1f;
		defaultScale = transform.localScale;
		newPosition = new Vector3(transform.position.x, transform.position.y,transform.position.z);
		newPosition.x -= 0.5f;

	}
	
	// Update is called once per frame
	void Update () 
	{
 				transform.position = Vector3.Lerp (transform.position, newPosition, master.lifeSpanInSeconds) * Time.deltaTime;
		transform.localScale = Vector3.Lerp (transform.localScale, new Vector3(transform.localScale.x,transform.localScale.y,0),master.lifeSpanInSeconds * Time.deltaTime);

	}
	
	public void ResetHealthBar()
	{
		transform.position = defaultPosition;
		transform.localScale = defaultScale; 
	}
}
