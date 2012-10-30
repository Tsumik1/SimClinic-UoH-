using UnityEngine;
using System.Collections;

public class Tab : MonoBehaviour {
	
	
	public bool selected; 
	public string pageName;
	public GameObject content; 
	public Material selectedMaterial;
	public Transform contentArea; 
	public bool isDefault;
	private Material defaultMaterial;
	private Material downMaterial; 
	private Material upMaterial;
	private GameObject page;
	private ButtonBehaviour buttonControl; 
	// Use this for initialization
	void Start () 
	{
		defaultMaterial = renderer.material;
		downMaterial = selectedMaterial;
		upMaterial = defaultMaterial;
		selected = false; 
		buttonControl = gameObject.AddComponent<ButtonBehaviour>();
		buttonControl.mouseOver = selectedMaterial; 
		name = pageName;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if(selected)
		{
		    renderer.material = downMaterial;
			buttonControl.mouseOver = downMaterial;
		}
	}
	
	
	public void EnableContent()
	{
		renderer.material = selectedMaterial;
		selected = true; 
		page = Instantiate (content, contentArea.position, content.transform.rotation) as GameObject;
		page.transform.parent = transform.parent.parent;

	}
	
	public void DisableContent()
	{
		selected = false; 
		renderer.material = defaultMaterial; 
		Destroy (page);
	}
	void Clicked()
	{
		DisableContent ();
		if(!selected)
		{
			
			Tab[] tabs = FindObjectsOfType(typeof(Tab)) as Tab[];
			foreach(Tab tab in tabs)
			{
				tab.DisableContent ();
			}
			EnableContent ();
		}
	}
}
