using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour {

	public Text time;
	public float timer;
	public bool playing=false;
	// Update is called once per frame
	void FixedUpdate() 
	{
		if(playing)
		{
		if(timer<0)
		{
			timer=0;
			playing = false;
		}
		timer -=Time.deltaTime;
		timecountdown();
		}
	
	}
	void timecountdown()
	{
		time.text = "X"+Mathf.RoundToInt(timer);
	}
}
