using UnityEngine;
using System.Collections;

public class DefensivePoisonMutation : Mutation {
	public PoisonCloudStarve poison;
	public string type = "starvation1";
	
	
	void hit(){
		PoisonCloudStarve temp = GameObject.Instantiate(poison);
		temp.transform.position = transform.position;
		temp.type = type;
	}
	
	void Start () {
		base.Start();
		stats.immunity += type;
	}
	
/*
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}*/
}
