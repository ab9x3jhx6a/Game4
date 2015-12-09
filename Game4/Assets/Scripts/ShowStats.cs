using UnityEngine;
using System.Collections;

public class ShowStats : MonoBehaviour {
	Stats cell;
	Mutations mute;
	bool show;
	float posx;
	float posy;
	// Use this for initialization
	void Start () {
		cell = gameObject.GetComponent<Stats> ();
		mute = gameObject.GetComponent<Mutations> ();
		show = false;
		posx = 15;
		posy = 20;
	}

	void OnMouseEnter(){
		show = true;
		//Debug.Log ("enter");
	}

	void OnMouseExit(){
		show = false;
	}

	void OnGUI(){
		//Debug.Log ("GUI");
		if (show) {
			//health
			GUI.Label (new Rect (posx, posy, 200, 20), "Health: " + cell.curHealth.ToString() + "/" + cell.maxHealth.ToString());
			//maturation
			GUI.Label (new Rect (posx, posy + 20, 200, 20), "Maturation: " + cell.maturation.ToString());
			//metabolism
			GUI.Label (new Rect (posx, posy + 40, 200, 20), "Metabolism: " + cell.metabolism.ToString());
			//sight radius
			GUI.Label (new Rect (posx, posy + 60, 200, 20), "Sight Radius: " + cell.sightRadius.ToString());
			//speed
			GUI.Label (new Rect (posx, posy + 80, 200, 20), "Speed: " + cell.speed.ToString());
			//regeneration
			GUI.Label (new Rect (posx, posy + 100, 200, 20), "Metabolism: " + cell.healing.ToString());

			int length = mute.mutations.Count;

			GUI.Label (new Rect (posx + 200, posy, 200, 20), "Mutations:");

			for (int i=0; i< length; i++){
				GUI.Label (new Rect (posx + 200, posy + 20 + i*20, 200, 20), mute.mutations[i]);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
