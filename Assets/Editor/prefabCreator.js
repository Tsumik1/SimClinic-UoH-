//Quick make prefab script. 
@MenuItem("Project Tools /Make Prefab #&_p")

static function CreatePrefab()
{
	var selectedObjects :GameObject[] =  Selection.gameObjects; 
	
	for (var go:GameObject in selectedObjects) //loop through selection.
	{
		//print(go.name);
		var name : String = go.name; // get name of prefab
		var localPath:String = "Assets/Prefabs/" + name +".prefab"; // where the prefabs are saved to.
		if(AssetDatabase.LoadAssetAtPath(localPath,GameObject))
		{
			if(EditorUtility.DisplayDialog("Overwrite existing?", "Prefab already exists. Overwrite?", "Yes", "No"))
				{
					createNew(go,localPath);//make pregav
				}
		}
		else
		{
			createNew(go, localPath);
		}
		
	}

}

static function createNew(selectedObjects :GameObject, localPath:String)
{
	var prefab : Object  = PrefabUtility.CreateEmptyPrefab(localPath);
	PrefabUtility.ReplacePrefab(selectedObjects, prefab);
	AssetDatabase.Refresh();
	
	DestroyImmediate(selectedObjects); //removes object
	var clone: GameObject = PrefabUtility.InstantiatePrefab(prefab) as GameObject; //makes a copy of prefab. 
	
}