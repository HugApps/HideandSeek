using UnityEngine;
using System.Collections;

public class Furniture : MonoBehaviour {



	private int part1;
	private int part2;
	private int part3;
	private bool searched;

	// Use this for initialization
	void Start () {
		part1 = 0;
		part2 = 0;
		part3 = 0;
	
	
	}


	public void setkey(int key){
//		print (gameObject.name + " " + key);
		switch (key) {


		case 1:
			this.part1 = 1;
			break;
		case 2:
			this.part2 = 1;
			break;
		case 3:
			this.part3 = 1;
			break;



		}

	}

	// Update is called once per frame
	void Update () {
	
	}



	public int getKey (){
		print (part1);
		print (part2);
		print (part3);
		if (part1 == 1) {
			part1 = 0;
			return 1;
		}
		if (part2 == 1) {
			part2 = 0;
			return 2;
		}
		if (part3 == 1) {
			part3 = 0;
			return 3;
		} else {
			return 0;
		}
	
	
	
	
	}


}
