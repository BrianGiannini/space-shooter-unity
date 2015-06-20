using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

	
	public void Click(){
		Application.LoadLevel(Application.loadedLevel);
		Debug.Log ("Click");
	}

}
