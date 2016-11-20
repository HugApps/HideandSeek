using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerController2 : MonoBehaviour
{

	public float moveSpeed;
	private Rigidbody2D myRigidbody;
	private bool playerMoving;
	private Vector2 lastMove;
	private int searchprogress;
	public float moveAngleVert;
	public float moveAngleHorz;
	public ArrayList Inventory;
	public bool canMove;
	private Furniture ff;
	private bool inRoom;
	public Text status;
	// bool collide;
	//	public string startPoint;

	Animator animator;

	const int restUP = 0;
	const int walkUP = 1;

	const int restDOWN = 2;
	const int walkDOWN = 3;

	const int restLEFT = 4;
	const int walkLEFT = 5;

	const int restRIGHT = 6;
	const int walkRIGHT = 7;
	private bool searchable;
	int currentAnimationState = walkUP;
	private ArrayList Rooms;
	string lastMovement;

	public Slider sanityslider;
	public Slider searchslider;
	GameObject hideslider;
	public int Sanity = 10;
	Canvas canvas;
	// Use this for initialization
	void Start () 
	{



		sanityslider = GameObject.Find ("sanityslider").GetComponent<Slider>();
		searchslider = GameObject.Find ("searchprogress").GetComponent<Slider> ();
		status = GameObject.Find ("searchtext").GetComponent<Text> ();
		status.gameObject.SetActive (false);
		hideslider = searchslider.gameObject;
		//status =hideslider.GetComponent<Text> ();

		hideslider.SetActive (false);
		//sanityslider=test.GetComponent<Slider> ();
		searchslider.minValue=0;
		searchslider.maxValue = 50;
		sanityslider.maxValue = this.Sanity;
		sanityslider.minValue = 0;
		Inventory = new ArrayList ();
		myRigidbody = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		Rooms = new ArrayList ();
		Rooms.Add ( GameObject.Find ("master bedroom"));
		Rooms.Add (GameObject.Find ("kid bedroom"));
		Rooms.Add (GameObject.Find ("office"));
		Rooms.Add (GameObject.Find ("foyer"));
		Rooms.Add (GameObject.Find ("kitchen"));
		Rooms.Add (GameObject.Find ("bathroom"));
		Rooms.Add (GameObject.Find ("pantry"));
		Rooms.Add (GameObject.Find ("living room"));// Intialize random assignment of keys 
		searchable=false;


		for (int i = 1; i <= 3; i++)
		{

			// For each key randomly select a room
			int key = Random.Range (1, 9);
			int roomNum = key % 8;
			GameObject targetroom = (GameObject) Rooms [roomNum];
			GameObject furniture = targetroom.transform.GetChild (key % targetroom.transform.childCount).gameObject;
			//print (furniture.name);
			ff = furniture.GetComponent<Furniture> ();
			ff.setkey (i);
		}
		//		if (!playerExists) {
		//				playerExists = true; 
		//				DontDestroyOnLoad (transform.gameObject); 
		//			} else {
		//				Destroy (gameObject);
		//			}
	}

	//	public void RoomCheck (bool value)
	//	{
	//		inRoom = value;
	//	}
	//
	//	public bool getRoomPresence()
	//	{
	//		return inRoom;
	//	}

	// Update is called once per frame
	void Update () 
	{

		//		Debug.Log (currentAnimationState);
		if (Inventory.Count >= 3) {
			print ("GAME OVER YOU WIN");
			Time.timeScale = 0;
			return;
		}

		if (!canMove) 
		{
			return;
		}

		playerMoving = false;

		//move left
		if (Input.GetAxisRaw ("Horizontal") < -0.5f) 
		{
			transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * (moveSpeed*2), moveAngleHorz, 0f));
			playerMoving = true;
			//			lastMovement = "LEFT";
			//lastMove = new Vector2 ( 0f, Input.GetAxisRaw ("Vertical"));
		}

		//move right
		if (Input.GetAxisRaw ("Horizontal") > 0.5f) 
		{
			transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * (moveSpeed*2), -moveAngleHorz, 0f));
			playerMoving = true;
			//			lastMovement = "RIGHT";
			//lastMove = new Vector2 ( 0f, Input.GetAxisRaw ("Vertical"));
		}

		//move down
		if (Input.GetAxisRaw ("Vertical") < -0.5f) 
		{

			transform.Translate (new Vector3 (-moveAngleVert, Input.GetAxisRaw ("Vertical") * moveSpeed, 0f));
			playerMoving = true;
			//lastMovement = "DOWN";
			//lastMove = new Vector2 ( 0f, Input.GetAxisRaw ("Vertical"));
		}

		//move up
		if (Input.GetAxisRaw ("Vertical") > 0.5f) 
		{
			transform.Translate (new Vector3 (moveAngleVert, Input.GetAxisRaw ("Vertical") * moveSpeed, 0f));
			playerMoving = true;
			//			lastMovement = "UP";
			//lastMove = new Vector2 ( 0f, Input.GetAxisRaw ("Vertical"));
		}

		//stop movement
		if (Input.GetAxisRaw ("Horizontal") < 0.5f && Input.GetAxisRaw ("Horizontal") > -0.5f) {

			myRigidbody.velocity = new Vector2 (0f, myRigidbody.velocity.y);

			if (lastMovement == "LEFT") 
			{
				changeState (restLEFT);
			}

			else if (lastMovement == "RIGHT") 
			{
				changeState (restRIGHT);
			}

		}

		if (Input.GetAxisRaw ("Vertical") < 0.5f && Input.GetAxisRaw ("Vertical") > -0.5f) {

			myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, 0f);

			if (lastMovement == "UP") 
			{
				changeState (restUP);
			}

			else if (lastMovement == "DOWN") 
			{
				changeState (restDOWN);
			}
		}

		if (Input.GetKeyUp (KeyCode.RightArrow)) 
		{
			changeState (restRIGHT);
		}

		else if (Input.GetKeyUp (KeyCode.LeftArrow)) 
		{
			changeState (restLEFT);
		}

		else if (Input.GetKeyUp (KeyCode.UpArrow)) 
		{
			changeState (restUP);
		}

		else if (Input.GetKeyUp (KeyCode.DownArrow)) 
		{
			changeState (restDOWN);
		}

		// keyboard input //
		if (Input.GetKeyDown (KeyCode.RightArrow))
		{
			changeState (walkRIGHT);
			lastMovement = "RIGHT";
		}

		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			changeState (walkLEFT);
			lastMovement = "LEFT";
		}

		if (Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			changeState (walkUP);
			lastMovement = "UP";
		}

		if (Input.GetKeyDown (KeyCode.DownArrow)) 
		{
			changeState (walkDOWN);
			lastMovement = "DOWN";
		}


		if (Input.GetKeyDown (KeyCode.E)) {

			if(searchable && ff!=null){

				if(searchprogress <50){
					status.gameObject.SetActive (true);
					status.color = Color.white;
					searchprogress++;
					searchslider.value=searchprogress++;
					status.text =("Searching...." );
					return;
				}



				int key = ff.getKey ();
				if (key > 0) {

					this.Inventory.Add (key);
					print ("FOUNDKEY");
					status.text = "I Found something!";
					status.color = Color.green;
					status.gameObject.SetActive (true);
				}
				status.text = "NOTHING HERE";
				status.color = Color.red;
				searchslider.value = 0;
				hideslider.SetActive (false);
				this.searchprogress = 0;
				status.gameObject.SetActive (false);


			}



		}
	}
	//--------------------------------------
	// Change the players animation state
	//--------------------------------------
	void changeState(int state)
	{

		if (currentAnimationState == state)
			return;

		switch (state) 
		{

		case restUP:
			animator.SetInteger ("state", restUP);
			break;

		case walkUP:
			animator.SetInteger ("state", walkUP);
			//			Debug.Log ("UP");
			break;

		case restDOWN:
			animator.SetInteger ("state", restDOWN);
			//			Debug.Log ("DOWN");
			break;

		case walkDOWN:
			animator.SetInteger ("state", walkDOWN);
			//			Debug.Log ("DOWN");
			break;

		case restLEFT:
			animator.SetInteger ("state", restLEFT);
			//			Debug.Log ("LEFT");
			break;

		case walkLEFT:
			animator.SetInteger ("state", walkLEFT);
			//			Debug.Log ("LEFT");
			break;

		case restRIGHT:
			animator.SetInteger ("state", restRIGHT);
			//			Debug.Log ("RIGHT");
			break;

		case walkRIGHT:
			animator.SetInteger ("state", walkRIGHT);
			//			Debug.Log ("RIGHT");
			break;



		}

		currentAnimationState = state;
	}



	void OnCollisionExit2D(Collision2D coll){

		hideslider.SetActive (false);


	}


	void OnCollisionEnter2D(Collision2D coll){
		//print (coll.gameObject.name);


		if (coll.gameObject.name == "doll") {
			this.Sanity--;
			this.sanityslider.value = this.Sanity;



			return;
		}

		GameObject target = GameObject.Find (coll.gameObject.name);
		this.ff = target.GetComponent<Furniture> ();
		if (ff == null) {
			hideslider.SetActive (false);
			return;
		} else {
			this.searchable = true;

			hideslider.SetActive (true);
			searchslider.value = 0;
			searchslider.minValue = 0;
			searchslider.maxValue = 50;
			return;

		}



	}
	//	public void RespawnPlayer(){
	//		this.transform.position = respawnPoint.transform.position;  
	//		//Debug.Log ("playerrespawn");
	//	}
	//
	//	private void OnTriggerEnter2D(Collider2D other)
	//	{
	//		if (other.tag == "Item") //If we collide with an item that we can pick up
	//		{
	//			inventory.AddItem(other.GetComponent<Item>()); //Adds the item to the inventory.
	//		}
	//	}


}
