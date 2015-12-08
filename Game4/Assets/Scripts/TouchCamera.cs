using UnityEngine;
using System.Collections;

public class TouchCamera : MonoBehaviour {

	public float distance = 60.0f;
	public float sensitivityDistance = 50;
	public float damping = 5.0f;
	public float minFOV = 40.0f;
	public float maxFOV = 60.0f;

	private Vector3 dragOrigin;
	private float dragSpeed = 2;
	Camera main;


	// Use this for initialization
	void Start () {
		main = gameObject.GetComponent<Camera> ();
		distance = main.fieldOfView;
	}
	
	// Update is called once per frame
	void Update () {
		distance -= Input.GetAxis ("Mouse ScrollWheel") * sensitivityDistance;
		distance = Mathf.Clamp (distance, minFOV, maxFOV);
		main.fieldOfView = Mathf.Lerp (main.fieldOfView, distance, Time.deltaTime * damping);

		if (Input.GetMouseButtonDown(0))
		{
			dragOrigin = Input.mousePosition;
			return;
		}
		
		if (!Input.GetMouseButton(0)) return;
		
		Vector3 pos = main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
		Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);
		
		transform.Translate(move, Space.World);  
	}


}
