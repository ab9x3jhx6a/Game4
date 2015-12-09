using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIMute4 : MonoBehaviour {

    Text mute4;

	// Use this for initialization
	void Start () {
        mute4 = GetComponent<Text>();
        mute4.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UIupdate(string mutation)
    {
        mute4.text = mutation;
        mute4.enabled = true;
    }

    public void UIreset()
    {
        mute4.enabled = false;
    }
}
