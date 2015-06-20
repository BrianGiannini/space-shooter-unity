using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin,xMax,zMin,zMax;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;


	void Update ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource>().Play();
		}
	}

	void FixedUpdate()
	{ 
		if (Application.platform == RuntimePlatform.Android) {

			//float moveHorizontal = Input.GetTouch(0);
			//float moveVertical = Input.GetTouch(0);

			//Vector3 movemnent = new Vector3 (moveHorizontal, 0.0f, moveVertical);
			//GetComponent<Rigidbody> ().velocity = movemnent * speed;

		} else {

			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");
		
			Vector3 movemnent = new Vector3 (moveHorizontal, 0.0f, moveVertical);
			GetComponent<Rigidbody> ().velocity = movemnent * speed;

		}

		GetComponent<Rigidbody>().position = new Vector3 
		(
			Mathf.Clamp(GetComponent<Rigidbody>().position.x,boundary.xMin,boundary.xMax),
			0.0f,
			Mathf.Clamp(GetComponent<Rigidbody>().position.z,boundary.zMin,boundary.zMax)
		);

		GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody> ().velocity.x * -tilt);
	}
}
