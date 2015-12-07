using UnityEngine;
using System.Collections;

public class Begin : MonoBehaviour {
	public Camera main;

	private bool countdown;
	private float timer;

	Animator scene;
	// Use this for initialization
	void Start () {
		scene = main.GetComponent<Animator> ();
		timer = 0.0f;
		countdown = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (countdown) {
			timer += Time.deltaTime;
		}
		if (timer >= 3.0f) {
			Application.LoadLevel ("TestLevel");
		}
	}

	void OnMouseUp(){
		scene.SetBool ("ToMicro", true);
		countdown = true;
	}
}
