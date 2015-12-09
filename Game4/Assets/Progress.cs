using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Progress : MonoBehaviour {

    public int endGoal;
    Text progressGoal;

	// Use this for initialization
	void Start () {
        progressGoal = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
