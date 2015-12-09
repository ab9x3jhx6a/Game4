using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UISight : MonoBehaviour {

    Text sight;

	// Use this for initialization
	void Start () {
        sight = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UIupdate(float varSight)
    {
        sight.text = "Sight Radius:" + varSight;
    }
    public void UIreset()
    {
        sight.text = "Sight Radius";
    }
}
