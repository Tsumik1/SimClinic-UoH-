using UnityEngine;
using System.Collections;
public class EffectsManager : MonoBehaviour {
	
	public GameObject capacityFullEffect;
	public GameObject degradedExplosionEffect; 
	public GameObject capacityEmptyEffect;
	public GameObject restockEffect;
	
	public static GameObject degradedExplosion;
	public static GameObject capacityFull;
	public static GameObject capacityEmpty;
	public static GameObject restock; 
	// Use this for initialization
	void Start () 
	{
		capacityFull = capacityFullEffect;
		degradedExplosion = degradedExplosionEffect;
		capacityEmpty = capacityEmptyEffect;
		restock = restockEffect;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
