using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject hazard;
	public GameObject hazard2;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWaitMin;
	public float spawnWaitMax;
	public float startWait;
	public float waveWait;
	
	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	public GUIText WavesText;

	private bool gameOver;
	private int score;
	public static int waveCount;
	
	void Start ()
	{
		gameOver = false;
		restartText.text = "";
		gameOverText.text = "";
		WavesText.text = "Wave 1";
		score = 0;
		waveCount = 1;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.R)) {
		Application.LoadLevel(Application.loadedLevel);
		}
	}
		
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				if(i % 5 == 1){
					spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
					spawnRotation = Quaternion.identity;
					Instantiate (hazard2, spawnPosition, spawnRotation);
				}
				yield return new WaitForSeconds (Random.Range (spawnWaitMin,spawnWaitMax));
			}
			yield return new WaitForSeconds (waveWait);
			if (gameOver == false){
				NextWave();
			}
			else if(gameOver)
			{
				break;
			}
			yield return new WaitForSeconds (waveWait+1);
			gameOverText.text = "";
		}
	}
	
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	
	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver()
	{
		gameOverText.text = "Game Over";
		gameOver = true;
	}

	
	public void NextWave()
	{

		waveCount++;
		if (spawnWaitMax > 0.05) {			
			spawnWaitMax -= 0.05f;
		}
		if (waveCount == 3 || waveCount == 5 || waveCount == 7 || waveCount == 9 || waveCount == 12) {
			spawnWaitMin -= 0.01f;
		}
		hazardCount += 10;
		score = score + (waveCount*2+(waveCount*10));
		UpdateScore ();
		WavesText.text = "Wave "+waveCount;

		gameOverText.text = "Bonus "+ ((waveCount*2+(waveCount*10))) + " points !";
	}
}