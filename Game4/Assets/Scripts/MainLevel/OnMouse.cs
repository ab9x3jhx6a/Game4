using UnityEngine;
using System.Collections;

public class OnMouse : MonoBehaviour {


	public Material hover;
	public Material normal;

	private Vector3 init;
	// Use this for initialization
	void Start () {
		init = transform.position;
	}

	void OnMouseEnter(){
		Renderer tmp = gameObject.GetComponent<Renderer>();
		tmp.material = hover;
		Vector3 newpos = new Vector3 (transform.position.x, transform.position.y, transform.position.z - 0.04f);
		transform.position = newpos;
	}

	void OnMouseExit(){
		Renderer tmp = gameObject.GetComponent<Renderer>();
		tmp.material = normal;
		Vector3 newpos = new Vector3 (transform.position.x, transform.position.y, transform.position.z + 0.04f);
		transform.position = newpos;
	}

	void OnMouseDown(){
		Vector3 newpos = new Vector3 (transform.position.x, transform.position.y, transform.position.z + 0.08f);
		transform.position = newpos;
	}

	void OnMouseUp() {
		Vector3 newpos = new Vector3 (transform.position.x, transform.position.y, transform.position.z - 0.08f);
		transform.position = newpos;
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
