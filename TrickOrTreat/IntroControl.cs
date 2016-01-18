using UnityEngine;
using System.Collections;

public class IntroControl : MonoBehaviour
{
	public GameObject start,quit;


	// Use this for initialization
	public void startgame()
	{
		Application.LoadLevel(1);
	}
	
	
	public void quitgame()
	{
		Application.Quit();
	}
}
