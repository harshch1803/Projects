using UnityEngine;
using System.Collections;

public class DragonDeath : MonoBehaviour 
{

	void OnCollisionEnter2D(Collision2D other)
	{
		//Checks for Collision with Player.
		if(other.gameObject.tag == "Player")
		{
			//Calls The DeathFunction in the Dragon Script.
			this.GetComponentInParent<Dragon>().Death();

			//Deactivates the HeadCheck to which this script is attached.
			this.gameObject.SetActive(false);
		}
	}
}
