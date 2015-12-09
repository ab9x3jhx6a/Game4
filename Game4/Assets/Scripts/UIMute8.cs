using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIMute8 : MonoBehaviour
{

    Text mute8;

    // Use this for initialization
    void Start()
    {
        mute8 = GetComponent<Text>();
        mute8.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UIupdate(string mutation)
    {
        mute8.text = mutation;
        mute8.enabled = true;
    }

    public void UIreset()
    {
        mute8.enabled = false;
    }
}