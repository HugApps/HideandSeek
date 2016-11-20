using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Refresh : MonoBehaviour {

	// Use this for initialization
	void Start () {

		SceneManager.UnloadScene ("Title");
		SceneManager.UnloadScene ("Dead");
		SceneManager.UnloadScene ("Win");

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
