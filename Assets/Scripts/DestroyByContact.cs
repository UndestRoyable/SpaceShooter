using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Boundary") //Ive tagged screen boundary and this is comparing other.tag to boundary tag 
		{
			return;//ends this function and returns control to Unity's game loop
		}
		Instantiate(explosion, transform.position, transform.rotation); // triggers the explosion
		if (other.tag == "Player") //if player hits asteroid, we get a different explosion.
		 {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
		 }
		Destroy(other.gameObject); //Destroys light bolt when hit the asteroid
		Destroy (gameObject); //Destroys the asteroid, because this script is attached to Asteroid gameObject
	}

}
