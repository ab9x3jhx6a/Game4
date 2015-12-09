using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour {

    Text health;

	// Use this for initialization
	void Start () {
        health = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void UIupdate(float currentHP, float maxHP)
    {
        health.text = "Health:" + currentHP + "/" + maxHP;
    }
    public void UIreset()
    {
        health.text = "Health";
    }
}
