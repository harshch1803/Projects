using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseAndResume : MonoBehaviour 
{
	public GameObject pause;
	public GameObject resume;
	public GameObject Quit;
	
	void Start()
	{
		resume.SetActive(false);
		Quit.SetActive(false);
	}
	
 	public void pauseGame()
	{
		Time.timeScale=0;
		
		pause.SetActive(false);
		resume.SetActive(true);
		Quit.SetActive(true);
	}
	
	public void resumeGame()
	{
		Time.timeScale=1;

		resume.SetActive(false);
		Quit.SetActive(false);
		pause.SetActive(true);
	}
	
	public void quit()
	{
		Application.Quit();
	}

}
