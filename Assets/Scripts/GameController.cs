using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject hazard;
	public Vector3 spawnValues; // used to set random spawn position on X-axis.

	void Start()
	{
		SpawnWaves (); //Calls SpawnWaves function on the start of the game
	}
	void SpawnWaves()
	{
		Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x),spawnValues.y,spawnValues.z);
		//Generates random hazard. y and z are static values, x is Randomly generated
		//by Ramdon.Range function
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (hazard, spawnPosition, spawnRotation);
	}

}
