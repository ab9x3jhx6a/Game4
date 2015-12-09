using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIMute7 : MonoBehaviour
{

    Text mute7;

    // Use this for initialization
    void Start()
    {
        mute7 = GetComponent<Text>();
        mute7.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UIupdate(string mutation)
    {
        mute7.text = mutation;
        mute7.enabled = true;
    }

    public void UIreset()
    {
        mute7.enabled = false;
    }
}