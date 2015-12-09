using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTime : MonoBehaviour {

    private float startTime;
    private float elapsedTime;
    private float minutes;
    private float seconds;
    Text shownTime;
    private string finalTextMinutes;
    private string finalTextSeconds;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
        shownTime = GetComponent<Text>();
        //Debug.LogWarning(shownTime.text[0] +  "" + shownTime.text[1] + shownTime.text[2]);
	}
	
	// Update is called once per frame
	void Update () {
        elapsedTime = Time.time - startTime;
        minutes = elapsedTime / 60;
        seconds = elapsedTime % 60;
        finalTextMinutes = string.Format("{0:00}", minutes);
        finalTextSeconds = string.Format("{0:00}", seconds);
        shownTime.text = finalTextMinutes + ":" + finalTextSeconds;
	}


}
