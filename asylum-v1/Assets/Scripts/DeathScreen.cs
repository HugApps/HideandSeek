using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour 
{

	public PlayerController player;
	private bool show;


	public string startLevel;

	// Use this for initialization
	void Start () 
	{
	}

	// Update is called once per frame
	void Update () 
	{
		if (player.playerDead)
		{
//			Debug.Log ("DEADD");
//			show = true;
//			player.canMove = false;
//			deathScreen.SetActive (show);
			SceneManager.LoadScene (startLevel); 
		}
	}
}
