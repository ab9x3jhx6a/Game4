using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIMaturation : MonoBehaviour {

    Text maturation;

	// Use this for initialization
	void Start () {
        maturation = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UIupdate(float varMaturation)
    {
        maturation.text = "Maturation:" + varMaturation;
    }
    public void UIreset()
    {
        maturation.text = "Maturation";
    }
}
