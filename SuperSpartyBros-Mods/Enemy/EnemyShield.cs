using UnityEngine;
using System.Collections;

public class EnemyShield : MonoBehaviour
{
	//calling WeaponAttack script attached to the Weapon ( in this case the Sword).
	WeaponAttack _weaponattack;
	
	AudioSource _audio;
	// Use this for initialization
	void Start () 
	{
		_audio = GetComponent<AudioSource>();
	
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Weapon")
		{
			_weaponattack = other.gameObject.GetComponent<WeaponAttack>();

			//call WeaponBurst function from the script.
			_weaponattack.WeaponBurst();

			//play sword explosion audio.
			_audio.Play();


		}
	}

}
