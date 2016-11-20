using UnityEngine;
using System.Collections;

public class ConeScanner : MonoBehaviour {
	

	GameObject spirit;
	SpiritAI spirit_script;
	// Use this for initialization
	void Start () {
		spirit = GameObject.Find ("doll");
		this.spirit_script = spirit.GetComponent<SpiritAI> ();
		print (spirit.name);
	}

	// Update is called once per frame
	void Update () {
	
	}


    void OnTriggerEnter2D(Collider2D target)
    {
   
		spirit_script.AddScannedObjects (target.gameObject);
		spirit_script.checkScannedObjects();
			//print (spirit.tag);
			//spirit.checkScannedObjects ();

        

    }

    void OnTriggerStay2D(Collider2D target){
		
    }

    void OnTriggerExit2D(Collider2D target)
	{
		if (target.gameObject.name == "Player") {
			// Loose site of player
			spirit_script.RemoveScannedObjects (target.gameObject);
			//print("no longer visible");
		}
	}
}
