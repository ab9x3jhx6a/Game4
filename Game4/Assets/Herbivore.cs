using UnityEngine;
using System.Collections;

public class Herbivore : Mutation {
//This is here for targeting purposes only. In the future it should change increase the grazing stat. 
	// Use this for initialization
	/*void Start () {
		base.Start();
	}*/
	void OnCollisionEnter(Collision other){
		if(!enabled){
			return;
		}
		
		Stats temp = other.gameObject.GetComponent<Stats>();
		if(temp && ((temp.carnivoreism == 0 && temp.herbivorism == 0) || temp.carnivoreism > 0)){//(temp.herbivorism != stats.herbivorism || temp.carnivoreism != stats.carnivoreism)){
			temp.takeDamage(stats.damage);
			stats.rigidbody.AddRelativeForce(0,0,speed * -50);
		}
		
		FoodPlant food = other.gameObject.GetComponent<FoodPlant>();
		if(!food){
			return;
		}
		stats.feed(food.amount);
		Destroy(food.gameObject);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
