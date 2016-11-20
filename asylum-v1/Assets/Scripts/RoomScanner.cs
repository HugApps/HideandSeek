using UnityEngine;
using System.Collections;

public class RoomScanner : MonoBehaviour 
{

	private GameObject characterTarget;
	private PlayerController thePlayer;

	public bool inRoom, playerInRoom, dollInRoom;
	public bool transparency;
	public string character;
	public string dollRoomName;
	public string playerRoomName;
	public string thisRoomName;

	// Use this for initialization
	void Start () 
	{
		thePlayer = FindObjectOfType<PlayerController> ();	
	}

	public void RoomCheck (bool value)
	{
		inRoom = value;
	}

	public bool getRoomPresence()
	{
		return inRoom;
	}

	public bool getPlayerPresence()
	{
		return playerInRoom;
	}

	public bool getDollPresence()
	{
		return dollInRoom;
	}

	public string getRoomName()
	{
		thisRoomName = this.gameObject.name;
		return thisRoomName;
	}

	public bool enableTransparency()
	{
		return transparency;
	}

	public string getCharacter()
	{
		return character;
	}

	public string getDollRoom()
	{
		return dollRoomName;
	}

	public string getPlayerRoom()
	{
		return playerRoomName;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
//		inRoom = true;

//		Debug.Log ("IN DA ROOM");
		if (other.gameObject.name == "Player") {
//			this.thePlayer.RoomCheck (true);
			inRoom = true;
			playerInRoom = true;
			transparency = true;
			character = "player";
			playerRoomName = this.gameObject.name;
		} 
			
//		else if (other.gameObject.name == "doll") 
//		{
//			Debug.Log ("DOLL");
//			inRoom = true;
//			dollInRoom = true;
//			character = "doll";
//			dollRoomName = this.gameObject.name;
//		}
//
//		else if (other.gameObject.name == "testDoll") 
//		{
//			Debug.Log ("DOLL");
//			inRoom = true;
//			character = "doll";
//			dollRoomName = this.gameObject.name;
//		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
//		Debug.Log ("NOT IN DA ROOM");
//		this.thePlayer.RoomCheck (false);

		if (other.gameObject.name == "Player") {
			inRoom = false;
			character = "none";
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
