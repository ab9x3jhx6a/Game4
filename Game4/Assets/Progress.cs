using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Progress : MonoBehaviour {

    Global global;
    Text progressGoal;

	// Use this for initialization
	void Start () {
        progressGoal = GetComponent<Text>();
        global = GameObject.FindObjectOfType<Global>();
        global.endGoal = 2;
	}
	
	// Update is called once per frame
	void Update () {
	    progressGoal.text = global.extractedSoFar + "/" + global.endGoal;
	}
}
