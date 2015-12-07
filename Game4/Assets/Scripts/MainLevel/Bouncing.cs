using UnityEngine;
using System.Collections;

public class Bouncing : MonoBehaviour {

	public float speed;
	public float offset;


	private float accer;
	private Vector3 init;

	private int dir;
	// Use this for initialization
	void Start () {
		dir = 1;
		accer = speed;
		init = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float diff = transform.position.y - init.y;
		if (diff >= 0) {
			dir = -1;
		}
		if (diff <= -0) {
			dir = 1;
		}

		speed = speed + dir * accer/offset;
		float new_y = transform.position.y + speed/offset;

		Vector3 newpos = new Vector3 (transform.position.x, new_y, transform.position.z);

		transform.position = newpos;
	}
}
