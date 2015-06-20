using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	public int hp;
	private GameController gameController;
	
	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}
	
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Boundary")
		{
			return;
		}

		if (other.tag == "Player")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			Destroy(other.gameObject);//kill the player
			gameController.GameOver();
		}

		if (other.tag == "shot") 
		{
			hp--;
			Instantiate(explosion, transform.position, transform.rotation);
			Destroy (other.gameObject); //kill the shot
			if(hp==0){
				Destroy(gameObject);//kill the asteroid
				gameController.AddScore (scoreValue+GameController.waveCount);
			}
		}
	}
}