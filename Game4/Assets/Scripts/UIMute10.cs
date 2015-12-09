using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIMute10 : MonoBehaviour
{

    Text mute10;

    // Use this for initialization
    void Start()
    {
        mute10 = GetComponent<Text>();
        mute10.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UIupdate(string mutation)
    {
        mute10.text = mutation;
        mute10.enabled = true;
    }

    public void UIreset()
    {
        mute10.enabled = false;
    }
}