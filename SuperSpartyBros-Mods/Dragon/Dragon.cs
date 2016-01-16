using UnityEngine;
using System.Collections;

public class Dragon : MonoBehaviour 
{
	[Range(0f,10f)]
	public float moveSpeed = 4f;
	public int damageAmount = 10;

	public GameObject Victory;
	public GameObject[] myWaypoints; 

	public float waitAtWaypointTime = 1f; 
	public float stunnedTime = 1f;

	public bool loopWaypoints = true;

	public AudioClip attackSFX;
	public AudioClip deathSFX;

	Transform _transform;
	Rigidbody2D _rigidbody;
	Animator _animator;
	AudioSource _audio;


	int _myWaypointIndex = 0;
	float _moveTime; 
	float _vx = 0f;
	bool _moving = true;
	float lockPos = 0f;



	// Use this for initialization
	void Awake () 
	{
		_transform = GetComponent<Transform> ();
		_rigidbody = GetComponent<Rigidbody2D> ();
		_animator = GetComponent<Animator>();
		_audio = GetComponent<AudioSource> ();

		_moveTime = 0f;
		_moving = true;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.rotation = Quaternion.Euler(transform.rotation.x,transform.rotation.y,lockPos);

		if (Time.time >= _moveTime)
		{
			EnemyMovement();
		}
	
	}

	void EnemyMovement() 
	{
		// if there isn't anything in My_Waypoints
		if ((myWaypoints.Length != 0) && (_moving))
		{
			
			// make sure the enemy is facing the waypoint (based on previous movement)
			Flip (_vx);
			
			// determine distance between waypoint and enemy
			_vx = myWaypoints[_myWaypointIndex].transform.position.x-_transform.position.x;
			
			// if the enemy is close enough to waypoint, make it's new target the next waypoint
			if (Mathf.Abs(_vx) <= 0.05f)
			{
				// At waypoint so stop moving
				_rigidbody.velocity = new Vector2(0, 0);
				
				// increment to next index in array
				_myWaypointIndex++;
				
				// reset waypoint back to 0 for looping
				if(_myWaypointIndex >= myWaypoints.Length)
				{
					if (loopWaypoints)
						_myWaypointIndex = 0;

					else
						_moving = false;
				}
				
				// setup wait time at current waypoint
				_moveTime = Time.time + waitAtWaypointTime;
			}

			else 
			{
				// enemy is moving
				//_animator.SetBool("Moving", true);
				
				// Set the enemy's velocity to moveSpeed in the x direction.
				_rigidbody.velocity = new Vector2(_transform.localScale.x * moveSpeed, _rigidbody.velocity.y);
			}
			
		}
	}
	
	// flip the enemy to face torward the direction he is moving in
	void Flip(float _vx) 
	{
		
		// get the current scale
		Vector3 localScale = _transform.localScale;
		
		if ((_vx>0f)&&(localScale.x<0f))
			localScale.x*=-1;

		else if ((_vx<0f)&&(localScale.x>0f))
			localScale.x*=-1;
		
		// update the scale
		_transform.localScale = localScale;
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if ((collision.tag == "Player"))
		{
			CharacterController2D player = collision.gameObject.GetComponent<CharacterController2D>();
			if (player.playerCanMove) {
				// Make sure the enemy is facing the player on attack
				Flip(collision.transform.position.x-_transform.position.x);
				
				// attack sound
				playSound(attackSFX);
				
				// stop moving
				_rigidbody.velocity = new Vector2(0, 0);
				
				// apply damage to the player
				player.ApplyDamage (damageAmount);
				
				// stop to enjoy killing the player
				_moveTime = Time.time + stunnedTime;
			}
		}
	}

	//Public Function called by The DragonDeath Script attached to 'Mouth' GameObject (Child of the Dragon)
	public void Death()
	{
		//stop the dragon from moving.
		_moving =false;

		//stop the dragon from spawning anymore fireballs calling NoFireBall Function from DragonWeaponManger Script attached to Mouth GameObject. 
		this.GetComponentInChildren<DragonWeaponManager>().NoFireball();

		//Switch the Dragon from Enemy Layer to StunnedEnemy to prevent The Player from getting killed during the Explosion.
		this.gameObject.layer = LayerMask.NameToLayer("StunnedEnemy"); 

		//Play Death SoundFX.
		playSound(deathSFX);

		//Play DeathAnimation.
		_animator.SetTrigger("Dead");

		//Destroy Dragon after 1.2seconds.
		Invoke("DestroyNow",1.2f);
	}

	void DestroyNow()
	{
		//Spawn  the princess after dragon's death.
		Instantiate(Victory,Vector3.zero,Quaternion.identity);
		Destroy(this.gameObject);
	}

	void playSound(AudioClip clip)
	{
		_audio.PlayOneShot(clip);
	}
}
