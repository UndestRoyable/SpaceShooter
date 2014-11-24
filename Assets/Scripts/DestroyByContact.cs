using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;

	public int scoreValue; //The amont of points every hazard gives to player when destroyed.
	private GameController gameController;//instance of GameController.

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) 
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null) 
		{
			Debug.Log("I just can't find 'GameController' script");
		}
	}

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
			gameController.GameOver();
		 }
		gameController.AddScore (scoreValue);
		Destroy(other.gameObject); //Destroys light bolt when hit the asteroid
		Destroy (gameObject); //Destroys the asteroid, because this script is attached to Asteroid gameObject
	}

}
