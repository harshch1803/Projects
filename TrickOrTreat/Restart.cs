using UnityEngine;
using System.Collections;


public class Restart : MonoBehaviour
{

	PauseAndResume pause;
	void Start()
	{
		pause = GameObject.Find("GameController").GetComponent<PauseAndResume>();
	}

	public void RestartGame()
	{
		pause.pause.SetActive(false);
		Application.LoadLevel(Application.loadedLevel);
	}


}
