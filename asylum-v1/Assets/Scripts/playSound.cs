using UnityEngine;
using System.Collections;

public class playSound : MonoBehaviour 
{
	AudioSource music;
	// Use this for initialization
	void Start ()
	{
		music = GetComponent<AudioSource>();
		music.Play();
		DontDestroyOnLoad(this);

	}
 }
