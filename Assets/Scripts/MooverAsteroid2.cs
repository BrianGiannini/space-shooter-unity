using UnityEngine;
using System.Collections;

public class MooverAsteroid2 : MonoBehaviour {

	public float speed;
	private int temp;
	
	void Start ()
	{
		temp = Random.Range (1, 5);
		//Debug.Log (temp);
		if (temp == 1) {
			GetComponent<Rigidbody> ().velocity = (transform.forward * 3 * speed) + (transform.right * speed);
		} else if (temp == 2 || temp == 3) {
			GetComponent<Rigidbody> ().velocity = (transform.forward * 3 * speed);
		}else if (temp == 4) {
			GetComponent<Rigidbody> ().velocity = (transform.forward * 3 * speed) + (-transform.right * speed);
		}

	}

}
