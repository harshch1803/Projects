using UnityEngine;
using System.Collections;

public class WeaponStun : MonoBehaviour 
{

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other)
	{
		//check if tag of the GO collided is weapon.
		if (other.gameObject.tag == "Weapon")
		{
			// tell the enemy to be stunned
			this.GetComponentInParent<Enemy>().Stunned();
			
			//destroy weapon.
			Destroy(other.gameObject);
		}
	}
}
