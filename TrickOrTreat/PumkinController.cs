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
		if(cam==null)
			cam=Camera.main;
			
		scorecount = GameObject.Find("GameController").GetComponent<Scorecount>();
		timecounter = GameObject.Find("GameController").GetComponent<TimeCounter>();
		highscore = GameObject.Find("GameController").GetComponent<HighScore>();
		
		Vector3 screenlimit = new Vector3(Screen.width,Screen.height,0f);
		Vector3 worldlimit = cam.ScreenToWorldPoint(screenlimit);
		 maxwidth= worldlimit.x-1.1f;
	
	}
	
	// Update is called once per physicalframe
	void FixedUpdate ()
	{
		Vector3 worldposition = cam.ScreenToWorldPoint(Input.mousePosition);
		Vector3 pumpkinposition = new Vector3(worldposition.x,0f,0f);
		float maxWidth  =Mathf.Clamp(pumpkinposition.x,-maxwidth,maxwidth);
		pumpkinposition = new Vector3(maxWidth,0f,0f);
		rigidbody2D.MovePosition(pumpkinposition);
	
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag=="Skull")
			scorecount.scorecounter = scorecount.scorecounter -2;
		
		else if(other.gameObject.tag =="Spider")
		{
			timecounter.timer = timecounter.timer - 4f;
			scorecount.scorecounter--;
		}
		 
		if(other.gameObject.tag == "Skull"||other.gameObject.tag=="Spider")
		{
			Destroy(other.gameObject);
			Instantiate(explosion,transform.position,Quaternion.identity);

		}
		
		highscore.temp=scorecount.scorecounter;
	}
	
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
