using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIMute6 : MonoBehaviour
{

    Text mute6;

    // Use this for initialization
    void Start()
    {
        mute6 = GetComponent<Text>();
        mute6.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UIupdate(string mutation)
    {
        mute6.text = mutation;
        mute6.enabled = true;
    }

    public void UIreset()
    {
        mute6.enabled = false;
    }
}