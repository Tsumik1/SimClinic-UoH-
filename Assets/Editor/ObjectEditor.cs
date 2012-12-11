using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
public class ObjectEditor : ScriptableWizard {
	
	
	public enum Menu
	{
		equip,
		furn,
	}
	
	public enum ObjectType
	{
		basic,
		equipment,
		restock,
	}
	
	public Menu menu; 
	public ObjectType type  = ObjectType.basic;
	public string objectName;
	public string description;
	public BasicObject.Quality quality;
	
	public double cost;
	public double sellValue;
	public double dailyCost; 
	public double monthlyCost; 
	public double repairCost;
	public double restockCost; 
	
	public int lifeSpan;
	public int patientIncrease;
	public int capacity; 
	public int maxLevel = 4;
	public int increment = 10;
	
	public bool degradable = false;
	public bool stockable = false;
	public bool shop = false;
	public bool restockable = false;
	public bool overide = false; 
	public bool valid = false; 
	public GameObject buttons = Resources.Load ("ObjectButtons") as GameObject;
	public GameObject healthBar = Resources.Load ("HealthBar") as GameObject;
	public GameObject destruction = Resources.Load ("Detonator-Simple") as GameObject; 
	public GameObject storageSpace = Resources.Load ("DefaultStorageSpace") as GameObject;
	public GameObject model;
	public GameObject defaultIcon = Resources.Load ("DefaultIcon") as GameObject;
	public GameObject empty;
	public GameObject mid; 
	public GameObject full;
	public GameObject created; 
	
	public Material mat;  
	public Texture icon;
	
	public string defaultPath = "Assets/Prefabs/";
	
	
	
	    static Camera cam;
    static Camera lastUsedCam;
	
	[MenuItem("SimClinic/New Item %q" , false, 1) ]
    static void CreateWizard()
    {
        cam = Camera.current;
        // Hack because camera.current doesn't return editor camera if scene view doesn't have focus
        if (!cam)
            cam = lastUsedCam;
        else
            lastUsedCam = cam;
        ScriptableWizard.DisplayWizard("New BasicObject",typeof(ObjectEditor));
    }
	
	// Use this for initialization
	void OnWizardUpdate()
    {
        //widthSegments = Mathf.Clamp(widthSegments, 1, 254);
        //lengthSegments = Mathf.Clamp(lengthSegments, 1, 254);
		
    }
	void Start () 
	{
		
	}
	
