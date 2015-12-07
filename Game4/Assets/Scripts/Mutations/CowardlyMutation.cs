using UnityEngine;
using System.Collections;

public class CowardlyMutation : Mutation {
	bool running = false;
	//GameObject target;
	//public float range; 
	AI ai;
	float runningTimer = 0;
	public float speedMultiplier = 3;
	public float foodOnUse = 5;
	public float duration = 5;
	
	void hit(){
		print ("turning running on");
		running = true;
		transform.Rotate(0,Random.Range(0,360),0);
		ai.enabled = false;
		runningTimer = 0;
		//collider[] targets = Physics.OverlapSphere(transform.position,range);
		//for(int i = 0; i < )
	}
	
	// Use this for initialization
	void Start () {
		base.Start();
		ai = GetComponent<AI>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(running){
			stats.rigidbody.AddForce(0,0,stats.speed * speedMultiplier);
			runningTimer += Time.deltaTime;
			if(runningTimer > duration){
				running = false;
				ai.enabled = true;
			}
		}
	}
}
