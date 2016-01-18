using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class HighScore : MonoBehaviour 
{
	public Text highscore;
	public int temp;
	
	int topscore;
	
	void Start()
	{
		topscore=PlayerPrefs.GetInt("HIGHSCORE");
		highscore.text="HIGHSCORE: " +(topscore);
	}
	
	
	public void compare()
	{
		if(temp>topscore)
		{
			topscore=temp;
			PlayerPrefs.SetInt("HIGHSCORE",topscore);
			topscore=PlayerPrefs.GetInt("HIGHSCORE");
			highscore.text="HIGHSCORE: " +(topscore);
		}

	}
}