	void OnGUI()
	{
		EditorGUILayout.LabelField("Create New Object:" ,objectName);
		GUIContent menuLabel = new GUIContent("Build Menu: ", "Select which menu the object will be placed");
		menu = (Menu)EditorGUILayout.EnumPopup(menuLabel, menu);
		type = (ObjectType)EditorGUILayout.EnumPopup("Object Type: ",type);
		GUIContent nameLabel = new GUIContent("Name: ", "Name the object.");
		objectName = EditorGUILayout.TextField (nameLabel,objectName);
		GUIContent descLabel = new GUIContent("Description: ", "A brief description of the object and its purpose. ");
		description = EditorGUILayout.TextField (descLabel, description, GUILayout.Height (100));
		quality = (BasicObject.Quality)EditorGUILayout.EnumPopup ("Quality: ",quality);
		GUIContent costLabel =  new GUIContent("Cost: ", "How much the item is to buy.");
		cost = (double)EditorGUILayout.FloatField(costLabel, (float)cost);
		GUIContent sellLabel = new GUIContent("Sell Value: ", "How much the item is worth to sell.");
		sellValue = (double)EditorGUILayout.FloatField (sellLabel, (float)sellValue);
		GUIContent dailyLabel = new GUIContent("Daily Cost: ", "(Optional)How much the item costs per day.");
		dailyCost = (double)EditorGUILayout.FloatField(dailyLabel, (float)dailyCost);
		GUIContent monthLabel = new GUIContent("Monthly Cost: ", "How much the item costs per month.");
		monthlyCost = (double)EditorGUILayout.FloatField(monthLabel,(float)monthlyCost);
		GUIContent patientLabel = new GUIContent("Patient Increase: ", "How mucht his item could increase patients per month.");
		patientIncrease = EditorGUILayout.IntField (patientLabel, patientIncrease);
		GUIContent degradeLabel = new GUIContent("Needs Repair: ", "Dictates if the item can be destroyed by wear and tear.");
		degradable = EditorGUILayout.Toggle(degradeLabel, degradable);
		if(degradable)
		{
			GUIContent lifeSpanLabel = new GUIContent("Life Span(Days): ", "How long the item lasts in days.");
			lifeSpan = EditorGUILayout.IntField (lifeSpanLabel, lifeSpan);
			GUIContent repairCostLabel = new GUIContent("Repair Cost: ", "The cost of repair.");
			repairCost = (double)EditorGUILayout.FloatField (repairCostLabel, (float)repairCost);
		}
		if(type == ObjectType.restock)
		{
			GUIContent maxLevelLabel = new GUIContent("Max Stock Level: ", "Dictates the maximum level of stock.");
			maxLevel = (int)EditorGUILayout.Slider(maxLevelLabel,(float)maxLevel,1,4);
			GUIContent timeLabel = new GUIContent("Stock Decrease Interval: ", "Dictate the amount of time(in days) till the stock level drops.");
			increment = EditorGUILayout.IntField(timeLabel,increment);
			GUIContent restockCostLabel = new GUIContent("Restock Cost: ", "The cost of restocking the object");
			restockCost = (double)EditorGUILayout.FloatField(restockCostLabel,(float)restockCost);
			GUIContent emptyLabel = new GUIContent("Empty Model: ", "Empty model, placed on top of root mesh.");
			empty = (GameObject)EditorGUILayout.ObjectField(emptyLabel, empty, typeof(GameObject));
			GUIContent midLabel = new GUIContent("In Between Model: ", "A middle stock level model.");
			mid = (GameObject)EditorGUILayout.ObjectField (midLabel,mid,typeof(GameObject));
			GUIContent fullLabel = new GUIContent("Full Model: ","The full stock model.");
			full = (GameObject)EditorGUILayout.ObjectField(fullLabel,full, typeof(GameObject));
		}
		if(type == ObjectType.equipment)
		{
			GUIContent capacityLabel = new GUIContent("Capacity","How many items the item can hold.");
			capacity = EditorGUILayout.IntField (capacityLabel, capacity);
		}
		GUIContent overideLabel = new GUIContent("Overide Behaviour: ", "Overide the behaviour such as buttons etc.");
		overide = EditorGUILayout.Toggle (overideLabel, overide);
		if(overide)
		{
			GUIContent buttonLabel =  new GUIContent("Buttons: ", "The buttons that appear on an item, default to the buttons resource.");
			buttons = (GameObject)EditorGUILayout.ObjectField (buttonLabel,buttons, typeof(GameObject));
			GUIContent healthLabel = new GUIContent("Health Bar: ", "Change the default health bar.");
			healthBar = (GameObject)EditorGUILayout.ObjectField(healthLabel,healthBar, typeof(GameObject));
			GUIContent destructionLabel = new GUIContent("Destruction: ", "Change the default destruction effect.");
			destruction = (GameObject)EditorGUILayout.ObjectField(destructionLabel, destruction, typeof(GameObject));
		}
		
		GUIContent modelLabel = new GUIContent("Model: ", "The mesh to be rendered.");
		model = (GameObject)EditorGUILayout.ObjectField(modelLabel, model, typeof(GameObject));
		GUIContent matLabel = new GUIContent("Material: ", "If the material needs to be altered.");
		mat = (Material)EditorGUILayout.ObjectField(matLabel, mat, typeof(Material));
		GUIContent iconLabel = new GUIContent("Icon: ", "Icon Image");
		icon = (Texture)EditorGUILayout.ObjectField(iconLabel, icon, typeof(Texture));
		GUILayout.Space (20);
		GUIContent createLabel = new GUIContent("Create", "Create the object.");
		GUI.enabled = valid;
		if(GUILayout.Button (createLabel))
		{
			Debug.Log ("Button Pressed!");
			Debug.Log (valid);
			CheckValid ();
			Debug.Log (valid);
			if(valid)
			{
				CreateItem ();
			}
			else
			{
				EditorGUILayout.LabelField(CheckValid());
			}
		}
		if(!valid)
		{
			GUI.enabled = true;
			EditorGUILayout.LabelField(CheckValid());
		}
		CheckValid ();
	}
	
