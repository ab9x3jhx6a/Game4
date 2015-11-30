using UnityEngine;
using System.Collections;

public class Chloroplast : Mutation {
	//Currently only here to be targeted by a bacteria looking for food. Should do plant things in the future.
	public float energyPerSecond = 5;
	
	// Use this for initialization
	void Start () {
		base.Start();
		print("starting");
	}
	
	// Update is called once per frame
	void Update () {
		stats.feed(energyPerSecond * Time.deltaTime);
	}
}
