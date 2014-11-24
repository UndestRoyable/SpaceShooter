using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject hazard;
	public Vector3 spawnValues; // used to set random spawn position on X-axis.

	public int hazardCount;
	public float spawnWait;//wait time th throw next asteroid
	public float startWait;//wait on game start so the player can get ready.
	public float waveWait; //time to wait between the waves

	void Start()
	{
		StartCoroutine(SpawnWaves ()); //Calls SpawnWaves function on the start of the game
	}
	IEnumerator SpawnWaves() //using coroutine
	{
		yield return new WaitForSeconds(startWait);/*short pause in the beginning of the game, 
		so the player will have time to get ready.*/
		while(true)//a little bit of infinite loop :3 :D
		{
			for (int i = 0; i < hazardCount; i++) 
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				//Generates random hazard. y and z are static values, x is Randomly generated
				//by Ramdon.Range function
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(spawnWait); // Waits some time before throw new asteroid.
			}
			yield return new WaitForSeconds(waveWait);
		}
	}

}
