using UnityEngine;
using System.Collections;

public class HideInstructions : MonoBehaviour 
{

	public GameObject instructions;
	public GameObject ui;
	public PlayerController player;
	public SpiritAI spirit;
	private bool show;

	// Use this for initialization
	void Start () 
	{
		player = FindObjectOfType<PlayerController>();
		spirit = FindObjectOfType<SpiritAI> ();
		show = true;
		ui.GetComponent<CanvasGroup> ().alpha = 0f;
	}
		
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.E))
		{
			show = false;
			player.canMove = true;
			spirit.canMove = true;
			instructions.SetActive (show);
			ui.GetComponent<CanvasGroup>().alpha = 1f;
		}
	}
}