	string CheckValid()
	{
		if(objectName == null || objectName == "")
		{
			valid = false;
			return("Please enter a name for the object.");
		}
		if(description == null || description == "")
		{
			valid = false;
			return("Object needs a description.");
		}
		if(cost == null || cost <= 0)
		{
			valid = false; 
			return("Please enter a valid cost.");
		}
		if(sellValue == null || sellValue <= 0)
		{
			valid = true;
			sellValue = cost /2; 
			System.Math.Truncate(sellValue);
		}
		if(monthlyCost == null || monthlyCost <= 0)
		{
			valid = false;
			return("Please enter a monthly cost.");
		}
		if(patientIncrease == null || patientIncrease <= 0)
		{
			valid = false;
			return("All items will increase patients by at least 1.");
		}
		if(degradable)
		{
			if(repairCost == null || repairCost <= 0)
			{
				valid = false;
				return "Enter a repair cost.";
			}
			if(lifeSpan == null || lifeSpan <= 0)
			{
				valid = false;
				return "Life must be entered above 0.";
			}
		}
		if(type == ObjectType.equipment)
		{
			stockable = true;
			if(capacity <= 0)
			{
				valid = false;
				return "Enter a capacity.";
			}
		}
		if(type == ObjectType.restock)
		{
			restockable = true;
		}
		if(!model)
		{
			valid = false;
			return "Assign a model!";
		}
		if(!mat)
		{
			valid = false;
			return "Assign a material please!";
		}
		if(!icon)
		{
			valid = false;
			return "Please assign an icon.";
		}
		valid = true;
		return "";
		
		
	}
	void CreateItem()
	{
		created = new GameObject();
		created.name = objectName;
		//created.layer = 15;
		if(model.GetComponent<MeshFilter>())
		{
			MeshFilter m = created.AddComponent<MeshFilter>();
			m.sharedMesh = model.GetComponent<MeshFilter>().sharedMesh;
		}
		else
		{
			created = model;
		}
		created.transform.rotation = model.transform.rotation;
		created.AddComponent<BoxCollider>();
		created.AddComponent<Rigidbody>();
		created.GetComponent<Rigidbody>().useGravity = false;
		MeshRenderer r = created.AddComponent<MeshRenderer>();
		r.material = mat;
		switch(type)
		{
		case ObjectType.basic:
				CreateBasic();
			break;
		case ObjectType.equipment:
				CreateEquip();
			break;
		case ObjectType.restock:
				CreateReStock();
			break;
		default:
			break;	
		}

		
	}
	
	void CreateBasic()
	{
		created.AddComponent<BasicObject>();
		ObjectPlacement p = created.AddComponent<ObjectPlacement>();
		p.moveSpeed = 10000f;
		BasicObject o = created.GetComponent<BasicObject>();
		o.objectName = objectName;
		o.objectDescription = description;
		o.quality = quality;
		o.cost = (int)cost;
		o.sellValue = (int)sellValue;
		o.costPerDay = (int)dailyCost;
		o.costPerMonth = (int)monthlyCost;
		o.degradable = degradable;
		if(degradable)
		{
			o.repairCost = (int)repairCost;
			o.lifeSpanInDays = lifeSpan;
		}
		o.buttons = buttons;
		o.healthBar = healthBar;
		o.destruction = destruction;
		//o.transform.eulerAngles = newAngle;
		//string path = defaultPath + objectName + ".prefab";


		CreatePrefab.CreateNewPrefab(created);
		defaultPath = "Assets/Prefabs/" + objectName + ".prefab";
		AddObjectToUI(created);
	}
	
