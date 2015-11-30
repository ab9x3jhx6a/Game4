using UnityEngine;
using System.Collections;

public class Herbivore : Mutation {
//This is here for targeting purposes only. In the future it should change increase the grazing stat. 
	public float herbivorism = .1f;
	// Use this for initialization
	void Start () {
		base.Start();
		stats.herbivorism += herbivorism;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
