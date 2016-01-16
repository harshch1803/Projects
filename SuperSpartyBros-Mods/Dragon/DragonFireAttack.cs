using UnityEngine;
using System.Collections;

public class DragonFireAttack : MonoBehaviour 
{
	public AudioClip fireballSFX;
	public float FireBallSpeed = 3f;

	Rigidbody2D _rigidbody;
	Animator _anim;
	AudioSource _audio;

	// Use this for initialization
	void Start ()
	{
		_anim = GetComponent<Animator>();
		_rigidbody = GetComponent<Rigidbody2D>();
		_rigidbody.velocity = FireBallSpeed *Vector3.down;
		_audio = GetComponent<AudioSource>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//Checks if FireBall Collided with Shield GameObject.
		if(other.gameObject.tag == "Shield")
		{
			//Play Explosion Animation of FireBall.
			_anim.SetTrigger("Explosion");

			//Play Sound Of Explosion of FireBall.
			playSound(fireballSFX);

			//Switch The FireBall Layer from Enemy to Stunned Enemy to Prevent from dying after the Explosion. 
			this.gameObject.layer = LayerMask.NameToLayer("StunnedEnemy");  

			//Destroy This GameObject.
			Invoke("DestroyNow",1.5f);
		}
	}

	void playSound(AudioClip clip)
	{
		_audio.PlayOneShot(clip);
	}

	void DestroyNow()
	{
		Destroy(this.gameObject);
	}
}
