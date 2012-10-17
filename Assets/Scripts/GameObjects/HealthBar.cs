using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	private Vector3 defaultPosition;
	private Vector3 defaultScale; 
	
	private float currentLife; 
	private float min = 0f; 
	private float max;
	//private Vector3 newPosition;
	private BasicObject master; //= transform.parent.GetComponent(typeof(BasicObject)) as BasicObject;
	// Use this for initialization
	void Start () 
	{
		Vector3 healthBarPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		healthBarPosition.y += 0.5f;
		healthBarPosition.z += 0.35f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		BasicObject parent = transform.parent.GetComponent(typeof(BasicObject)) as BasicObject;
		currentLife = parent.life;
		max = parent.lifeSpanInSeconds;
		currentLife = (currentLife - min)/(max - min);
		print (currentLife);
		renderer.material.SetFloat ("_Progress", currentLife);
	}
}
