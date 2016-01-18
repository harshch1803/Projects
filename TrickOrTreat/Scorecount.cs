using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scorecount : MonoBehaviour 
{

	public Text counter;
	public int scorecounter;
	// Use this for initialization
	void Start () 
	{
	

	}
	
	// Update is called once per frame
	void Update () 
	{
		counter.text = "Score: "+scorecounter;
	
	}
}
