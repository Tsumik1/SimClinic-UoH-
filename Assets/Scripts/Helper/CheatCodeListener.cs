using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/* Name: CheatCodeListener
 * Description: This class controls the cheats in game. Will remain mostly undocumented. 
 * Author: Blake Kendrick 
 * Date: 02/11/2012
 * */
public class CheatCodeListener : MonoBehaviour
{
    private string m_Keys = "";
    private float m_LastKeyTime;

    public List <string> m_Codes = new List <string> ();
    public float m_ClearDelay = 2.0f;
    public GameObject m_Receiver = null;
	
	public GameObject claptrap;
	
	public AudioClip firearms; 
	
    void Start ()
    {
        m_LastKeyTime = Time.time;
        for (int i = 0; i < m_Codes.Count; i++)
        {
            m_Codes [i] = m_Codes [i].ToLower ();
        }
    }

    void Update ()
    {
        if (Input.anyKey)
        {
            m_LastKeyTime = Time.time;
        }
        else if (Time.time - m_LastKeyTime > m_ClearDelay)
        {
            m_Keys = "";
        }

        m_Keys += Input.inputString.ToLower ();

        if (m_Codes.Contains (m_Keys))
        {
            string message = "On" + char.ToUpper (m_Keys [0]) + m_Keys.Substring (1) + "Code";

            if (m_Receiver == null)
            {
                SendMessage (message);
            }
            else
            {
                m_Receiver.SendMessage (message);
            }
            m_Keys = "";
        }
    }

    void OngivemenovacaineCode ()
    // Handle codes in scripts on the target GameObject (or the current one if
    // no target is set) by implementing functions named On{Name}Code - note
    // that the codes are set to be all-lowercase except for the first letter.
    {
        PatientManager.IncreasePatientSatisfaction(999999);
    }
	
	void OnWherehastherumgoneCode()
	{
		print ("WHERE HAS THE RUM GONE!!!!!!");
		//Makes all patients talk like Jack Sparrow
		
	}
	
	void OnIwantmoreCode()
	{
		print ("YOU WANTED MORE!!!!");
		MoneyManager.money += 50000;
	}
	
	void OnGimmiewhatiwantCode()
	{
		MoneyManager.money += 5000000;
	}
	
	void OnClaptrapCode()
	{
	 //will spawn claptrap from Borderlands2;	
	}
	
	void OnAmericanidiotCode()
	{
		//Makes everyone wear silly hats. 
	}
	
	void OnThematrixhasyouCode()
	{
		Time.timeScale = 1;
		TimeManager.currentDate = System.DateTime.Now;
		TimeManager.multiplyValue = 1;
	}
	
	void OnCanyourlightcycledothisCode()
	{
		foreach(GameObject o in FindObjectsOfType(typeof(GameObject)))
		{
			if(o.GetComponent<MeshRenderer>())
			{
				WireframeRenderer r = o.AddComponent<WireframeRenderer>();
				r.BackgroundColor = Color.black;
				r.LineColor = Color.green;
				r.LineColor.a = 255f;
				r.BackgroundColor.a = 255f;
			}
		}
	}
	
	void OnThesecheatsareoursCode()
	{
		
	}
	
	void OnThankspeterCode()
	{
		//Will implement bloatyhead!
	}
	
	void OnFirearmsCode()
	{
		AudioSource.PlayClipAtPoint(firearms, Camera.main.transform.position);
	}
}