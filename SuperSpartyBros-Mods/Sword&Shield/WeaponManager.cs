using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour
{
	//call weaponattack script attached to weapon(sword) GO.
	WeaponAttack _weaponattack;

	//accepts sword GO.
	public GameObject Weapon;

	//accepts shield GO.
	public GameObject Shield;

	//to activate sword.(used in level 2)
	public bool Sword_ON= false;

	//to activate shield.(used in level 3)
	public bool Shield_ON =false;

	//distance of the shield from sparty. 
	public float ShieldOffset = 1f;

	Vector3 direction;

	//set weapon(sword) speed.
	[Range(0,10)]
	public int WeaponSpeed;

	//distance between sword and sparty.
	 float Xoffset = 1.5f;


	// Use this for initialization
	void Awake () 
	{
		 _weaponattack = Weapon.GetComponent<WeaponAttack>();
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//used in level 2.
		if(Input.GetKeyDown(KeyCode.RightAlt) && Sword_ON)
		{
			 if(transform.localScale.x == 1 && WeaponSpeed < 0)

			{
				Xoffset = 1.5f;
				WeaponSpeed = WeaponSpeed*-1;
			}

			else if(transform.localScale.x ==-1 && WeaponSpeed >0)
			{
				Xoffset = -1.5f;
				WeaponSpeed = WeaponSpeed*-1;
			}

			WeaponActive();
		}

		//used in level 3.
		else if(Input.GetKeyDown(KeyCode.RightControl) && Shield_ON)
		{
			ShieldActive();
		}
	
	}

	//used in level2.
	void WeaponActive()
	{
		//to face the direction of weapon along the direction of sparty.
		Weapon.transform.localScale= new Vector3(transform.localScale.x,1f,1f);

		//store the spawn position in wepoPos.
		Vector3 weaponPos = new Vector3(transform.position.x + Xoffset,transform.position.y,transform.position.z);

		//Update the position of the weapon.
		Weapon.transform.position = weaponPos;

		//update the speed of the weapon in weapon attack.
		_weaponattack.Speed = WeaponSpeed;	

		//spawn the weapon.
		Instantiate(Weapon);
	}	

	//used in level3.
	void ShieldActive()
	{
		//spawn position of the shield.
		Shield.transform.position = new Vector3(transform.position.x, transform.position.y+ShieldOffset,transform.position.z);

		//spawn rotation of the shield.Perpendicular to sparty.
		Shield.transform.rotation  = Quaternion.Euler(transform.rotation.x,transform.rotation.y,transform.rotation.z+90f);

		//spawn the shield just above sparty.
		Instantiate(Shield);
	}
}
