using UnityEngine;
using System.Collections;

public class RandomMessages : MonoBehaviour {
	
	public static string[] goingHome;
	public static string[] goingHomeHappy;
	public static string[] goingHomeAngry;
	public static string[] clinicClosed;
	public static string[] first;
	public static string[] impatient;
	public static string[] longQueue;
	// Use this for initialization
	void Awake () 
	{
		goingHome = new string[5]
		{
			"I guess it's home time.", 
			"Well I'll be leaving then.", 
			"Awww I'm going, I'm going!",
			"Sayonara Bitches!", 
			"Sometimes goodbye is not the end, but in this case it is :)"
		};
		
		goingHomeAngry = new string[5]
		{
			"Fuck this, I'm leaving!",
			"RAWR YOU HAVE FAILED ME FOR THE LAST TIME!!!!",
			"Good day to you sir, I shall not be returning",
			"Go to hell",
			"I hope this place burns to the ground!"
		};
		
		goingHomeHappy = new string[5]
		{
			"Thank you so much! I'll be going now.",
			"See you around, I owe you one.",
			"Wow great service, see you soon!",
			"I love you!!!!",
			"I don't want to leave, but I have to, au'reviour"
		};
		
		clinicClosed = new string[5]
		{
			"Looks like the clinic is closed!",
			"Oh man closed, this suuuucks!!!",
			"Access Denied, will come back another time",
			"Why am I here at this time??????????????",
			"What am I doing here? The Clinic is closed"
		};
		
		first = new string[3]
		{
			"Wow i'm the first one here!",
			"First!!!!! Fuck Yes!",
			"There's nobody else here."
		};
		
		impatient = new string[2]
		{
			"Hurry up!!!!!!!!!!!!!",
			"I've been standing here for far too long."
		};
		
		longQueue = new string[3]
		{
			"I'm outta here, I can't afford to wast time in a queue that long!",
			"Shit! A Queue that long just ain't worth it, I'm going home!",
			"No.Not waiting.Bye!"
		};
	}
	
	
	
	public static void AddNameToString(string name)
	{
		
	}
	
	public static string GetHomeMessage()
	{
		int i = Random.Range (0,goingHome.Length-1);
		return goingHome[i];
	}
	
	public static string GetAngryHomeMessage()
	{
		int i = Random.Range (0,goingHomeAngry.Length-1);
		return goingHomeAngry[i];
	}
	
	public static string GetHappyHomeMessage()
	{
		int i  = Random.Range(0,goingHomeHappy.Length-1);
		return goingHomeHappy[i];
	}
	
	public static string GetClosedMessage()
	{
		int i = Random.Range (0,clinicClosed.Length - 1);
		return clinicClosed[i];
	}
	public static string GetFirstMessage()
	{
		int i = Random.Range (0,clinicClosed.Length - 1);
		return first[i];
	}
	
	public static string GetImpatientMessage()
	{
		int i = Random.Range (0,impatient.Length - 1);
		return impatient[i];
	}
	
	public static string GetLongQueue()
	{
		int i = Random.Range (0,longQueue.Length - 1);
		return longQueue[i];
	}
	// Update is called once per frame
	void Update () {
	
	}
}
