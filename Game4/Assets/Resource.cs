using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Resource : MonoBehaviour {

    Global global;
    Text resource_count;

	// Use this for initialization
	void Start () {
        resource_count = GetComponent<Text>();
        global = GameObject.FindObjectOfType<Global>();
        global.resource = 50;
	}
	
	// Update is called once per frame
	void Update () {
        resource_count.text = "$" + global.resource;
	}
}
