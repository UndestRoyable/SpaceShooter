using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Boundary") //Ive tagged screen boundary and this is comparing other.tag to boundary tag 
		{
			return;//ends this function and returns control to Unity's game loop
		}
		Destroy(other.gameObject); //Destroys light bolt when hit the asteroid
		Destroy (gameObject); //Destroys the asteroid, because this script is attached to Asteroid gameObject
	}

}
