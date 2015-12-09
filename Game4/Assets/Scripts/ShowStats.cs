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
		posx = 50;
		posy = 15;
        GUI.color = Color.black;
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
            GUI.color = Color.black;
			//health
			GUI.Label (new Rect (posx, posy, 200, 20), "Health: " + cell.curHealth.ToString() + "/" + cell.maxHealth.ToString());
			//regen
            GUI.Label(new Rect(posx, posy + 37, 200, 20), "Regen: " + cell.healing.ToString());
			//speed
            GUI.Label(new Rect(posx, posy + 75, 200, 20), "Speed: " + cell.speed.ToString());
			//maturation
            GUI.Label(new Rect(posx + 175, posy, 200, 20), "Maturation: " + cell.maturation.ToString());
			//metabolism
            GUI.Label(new Rect(posx + 175, posy + 37, 200, 20), "Metabolism: " + cell.metabolism.ToString());
			//sight radius
            GUI.Label(new Rect(posx + 175, posy + 75, 200, 20), "Sight Radius: " + cell.sightRadius.ToString());

			int length = mute.mutations.Count;

			GUI.Label (new Rect (posx - 37, posy + 112, 200, 20), "Mutations:");

			for (int i=0; i< length; i++){
				GUI.Label (new Rect (posx - 37, posy + 112 + 20 + i*20, 200, 20), mute.mutations[i]);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
