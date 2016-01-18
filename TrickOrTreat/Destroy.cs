using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D other)
	{
		//destroys candies,skull,spider on collision with death zone.
		Destroy(other.gameObject);
	}

}
