using UnityEngine;
using System.Collections;

public class SpiritAI : MonoBehaviour {

	// Use this for initialization

    public Vector2  UP = new Vector2(1,1);
    public Vector2 LEFT = new Vector2(-1,1);
    public Vector2 RIGHT = new Vector2(1,-1);
    public Vector2 DOWN = new Vector2(-1, -1);
	public Vector2 SCAN_RIGHT = new Vector3 (1,0,-1);
	public Vector2 SCAN_LEFT  = new Vector3(0,0,1);


	private float speed =1f;
    private Vector2 CurrentDirection;
    private BoxCollider2D collider;
	private int Memory_counter;
	private ArrayList Scanned_Objects;
	public ArrayList Rooms;
	public ArrayList SearchedRooms;
	public int roomsearched;
	private int Power;
	private GameObject target;

	public bool canMove;

	private bool Spotted=false;
	private bool Caught = false;
	private bool scan_room = false;
	private bool readjust=false;
	private int retardcount;
	GameObject cone;
	GameObject WayPoints;





	void Start () {
		 roomsearched = 0;
		 cone = GameObject.Find ("vision-cone");
		WayPoints = GameObject.Find ("Waypoints");
		Rooms = new ArrayList ();
		SearchedRooms = new ArrayList ();
		Rooms.Add ( GameObject.Find ("A"));
		Rooms.Add (GameObject.Find ("B"));
		Rooms.Add (GameObject.Find ("C"));
		Rooms.Add (GameObject.Find ("D"));
		Rooms.Add (GameObject.Find ("E"));
		Rooms.Add (GameObject.Find ("F"));

		//Rooms.Sort ();
        CurrentDirection = UP;

		Power = 0;
		speed = 1*Time.deltaTime;
		Memory_counter = 0;
		Scanned_Objects = new ArrayList();
        //get reference to box collider at game start
	}
	
	void Update () 
	{
		if (!canMove) 
		{
			return;
		}

		
		if (Spotted) {
			SearchForPlayer ();
			return;
		}
		if (readjust) {
			MoveBot (CurrentDirection);
			return;
		}

		//MoveBot (UP);
		if (Power < 50) {
			speed = Time.deltaTime;
			Power++;
		} else {
			speed = 3 * speed;
			Power = 0;
		}
		if (Memory_counter == 0) {
			SearchForPlayer ();
			return;
		} else {
			MoveBot (CurrentDirection);
			Memory_counter--;
			return;
		}
	}



	void SearchForPlayer (){
		
		if (this.Scanned_Objects.Capacity==0 || this.Scanned_Objects==null) {


			foreach (GameObject item in this.Rooms) {
//				print (item.name);
				if (!SearchedRooms.Contains (item)) {
					
					target = item;
					transform.position = Vector2.MoveTowards (transform.position, target.transform.position, Time.deltaTime);

					return;

				} 
			}
		} else{	
			//checked Scanned objects
			checkScannedObjects();}							
	}

	public void checkScannedObjects(){
		Vector2 lockVector;
		foreach (GameObject item in this.Scanned_Objects) {
			if (item.name == "Player") {
				// Found Character move towards
				transform.position = Vector2.MoveTowards (transform.position, item.transform.position,3*Time.deltaTime);

				//Memory_counter++;
				Power--;
				CurrentDirection = transform.position;
				Spotted = true;
			}
		 	
		}
	}
	public void AddScannedObjects(GameObject found){

		if (found.name == "Player") {
			this.Scanned_Objects.Add (found);


		}

	}

	public void RemoveScannedObjects(GameObject forgot){
		//print ("removing");

		foreach (GameObject item in this.Scanned_Objects) {
			if (item.name == "Player") {
				// Found Character move towards
				this.Scanned_Objects.Remove(item);

				//Vector2.MoveTowards (transform.position, target.transform.position,speed*Time.deltaTime);
				readjust=false;


				//CurrentDirection = Vector2.MoveTowards (transform.position, target.transform.position,Time.deltaTime);
				Spotted = false;
				Scanned_Objects = new ArrayList ();
				return;
			}

		}

	}


    void MoveBot(Vector2 direction)
    {
        // makes sure it moves in m/s
        transform.Translate(direction * Time.deltaTime);
    }

   
    void OnCollisionEnter2D(Collision2D hit)
    {	

		// Calculate its distance away from target 
		Spotted=false;

		float x = target.transform.position.x;
		float y = target.transform.position.y;

		if (CurrentDirection == UP || CurrentDirection == DOWN) {

			if (x > transform.position.x ) {
				CurrentDirection = RIGHT;
			} else if(x<transform.position.x){
				CurrentDirection = LEFT;
			}else {
				CurrentDirection = -CurrentDirection;}
	

		} else if (CurrentDirection == RIGHT || CurrentDirection == LEFT) {
			

			if (y > transform.position.y) {
				CurrentDirection = UP;
			} else if(y< transform.position.y) {
				CurrentDirection = DOWN;
			}
			else{
				CurrentDirection = -CurrentDirection;
			}


		} else {
			CurrentDirection = -CurrentDirection;
		}


		//CurrentDirection = -CurrentDirection;
		//print (CurrentDirection);
		readjust = true;
	
		if (hit.gameObject.name == "Player") 
		{


			return;
		}
		//MoveBot (-CurrentDirection);
		
    }

	void OnColissionExit2D(Collision2D hit){
		//CurrentDirection = -CurrentDirection;
		readjust = false;


	}

	void OnCollisionStay2D(Collision2D hit){
		// Calculate its distance away from target 
		retardcount++;
		if (retardcount > 100) {
			transform.position = target.transform.position;
			retardcount = 0;
			return;
		}
//		print(hit.gameObject.name);
		readjust = false;

	}






    // Sets up intial settings before script enabled of game objects
    //
    void Awake() { }

    // detect physics step
    // called in fixed intervals.
    

    // Movement functions - takes in 

  
}
