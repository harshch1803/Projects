using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameController : MonoBehaviour 
{
	public Camera cam;
	float maxwidth;
	public GameObject[] candies;
	public GameObject restart,MainMenu;
	public Text instruction;
	
	HighScore highscore;
	TimeCounter timecounter;
	
	void Awake()
	{
		MainMenu.SetActive(false);
		restart.SetActive(false);
	}
	
	// Use this for initialization
	void Start () 
	{
		if(cam==null)
			cam=Camera.main;
			
		timecounter = gameObject.GetComponent<TimeCounter>();
		
		highscore = GameObject.Find("GameController").GetComponent<HighScore>();
		
		Vector3 screenlimit = new Vector3(Screen.width,Screen.height,0f);
		Vector3 worldlimit = cam.ScreenToWorldPoint(screenlimit);
		maxwidth = worldlimit.x-.9f;
		
		instruction.enabled=true;
		
		StartCoroutine("spawn");
	

	}

	IEnumerator spawn()
	{
		yield return new WaitForSeconds(3f);
		
		instruction.enabled=false;
		timecounter.playing=true;
		
		yield return new WaitForSeconds(2f);
		
		while(timecounter.playing)
		{
			Vector3 spawnposition = new Vector3(Random.Range(-maxwidth,maxwidth),transform.position.y,0f);
			Quaternion spawnrotation = Quaternion.identity;

			Instantiate(candies[Random.Range(0,candies.Length)],spawnposition,spawnrotation);
			
			yield return new WaitForSeconds(Random.Range(0.8f,1.6f));
		}
		
		highscore.compare();
		
		yield return new WaitForSeconds(2f);
		
		restart.SetActive(true);
		MainMenu.SetActive(true);
	}

}
