using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIMute3 : MonoBehaviour {

    Text mute3;

	// Use this for initialization
	void Start () {
        mute3 = GetComponent<Text>();
        mute3.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UIupdate(string mutation)
    {
        mute3.text = mutation;
        mute3.enabled = true;
    }

    public void UIreset()
    {
        mute3.enabled = false;
    }
}
