using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour 
{

	public PlayerController player;
	private bool show;


	public string startLevel;

	// Use this for initialization
	void Start () 
	{
//		player.Inventory.Count = 3;
	}

	// Update is called once per frame
	void Update () 
	{


		if (player.Inventory.Count >= 3)
		{
			//			Debug.Log ("DEADD");
			//			show = true;
			//			player.canMove = false;
			//			deathScreen.SetActive (show);
			SceneManager.LoadScene (startLevel); 
		}
	}
}
