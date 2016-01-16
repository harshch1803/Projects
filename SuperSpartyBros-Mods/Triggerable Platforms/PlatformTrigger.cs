using UnityEngine;
using System.Collections;

public class PlatformTrigger : MonoBehaviour 
{
	//accepts Platform GO.
	public GameObject Platform;

	//accepts a Empty GO.It acts as the destination point for the Platform.
	public GameObject WayPoint;

	//accepts a Particle System GO.
	public GameObject explosion;

	//speed of the moving platform.
	public float speed = 3f;
	
	Renderer renderer;

	AudioSource _audio;

	bool _trigger = false;

	// Use this for initialization
	void Start () 
	{
		renderer = GetComponent<Renderer>();
		_audio = GetComponent<AudioSource>();
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		//checks if trigger is activated.
		if(_trigger)
		{
			//stores the destination position in newPos.
			Vector3 newPos = new Vector3(Platform.transform.position.x,WayPoint.transform.position.y,Platform.transform.position.z);

			//lerps the platform from start to destination position.
			Platform.transform.position = Vector3.Lerp(Platform.transform.position,newPos,speed*Time.deltaTime);
		}
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//checks if the tag of the GO collided is Player.
		if(other.gameObject.tag == "Player")
		{
			//sets the trigger = true.
			_trigger = true;

			//disable the renderer so the rose is not visible.
			renderer.enabled = false;

			//Switch the layer of the GO to BackGround to prevent any further interations with the player.
			this.gameObject.layer = LayerMask.NameToLayer("BackGround");

			//emit the explosion particles.
			Instantiate(explosion,transform.position,transform.rotation);

			//play explosion sound.
			_audio.Play();

			//destroy GO after 1 second.
			Invoke("DestroyNow",1f);
		}
	}

	void DestroyNow()
	{
		Destroy(this.gameObject);
	}
}
