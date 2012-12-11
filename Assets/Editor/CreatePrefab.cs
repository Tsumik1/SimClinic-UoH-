using UnityEngine;
using System.Collections;
using UnityEditor;
public class CreatePrefab : MonoBehaviour {

	public static void CreateNewPrefab(GameObject go)
	{
		string name = go.name;
		string localPath = "Assets/Prefabs/" + name + ".prefab";
		if(AssetDatabase.LoadAssetAtPath(localPath,typeof(GameObject)))
		{
			if(EditorUtility.DisplayDialog("Overwrite Existing Object?", "This prefab already exists, overwrite?", "Yes", "No"))
			{
				CreateNew(go,localPath);
			}
		}
		else
		{
			CreateNew(go,localPath);
		}
		
	}
	
	public static void CreateNew(GameObject selected, string path)
	{
		
		Object prefab = PrefabUtility.CreateEmptyPrefab(path);
		PrefabUtility.ReplacePrefab(selected, prefab);
		AssetDatabase.Refresh();
		
		DestroyImmediate(selected);
		GameObject clone = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
	}
}
