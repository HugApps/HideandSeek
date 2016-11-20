using UnityEngine;
using System.Collections;

public class DollTester : MonoBehaviour {


	public float moveSpeed;
	private Rigidbody2D myRigidbody;
	private bool playerMoving;
	private Vector2 lastMove;

	public float moveAngleVert;
	public float moveAngleHorz;

	public bool canMove;

	// bool collide;
	//	public string startPoint;

	Animator animator;

	const int walkBACK = 0;

	const int walkFRONT = 1;

	const int walkLEFT = 2;

	const int walkRIGHT = 3;

	int currentAnimationState = walkFRONT;

	string lastMovement;

	// Use this for initialization
	void Start () 
	{
		myRigidbody = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();

		//		if (!playerExists) {
		//				playerExists = true; 
		//				DontDestroyOnLoad (transform.gameObject); 
		//			} else {
		//				Destroy (gameObject);
		//			}
	}


	// Update is called once per frame
	void Update () 
	{

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
			//			lastMovement = "FRONT";
			//lastMove = new Vector2 ( 0f, Input.GetAxisRaw ("Vertical"));
		}

		//move up
		if (Input.GetAxisRaw ("Vertical") > 0.5f) 
		{
			transform.Translate (new Vector3 (moveAngleVert, Input.GetAxisRaw ("Vertical") * moveSpeed, 0f));
			playerMoving = true;
			//			lastMovement = "BACK";
			//lastMove = new Vector2 ( 0f, Input.GetAxisRaw ("Vertical"));
		}

		//stop movement
		if (Input.GetAxisRaw ("Horizontal") < 0.5f && Input.GetAxisRaw ("Horizontal") > -0.5f) {

			myRigidbody.velocity = new Vector2 (0f, myRigidbody.velocity.y);

		}

		if (Input.GetAxisRaw ("Vertical") < 0.5f && Input.GetAxisRaw ("Vertical") > -0.5f) {

			myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, 0f);
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

		if (Input.GetKeyDown (KeyCode.DownArrow)) 
		{
			changeState (walkBACK);
			lastMovement = "BACK";
		}

		if (Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			changeState (walkFRONT);
			lastMovement = "FRONT";
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

		case walkBACK:
			animator.SetInteger ("state", walkBACK);
			Debug.Log ("UP");
			break;

		case walkFRONT:
			animator.SetInteger ("state", walkFRONT);
			Debug.Log ("DOWN");
			break;

		case walkLEFT:
			animator.SetInteger ("state", walkLEFT);
			Debug.Log ("LEFT");
			break;

		case walkRIGHT:
			animator.SetInteger ("state", walkRIGHT);
			Debug.Log ("RIGHT");
			break;



		}

		currentAnimationState = state;
	}
}
