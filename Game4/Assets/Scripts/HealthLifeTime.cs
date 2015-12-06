using UnityEngine;
using System.Collections;

public class HealthLifeTime : MonoBehaviour {
	public float time;
	Stats stats;
	// Use this for initialization
	void Start () {
		stats = gameObject.GetComponent<Stats>();
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		if(time < 0){
			stats.enabled = true;
			stats.takeDamage(1000000);
		}
	}
}
