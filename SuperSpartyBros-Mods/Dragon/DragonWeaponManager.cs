using UnityEngine;
using System.Collections;

public class DragonWeaponManager : MonoBehaviour
{
	//Accepts a GameObject in this case FireBall.
	public GameObject DragonWeapon;

	//Offset distance from the Mouth of the Dragon to  Spawn the Fireball.
	public float FireBall_YOffset = 1f;

	//Time Interval between Fireball spawns.
	public float spawnTime = 1f;

	bool dragonDead;


	// Use this for initialization
	void Start ()
	{
		StartCoroutine("spawn");
	}

	//Coroutine to spawn FireBalls.

	IEnumerator spawn()

	{
		//Check if Dragon is Dead.
		while(!dragonDead)
		{
			yield return new WaitForSeconds(1f);

			//Spawns Fireball at the Desired Position.
			DragonWeapon.transform.position = new Vector3(transform.position.x, transform.position.y - FireBall_YOffset,transform.position.z);
			DragonWeapon.transform.rotation = Quaternion.Euler(transform.rotation.x,transform.rotation.y,transform.rotation.z-90f);

			Instantiate(DragonWeapon);
		}

	}

	//called by Dragon Script when the player jumps on the back of the dragon.
	public void NoFireball()
	{
		dragonDead = true;
	}
}