	void CreateEquip()
	{
		created.AddComponent<StockableObject>();
		ObjectPlacement p = created.AddComponent<ObjectPlacement>();
		p.moveSpeed = 10000f;
		StockableObject o = created.GetComponent<StockableObject>();
		o.objectName = objectName;
		o.objectDescription = description;
		o.quality = quality;
		o.cost = (int)cost;
		o.costPerDay = (int)dailyCost;
		o.sellValue = (int)sellValue;
		o.costPerMonth = (int)monthlyCost;
		o.degradable = degradable;
		if(degradable)
		{
			o.repairCost = (int)repairCost;
			o.lifeSpanInDays = lifeSpan;
		}
		o.buttons = buttons;
		o.healthBar = healthBar;
		o.destruction = destruction;
		o.stockable = stockable;
		o.capacity = capacity; 
		//o.transform.eulerAngles = newAngle;
		//string path = defaultPath + objectName + ".prefab";
		CreatePrefab.CreateNewPrefab(created);
		defaultPath = "Assets/Prefabs/" + objectName + ".prefab";
		AddObjectToUI(created);
	}
	void CreateReStock()
	{
		created.AddComponent<ReStockableObject>();
		ObjectPlacement p = created.AddComponent<ObjectPlacement>();
		p.moveSpeed = 10000f;
		ReStockableObject o = created.GetComponent<ReStockableObject>();
		o.objectName = objectName;
		o.objectDescription = description;
		o.quality = quality;
		o.cost = (int)cost;
		o.sellValue = (int)sellValue;
		o.costPerDay = (int)dailyCost;
		o.costPerMonth = (int)monthlyCost;
		o.degradable = degradable;
		if(degradable)
		{
			o.repairCost = (int)repairCost;
			o.lifeSpanInDays = lifeSpan;
		}
		o.buttons = buttons;
		o.healthBar = healthBar;
		o.destruction = destruction;
		//o.stockable = stockable;
		o.restockable = restockable;
		o.restockCost = restockCost;
		o.initialStockLevel = maxLevel;
		o.maxStockLevel = maxLevel;
		o.stockLevel = 1;
		o.empty = empty;
		o.inBetween = mid;
		o.full = full;
		Vector3 spawnPoint = o.transform.position; 
		spawnPoint.y += o.GetComponent <BoxCollider>().size.y /2; 
		o.spawnPoint = new GameObject().transform;
		o.spawnPoint.position = spawnPoint;
		//o.transform.eulerAngles = newAngle;
		//string path = defaultPath + objectName + ".prefab";
		CreatePrefab.CreateNewPrefab(created);
		defaultPath = "Assets/Prefabs/" + objectName + ".prefab";
		AddObjectToUI(created);
	}
	void AddObjectToUI(GameObject go)
	{
		switch(menu)
		{
		case Menu.equip:
			GameObject o = GameObject.FindGameObjectWithTag("equip") as GameObject;
			UpdateUI (o,go);
			break;
		case Menu.furn:
			GameObject p = GameObject.FindGameObjectWithTag("furn") as GameObject;
			UpdateUI (p,go);
			break;
		default:
			break;
		}
	}
	
	void UpdateUI(GameObject s,GameObject go)
	{
			ObjectSelect selector = s.GetComponent<ObjectSelect>();
			GameObject previousIcon = selector.objectIcons[selector.objectIcons.Length-1];
			Vector3 newPosition = previousIcon.transform.position; 
			newPosition.x += 1.25f;
			GameObject[] icons = selector.objectIcons;
			System.Array.Resize<GameObject>(ref icons, icons.Length + 1);
			GameObject newIcon = Instantiate (defaultIcon, newPosition, previousIcon.transform.rotation) as GameObject;
			icons[icons.Length-1] = newIcon;
			GameObject[] objects = selector.objects;
			System.Array.Resize<GameObject>(ref objects, objects.Length + 1);
			objects[objects.Length-1] = Resources.LoadAssetAtPath (defaultPath,typeof(GameObject)) as GameObject;
			newIcon.GetComponent<ToolTipHelper>().toolTipText = objectName;
			newIcon.name = objectName + "Icon";
			foreach(Transform t in newIcon.transform)
			{
				t.renderer.material.mainTexture = icon;
			}
			newIcon.GetComponent<SelectObjectOnClicked>().objectSelector = selector.gameObject;
			CreateObjectOnClicked a = newIcon.GetComponent<CreateObjectOnClicked>();
			a.objectSelector = selector;
			a.spawnNode = GameObject.FindGameObjectWithTag("objectspawn").transform;
			selector.objectIcons = icons;
			selector.objects = objects;
		newIcon.transform.parent = selector.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
