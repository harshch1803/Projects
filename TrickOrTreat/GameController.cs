using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{
	public Camera cam;
	float maxwidth;
	
	//stores different colored candies.
	public GameObject[] candies;
	
	public GameObject restart;
	public GameObject MainMenu;
	public Text instruction;
	
	HighScore highscore;
	TimeCounter timecounter;
	
	void Awake()
	{
		//disable MainMenu and restart buttons.
		MainMenu.SetActive(false);
		restart.SetActive(false);
	}
	
	// Use this for initialization
	void Start () 
	{
		//checks for camera and assigns main camera if no camera assigned earlier.
		if(cam==null)
			cam=Camera.main;
		
		//acess TimeCounter script.	
		timecounter = gameObject.GetComponent<TimeCounter>();
		
		//acess HighScore Script.
		highscore = gameObject.GetComponent<HighScore>();
		
		//stores the screen limits in a vector.
		Vector3 screenlimit = new Vector3(Screen.width,Screen.height,0f);
		
		//converts screen limits to world limits and stores it in a vector.
		Vector3 worldlimit = cam.ScreenToWorldPoint(screenlimit);
		
		//(-0.9f),so that candies are spawned inside the screenlimit.
		maxwidth = worldlimit.x - 0.9f;
		
		//display instructions before game starts.
		instruction.enabled=true;
		
		//begin spawning candies and other GOs. 
		StartCoroutine("spawn");
	}

	IEnumerator spawn()
	{
		//wait for 3 seconds.
		yield return new WaitForSeconds(3f);
		
		//disable instructions.
		instruction.enabled=false;
		
		//begin the countdown timer.
		timecounter.playing=true;
		
		//begin spawning candies after 2seconds.
		yield return new WaitForSeconds(2f);
		
		//check if counter reached zero.
		while(timecounter.playing)
		{
			//randomly generates and stores a spawn position in the given range.
			Vector3 spawnposition = new Vector3(Random.Range(-maxwidth,maxwidth),transform.position.y,0f);
		
			//stores spawn rotation.
			Quaternion spawnrotation = Quaternion.identity;

			//spawns the candies at the given spawn position and rotation.
			Instantiate(candies[Random.Range(0,candies.Length)],spawnposition,spawnrotation);
			
			// time gap between successive spawns.
			yield return new WaitForSeconds(Random.Range(0.8f,1.6f));
		}
		
		//checks if the highscore is broken.
		highscore.compare();
		
		//displays restart and MainMenu button after 2 seconds.
		yield return new WaitForSeconds(2f);
		
		restart.SetActive(true);
		MainMenu.SetActive(true);
	}

}
