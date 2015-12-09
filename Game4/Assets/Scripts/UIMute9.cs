using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIMute9 : MonoBehaviour
{

    Text mute9;

    // Use this for initialization
    void Start()
    {
        mute9 = GetComponent<Text>();
        mute9.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UIupdate(string mutation)
    {
        mute9.text = mutation;
        mute9.enabled = true;
    }

    public void UIreset()
    {
        mute9.enabled = false;
    }
}