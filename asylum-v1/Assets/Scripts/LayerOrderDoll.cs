using UnityEngine;
using System.Collections;

public class LayerOrderDoll : MonoBehaviour 
{
	public GameObject characterTarget;				//player object
	public GameObject dollTarget;
	private SpriteRenderer characterSprite;			//player sprite
	private SpriteRenderer dollSprite;
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

	public bool keepThisWallOnBottom;
	public bool keepSittingOnWall;
	public bool turnTransparent = false;
	public int layerDiff;


	// Use this for initialization
	void Start () 
	{
//		thePlayer = FindObjectOfType<PlayerController> ();
		characterSprite = characterTarget.GetComponent<SpriteRenderer> ();
		dollSprite = dollTarget.GetComponent<SpriteRenderer> ();

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

		//		Debug.Log (thisSprite + " In da top room? " + roomPresenceTop);
		//		Debug.Log (thisSprite + "In da bottom room? " + roomPresenceBottom);
		//		Debug.Log (thisSprite + "In da main room? " + roomPresenceMain);

		//if the player is in the room that wall is above
		if (roomPresenceBottom == true) 
		{
			thisSprite.sortingOrder = newOrder; // draw player above wall

			if (roomPresenceBottom == roomPresenceMain) 
			{
				opacity.a = 1f;
				thisSprite.GetComponent<SpriteRenderer> ().color = opacity;
				sitOnWall.GetComponent<SpriteRenderer>().sortingOrder = thisSprite.sortingOrder - 2;
			}

		} 

		//if the player is in the room that wall is below
		else if (roomPresenceTop == true)
		{ 
			thisSprite.sortingOrder = defaultOrder; //draw player behind wall

			if (this.characterTarget.name == "testDoll") 
			{
				Debug.Log ("the piece of shit");
			}

			if (turnTransparent && topRoomChecker.getCharacter() == "Player") 
			{
				opacity.a = 0.8f;
				thisSprite.GetComponent<SpriteRenderer> ().color = opacity;
			}

		}

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
