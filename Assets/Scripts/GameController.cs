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

	public GUIText scoreText; // reference to GUIText component on the screen
	private int score; //cotains current score, not visible in the inspector because of privacy
	public GUIText restartText;
	public GUIText gameOverText;

	private bool gameOver;
	private bool restart;

	void Start()
	{
		gameOver = false;
		restart = false;
		restartText.text = ""; //Setting restart text to nothing in the beginning of the game
		gameOverText.text = "";
		score = 0;
		UpdateScore (); //To display Score: {}
		StartCoroutine(SpawnWaves ()); //Calls SpawnWaves function on the start of the game
	}

	void Update()
	{
		if (restart) 
		{
			if(Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel(Application.loadedLevel); /*loads the scene in the(),
				in our case loadLevel. */ 
			}
		}
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
			if(gameOver)
			{
				restartText.text = "Press 'R' to Restart ;)";
				restart = true;
				break; //let's kill this infinite loop :3
					
			}
		}
	}

	public void AddScore(int newScoreValue) // public - to be accesible by everywhere
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score; //Displays the current score 
	}

	public void GameOver()
	{
		gameOverText.text = "Shiiiet son, you're fuckin' dead!";
		gameOver = true;
	}

}
