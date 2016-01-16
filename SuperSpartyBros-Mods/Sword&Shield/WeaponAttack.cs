using UnityEngine;
using System.Collections;

public class WeaponAttack : MonoBehaviour 
{
	Rigidbody2D rigidBody;
	Animator anim;

	//called by the WeaponManager script (attached to Sparty) to set speed of the sword.
	[HideInInspector]
	public int Speed;

	AudioSource _audio;

	void Start()
	{
		anim = GetComponent<Animator>();
		rigidBody = GetComponent<Rigidbody2D>();
		rigidBody.velocity = new Vector2(Speed,0f);
		_audio = GetComponent<AudioSource>();
		_audio.Play();
	}

	//called by EnemyShield script on collision with Enemy GO.
	public void WeaponBurst()
	{
		//play the burst animation.
		anim.SetTrigger("Burst");

	}
}
