using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIMetabolism : MonoBehaviour {

    Text metabolism;

	// Use this for initialization
	void Start () {
        metabolism = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UIupdate(float varMetabolism)
    {
        metabolism.text = "Metabolism:" + varMetabolism;
    }
    public void UIreset()
    {
        metabolism.text = "Metabolism";
    }
}
