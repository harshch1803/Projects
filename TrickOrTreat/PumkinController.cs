using UnityEngine;
using System.Collections;

public class PumkinController : MonoBehaviour 
{

	public Camera cam;
	public GameObject explosion;
	
	Scorecount scorecount;
	HighScore highscore;
	TimeCounter timecounter;
	
	float maxwidth;

	// Use this for initialization
	void Start () 
	{
		//assigns to main camera if no other camera is assigned before hand.
		if(cam==null)
			cam=Camera.main;
		
		//access scorecounter script.	
		scorecount = GameObject.Find("GameController").GetComponent<Scorecount>();
		
		//access timecounter script.
		timecounter = GameObject.Find("GameController").GetComponent<TimeCounter>();
	
		//access highscore script.
		highscore = GameObject.Find("GameController").GetComponent<HighScore>();
		
		//stores the screenlimits in the form of a vector.
		Vector3 screenlimit = new Vector3(Screen.width,Screen.height,0f);
		
		//converts screen limits into world limits and stores it in the form of a vector.
		Vector3 worldlimit = cam.ScreenToWorldPoint(screenlimit);
		
		//(-1.1f) so that the entire pumpkin lies inside the screen.
		maxwidth = worldlimit.x - 1.1f;
	
	}
	
	// Update is called once per physicalframe
	void FixedUpdate ()
	{
		//stores the mouseposition in the form of a vector.
		Vector3 worldposition = cam.ScreenToWorldPoint(Input.mousePosition);
		
		//the x-coordinate of the vector is used to control the pumpkin.
		Vector3 pumpkinposition = new Vector3(worldposition.x,0f,0f);
		
		//clamps the pumpkin between 2 extreme limits.
		float maxWidth  = Mathf.Clamp(pumpkinposition.x,-maxwidth,maxwidth);
	
		pumpkinposition = new Vector3(maxWidth,0f,0f);
	
		//move the pumpkin based on the given input position.
		rigidbody2D.MovePosition(pumpkinposition);
	
	}
	
	//if the GOs touches the outer portion of the pumpkin.
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag=="Skull")
		{
			scorecount.scorecounter = scorecount.scorecounter -2;
			DestroyNow(other);
		}
			
		else if(other.gameObject.tag =="Spider")
		{
			timecounter.timer = timecounter.timer - 4f;
			scorecount.scorecounter--;
			DestroyNow(other);
		}
		highscore.temp=scorecount.scorecounter;
	}
	
	//destory the gameObject that has collided.
	void DestroyNow(GameObject other)
	{
		Destroy(other.gameObject);
		Instantiate(explosion,transform.position,Quaternion.identity);
	}
	
	//if the GOs are collected properly by the pumpkin.
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag =="Apple")
			timecounter.timer = timecounter.timer + 3f;
		
		else if(other.gameObject.tag =="Spider")
		{
			timecounter.timer = timecounter.timer + 6f;
		    scorecount.scorecounter=scorecount.scorecounter+4;
		}
	
		else if(other.gameObject.tag =="Skull")
		{
			scorecount.scorecounter= scorecount.scorecounter+4;
		}
		
		else if(other.gameObject)
		{
			scorecount.scorecounter++;
		}
		
		Destroy(other.gameObject);
		
		highscore.temp=scorecount.scorecounter;
	}
}
