using UnityEngine;
using System.Collections;

public class LayerOrder : MonoBehaviour 
{
	public GameObject characterTarget;				//player object
	private SpriteRenderer characterSprite;			//player sprite
	private PlayerController thePlayer;

	private Vector3 targetPos;

	public GameObject topRoom, bottomRoom, mainRoom;
	public GameObject sitOnWall;

	private RoomScanner topRoomChecker, bottomRoomChecker, mainRoomChecker;

	private SpriteRenderer thisSprite;
	private Color opacity;

	int characterOrder;
	int defaultOrder;

	public int newOrder;
	private bool roomPresenceTop, roomPresenceBottom, roomPresenceMain;
//	private bool playerPresenceTop, playerPresenceBottom, playerPresenceMain;
//	private bool dollPresenceTop, dollPresenceBottom, dollPresenceMain;

	public bool keepThisWallOnBottom;
	public bool keepSittingOnWall;
	public bool turnTransparent = false;
	public int layerDiff;


	// Use this for initialization
	void Start () 
	{
		thePlayer = FindObjectOfType<PlayerController> ();
		characterSprite = characterTarget.GetComponent<SpriteRenderer> ();

		thisSprite = GetComponent<SpriteRenderer> ();
		opacity = thisSprite.GetComponent<SpriteRenderer>().color;

		defaultOrder = thisSprite.sortingOrder;
		characterOrder = characterSprite.sortingOrder;

		topRoomChecker = topRoom.GetComponent<RoomScanner> ();
		bottomRoomChecker = bottomRoom.GetComponent<RoomScanner> ();
		mainRoomChecker = mainRoom.GetComponent<RoomScanner> ();


	}
		
	// Update is called once per frame
	void Update () 
	{
//		Debug.Log (defaultOrder);
	//	Debug.Log ("Player: " + characterOrder);
		
		//set & refresh targetPosition
		targetPos = new Vector3 (characterTarget.transform.position.x, characterTarget.transform.position.y, transform.position.z); 

		//set & refresh room presence
		roomPresenceTop = topRoomChecker.getRoomPresence();
		roomPresenceBottom = bottomRoomChecker.getRoomPresence ();
		roomPresenceMain = mainRoomChecker.getRoomPresence ();

//		playerPresenceTop = topRoomChecker.getPlayerPresence();
//		playerPresenceBottom = bottomRoomChecker.getPlayerPresence ();
//		playerPresenceMain = mainRoomChecker.getPlayerPresence ();
//
//		dollPresenceTop = topRoomChecker.getDollPresence();
//		dollPresenceBottom = bottomRoomChecker.getDollPresence ();
//		dollPresenceMain = mainRoomChecker.getDollPresence ();
	
//		Debug.Log (thisSprite + " In da top room? " + roomPresenceTop);
//		Debug.Log (thisSprite + "In da bottom room? " + roomPresenceBottom);
//		Debug.Log (thisSprite + "In da main room? " + roomPresenceMain);

		//if the player is in the room that wall is above
		if (roomPresenceBottom == true) 
		{

				thisSprite.sortingOrder = newOrder; // move wall behind player


			if (roomPresenceBottom == roomPresenceMain) 
			{
				// if the doll is in an adjacent room and the player is in a room needing a transparent wall
//				if ((bottomRoomChecker.getCharacter () == "doll" || mainRoomChecker.getCharacter () == "doll")
//				    && topRoomChecker.getCharacter () == "player") 
//				{
					if (turnTransparent) {
						opacity.a = 0.75f;
						thisSprite.GetComponent<SpriteRenderer> ().color = opacity;
					}
//				} 

				else 
				{
					opacity.a = 1f;
					thisSprite.GetComponent<SpriteRenderer> ().color = opacity;
				}
				sitOnWall.GetComponent<SpriteRenderer>().sortingOrder = thisSprite.sortingOrder - 2;
			}

		} 

		//if the player is in the room that wall is below
		else if (roomPresenceTop == true)
		{ 
				thisSprite.sortingOrder = defaultOrder; //draw player behind wall

//			if (topRoomChecker.getDollRoom() == topRoomChecker.getRoomName()) {
//				thisSprite.sortingOrder = newOrder;
//			}

			if (this.characterTarget.name == "testDoll") 
			{
				Debug.Log ("piece of shit");
			}

			if (turnTransparent) 
			{
//				if (topRoomChecker.getCharacter() == "player") {
					opacity.a = 0.75f;
					thisSprite.GetComponent<SpriteRenderer> ().color = opacity;
//				} 
			}
		}

//		else if (roomPresenceTop == false && roomPresenceMain == true)
//		{
//			sitOnWall.GetComponent<SpriteRenderer>().sortingOrder = thisSprite.sortingOrder - 1;
//		}

		//player is somewhere else in the house
		else
		{
			thisSprite.sortingOrder = defaultOrder;

			if (keepThisWallOnBottom) 
			{
				if (roomPresenceBottom == false && roomPresenceMain == false) 
				{
					thisSprite.sortingOrder = newOrder;
				}
			} 

			if (keepSittingOnWall) 
			{
				if (roomPresenceBottom == false && roomPresenceMain == false) 
				{
					sitOnWall.GetComponent<SpriteRenderer>().sortingOrder = thisSprite.sortingOrder + layerDiff;
				}
			}

				opacity.a = 1f;
				thisSprite.GetComponent<SpriteRenderer>().color = opacity;			
		}
	
	}
}
