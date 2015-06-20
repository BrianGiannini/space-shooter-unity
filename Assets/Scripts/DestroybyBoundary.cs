using UnityEngine;
using System.Collections;

public class DestroybyBoundary : MonoBehaviour {

	void OnTriggerExit(Collider other) {
		Destroy(other.gameObject);
	}
}
