using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIMute5 : MonoBehaviour
{

    Text mute5;

    // Use this for initialization
    void Start()
    {
        mute5 = GetComponent<Text>();
        mute5.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UIupdate(string mutation)
    {
        mute5.text = mutation;
        mute5.enabled = true;
    }

    public void UIreset()
    {
        mute5.enabled = false;
    }
}