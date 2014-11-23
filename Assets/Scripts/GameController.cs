using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float InitialHazardSpeed;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public GUIText scoreText;
	public GUIText restartText;
	public GUIText GameOverText;
	public GUIText GameStats;
	public GUIText HighScoreText;

	private int score;
	private int shotsFired;
	private int totalHazardsSpawned;
	private bool gameOver;
	private bool restart;
	private float speedOffset;
	private static int highScore = 0;

	void Start()
	{
		score = 0;
		shotsFired = 0;
		gameOver = false;
		restart = false;
		restartText.text = string.Empty;
		GameOverText.text = string.Empty;
		GameStats.text = string.Empty;
		speedOffset = 0f;
		UpdateScore();
		StartCoroutine(SpawnWaves());
	}

	void Update()
	{
		if(restart)
		{
			if(Input.GetKeyDown (KeyCode.R))
				Application.LoadLevel (Application.loadedLevel);
		}
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds(startWait);
		while(true)
		{
			for (int i = 0;i < hazardCount; i++)
			{
				++totalHazardsSpawned;
				Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x),spawnValues.y,spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				GameObject clone = (GameObject)Instantiate(hazard, spawnPosition, spawnRotation);
				clone.rigidbody.AddForce(clone.transform.forward  * (InitialHazardSpeed - speedOffset));
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);

			if (gameOver)
			{
				restartText.text = "Press 'R' to Restart";
				restart = true;
				break;
			}
		}
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		if(score > highScore)
			highScore = score;
		UpdateScore();
		if(score > 1 && score % 120 == 0)
		{
			hazardCount += Random.Range(1, 3);
			speedOffset += 50f; //(Random.Range(-5f, 20f) * 10);
		}
	}

	public void AddShot()
	{
		shotsFired++;
	}

	public void GameOver()
	{
		GameOverText.text = "Game Over!";
		GameStats.text = GameStatsText();
		gameOver = true;
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score.ToString();
		HighScoreText.text = "High Score: " + highScore.ToString();
	}

	public string GameStatsText()
	{
		int tempScore = this.score/10;
		float e1 = ((float)tempScore/(float)totalHazardsSpawned) * 100f;
		float a1 = (((float)tempScore/(float)this.shotsFired)) * 100f;

		return string.Format("Total Asteroids: {0}\nAsteroids Destroyed: {1} ({2}%)\nShots Fired: {3} ({4}%)",
		                     totalHazardsSpawned.ToString(),
		                     tempScore.ToString(),
		                     e1.ToString("F1"),
		                     this.shotsFired.ToString(),
		                     a1.ToString("F1")
		                     );
	}
}
