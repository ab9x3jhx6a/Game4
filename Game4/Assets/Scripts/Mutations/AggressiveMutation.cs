using UnityEngine;
using System.Collections;

public class AggressiveMutation : Mutation {
	bool berzerking = false;
	AI ai;
	public float duration = 5;
	float timer = 0;
	public float berzerkSpeed  = 2;
	public float berzerkHealing = 2;
	public float berzerkCost = 5;
	
	void OnCollisionEnter(Collision other){
		if(!berzerking && ai.enemy(other.gameObject)){
			berzerking = true;
			timer = duration;
			stats.speed *= berzerkSpeed;
			stats.healing *= berzerkHealing;
			stats.feed(berzerkCost * -1);
		}
	}
	// Use this for initialization
	void Start () {
		base.Start();
		ai = GetComponent<AI>();
	}
	
	// Update is called once per frame
	void Update () {
		if(berzerking){
			timer -= Time.deltaTime;
			if(timer <= 0){
				berzerking = false;
				stats.speed /= berzerkSpeed;
				stats.healing /= berzerkHealing;
			}
		}
	}
}
