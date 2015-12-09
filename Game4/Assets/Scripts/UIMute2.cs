using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIMute2 : MonoBehaviour {

    Text mute2;

	// Use this for initialization
	void Start () {
        mute2 = GetComponent<Text>();
        mute2.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UIupdate(string mutation)
    {
        mute2.text = mutation;
        mute2.enabled = true;
    }

    public void UIreset()
    {
        mute2.enabled = false;
    }
}
