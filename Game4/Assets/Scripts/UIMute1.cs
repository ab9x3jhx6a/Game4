using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIMute1 : MonoBehaviour {

    Text mute1;

	// Use this for initialization
	void Start () {
        mute1 = GetComponent<Text>();
        mute1.enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UIupdate(string mutation)
    {
            mute1.text = mutation;
            mute1.enabled = true;
    }

    public void UIreset()
    {
        mute1.enabled = false;
    }
}
