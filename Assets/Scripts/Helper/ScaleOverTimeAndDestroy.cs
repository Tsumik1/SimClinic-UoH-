using UnityEngine;
using System.Collections;

public class ScaleOverTimeAndDestroy : MonoBehaviour {
	
	
	public float time = 1.0f; 
	public float initialScale = 0.1f;
	public float endScale = 5.0f;
	
	
	// Use this for initialization
	void Start () 
	{
		StartCoroutine ("ScaleOverTime");
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	IEnumerator ScaleOverTime()
	{
		float t = 0; 
		while(t <= time)
		{
			t += Time.deltaTime;
			float scale = Mathf.Lerp (initialScale,endScale,t/time);
			transform.localScale = new Vector3(scale,scale,scale);
			yield return null;
		}
		
	Destroy(gameObject);
	}
}
