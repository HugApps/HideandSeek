using UnityEngine;
using System.Collections;

public class RoomEvents : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	
	}

	void Haunt (){
		foreach (Transform child in transform)
		{
			//child is your child transform
			Destroy(child.gameObject);
			Furniture ff = child.gameObject.GetComponent<Furniture> ();
			//ff.triggerEvent ();
		}

	}
}
