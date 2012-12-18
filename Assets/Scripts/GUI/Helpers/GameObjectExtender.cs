using UnityEngine;
using System.Collections;

public static class GameObjectExtender 
{
	public static Color defaultColor;
	
	public static void StoreStandardColour(this GameObject o)
	{
		if(o.renderer)
		{
			defaultColor = o.renderer.material.color;
		}
		foreach(Transform child in o.transform)
		{
			if(child.renderer)
			{
				foreach(Material mat in child.renderer.materials)
				{
					mat.StoreDefaultColour();
				}
			}
		}
	}
	
	public static void RevertColour(this GameObject o)
	{
		if(o.renderer)
		{
			foreach(Material mat in o.renderer.materials)
			{
				mat.RevertColour();
			}
		}
		
		foreach(Transform child in o.transform)
		{
			if(child.renderer)
			{
				foreach(Material mat in child.renderer.materials)
				{
					mat.RevertColour();
				}
			}

					//child.renderer.material.color = green; 
		}
		
	}
	
	public static void StoreDefaultColour(this Material m)
	{
		defaultColor = m.color;
	}
	
	public static void RevertColour(this Material m)
	{
		m.color = defaultColor;
	}
	
	public static void ChangeColour(this GameObject o, Color c)
	{
		if(o.renderer)
		{
			foreach(Material mat in o.renderer.materials)
			{
				mat.color = c;
			}
		}
		
		foreach(Transform child in o.transform)
		{
			if(child.renderer)
			{
				foreach(Material mat in child.renderer.materials)
				{
					mat.color = c;
				}
			}		//child.renderer.material.color = green; 
		}

	}
}
