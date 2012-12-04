using UnityEngine;
using System.Collections;
	[SerializeAll]
public class RestockButton : MonoBehaviour {

	private ReStockableObject master; 
	private bool destroyFlag = false; 
	// Use this for initialization
	void Start () 
	{
		if(transform.parent.GetComponent<ReStockableObject>())
		{
			master = transform.parent.GetComponent<ReStockableObject>();
			SetDestroyFlag(true);
		}
		else
		{
			master = ObjectManager.GetSelectedObject() as ReStockableObject;
		}
	}
	
	void SetDestroyFlag(bool b)
	{
		destroyFlag = b;
	}
	// Update is called once per frame
	void Update () {
	
	}
	
	void Clicked()
	{
		master.ReStock();
		if(destroyFlag)
		{
			Destroy (gameObject);
		}
	}
}
