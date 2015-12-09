using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Progress : MonoBehaviour {

    Global global;
    Text progressGoal;
	Global[] globals;
	// Use this for initialization
	void Start () {
        progressGoal = GetComponent<Text>();
        global = GameObject.FindObjectOfType<Global>();
        globals = GameObject.FindObjectsOfType<Global>();
        //global.endGoal = 20;
	}
	
	// Update is called once per frame
	void Update () {
		print (global.endGoal);
	    progressGoal.text = global.extractedSoFar + "/" + global.endGoal;
	}
}
