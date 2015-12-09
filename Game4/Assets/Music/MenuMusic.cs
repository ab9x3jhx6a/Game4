using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class MenuMusic : MonoBehaviour {
	AudioSource sound;
	public AudioClip backMusic;
	// Use this for initialization
	void Start () {
		sound.Play ();
		sound.loop = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
