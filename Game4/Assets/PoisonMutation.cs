using UnityEngine;
using System.Collections;

public class PoisonMutation : Mutation {
	public PoisonCloudDamage poison;
	public string type = "damage1";
	
	void preDestroy(){
		PoisonCloudDamage temp = GameObject.Instantiate(poison);
		temp.transform.position = transform.position;
		temp.type = type;
	}
	// Use this for initialization
	void Start () {
		base.Start();
		stats.immunity += type;
	}
	/*
	// Update is called once per frame
	void Update () {
	
	}*/
}
