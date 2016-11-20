using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour {


	private static bool GUIExists;

	void Start(){


			
			if (!GUIExists) {
				GUIExists = true; 
				DontDestroyOnLoad (transform.gameObject); 
			} else {
				Destroy (gameObject);
			}

	}


	private void Update(){
		
//
//		if (Input.GetMouseButtonDown (1)) {
//			for (int i = 0; i < slots.Length; i++) {
//
//				if (IsMouseOverSlot (i)) {
//					Debug.Log ("clicked on slot" + i);
//				}
//			}
//
//		}

	}

}


		
//	public bool IsMouseOverSlot (int slotIndex){
//		RectTransform rt = slots [slotIndex].GetComponent<RectTransform> (); 
//		if (Input.mousePosition.x > rt.position.x - rt.sizeDelta.x * 1.5f && 
//			Input.mousePosition.x < rt.position.x + rt.sizeDelta.x * 1.5f) {
//
//			if (Input.mousePosition.y > rt.position.x - rt.sizeDelta.y * 1.5f &&
//			   Input.mousePosition.y < rt.position.x + rt.sizeDelta.y * 1.5f) {
//				return true; 
//			
//			}
//		}
//
//		return false; 
//	}
