using UnityEngine;
using System.Collections;

public class Waypoints : MonoBehaviour {

	// Use this for initialization
	GameObject spirit;
	SpiritAI spirit_script;
	int roomcount=0;
	void Start () {
		spirit = GameObject.Find ("doll");
		this.spirit_script = spirit.GetComponent<SpiritAI> ();
		print (spirit.name);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	void OnTriggerStay2D(Collider2D target)
	{
		print ("Room reached");
		spirit_script.SearchedRooms.Add (gameObject);
		//spirit_script.Rooms.Remove(gameObject);
		if (gameObject.name == "F") {
			spirit_script.SearchedRooms = new ArrayList ();
		}

	}
}
