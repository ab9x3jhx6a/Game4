using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIRegen : MonoBehaviour {

    Text regen;

	// Use this for initialization
	void Start () {
        regen = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UIupdate(float varRegen)
    {
        regen.text = "Regen:" + varRegen;
    }
    public void UIreset()
    {
        regen.text = "Regen";
    }
}
