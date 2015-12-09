using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UISpeed : MonoBehaviour {

    Text speed;

	// Use this for initialization
	void Start () {
        speed = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UIupdate(float varSpeed)
    {
        speed.text = "Speed:" + varSpeed;
    }
    public void UIreset()
    {
        speed.text = "Speed";
    }
}
