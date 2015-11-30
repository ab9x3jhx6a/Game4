using UnityEngine;
using System.Collections;

public class Carnivore : Mutation {
	//this trait means the cell is a carnivore. It is here for targeting purposes only now. In the future it should increase the predatory stat.
	public float carnivorism = .1f;
	// Use this for initialization
	void Start () {
		base.Start();
		stats.carnivoreism += carnivorism;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
