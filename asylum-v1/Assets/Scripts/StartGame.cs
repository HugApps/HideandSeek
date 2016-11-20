using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	private CanvasGroup canvasGroup;
	public string startLevel;

	public void Play(){

		SceneManager.LoadScene (startLevel); 
	}

	public void QuitGame(){
		Application.Quit();
	}



	void Start () 
	{

	}

	// Update is called once per frame
	void Update () {

	}
}

