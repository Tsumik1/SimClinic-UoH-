using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
	
	public bool needsPositioning = true; 
	public bool satisfaction= false;
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
		if(needsPositioning)
		{
		float colliderScaleY = transform.parent.transform.lossyScale.y/2;
		float colliderPositionY = transform.parent.transform.position.y; 
		
		colliderPositionY += colliderScaleY;
		
		float spawnObjectScaleY = transform.lossyScale.y /2 ;
		
		spawnObjectScaleY += colliderPositionY;
		
		Vector3 healthBarPosition = new Vector3(transform.position.x, spawnObjectScaleY, transform.position.z);
		//healthBarPosition.y -= 0.5f;
		//healthBarPosition.z += 0.35f;
		
		transform.position = healthBarPosition;
		//transform.Rotate(0,90,0, Space.Self);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!satisfaction)
		{
			BasicObject theMaster = ObjectManager.GetSelectedObject ();
			if(theMaster)
			{
				currentLife = theMaster.life;
				max = (float)theMaster.lifeSpanInDays;
				currentLife = (currentLife - min)/(max - min);
				//print(currentLife);
				//print (currentLife);
				renderer.material.SetFloat ("_Progress", currentLife);
			}
		}
		else
		{
			renderer.material.SetFloat ("_Progress", (PatientManager.patientSatisfaction - min)/(100-0));
		}

	}
}
