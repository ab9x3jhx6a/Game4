using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIMutations : MonoBehaviour {

    Text mutations;

	// Use this for initialization
	void Start () {
        mutations = GetComponent<Text>();
        mutations.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UIupdate()
    {
        mutations.enabled = true;
    }

    public void UIreset()
    {
        mutations.enabled = false;
    }
}
