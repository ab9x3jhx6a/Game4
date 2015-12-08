using UnityEngine;
using System.Collections;

public class Carnivore : Mutation {
	//this trait means the cell is a carnivore. It is here for targeting purposes only now. In the future it should increase the predatory stat.
	// Use this for initialization
/*	void Start () {
		base.Start();
	}*/
	void OnCollisionEnter(Collision other){
		if(!stats.enabled){
			return;
		}
		
		/*
		Stats temp = other.gameObject.GetComponent<Stats>();
		if(temp && (temp.herbivorism > 0)){
			temp.takeDamage(stats.damage);
			stats.rigidbody.AddRelativeForce(0,0,speed * -50);
		}*/
		
		FoodAnimal food = other.gameObject.GetComponent<FoodAnimal>();
		if(!food){
			return;
		}
		stats.feed(food.amount);
		Destroy(food.gameObject);
		
		/*
		if(stats.herbivorism > 0){
		
			if(other.gameObject.GetComponent<Chloroplast>()){
				//stats.feed(other.gameObject.GetComponent<Stats>().fedness);
				//Destroy(other.gameObject);
			}
		}
		if(stats.carnivoreism > 0){
			if(other.gameObject.GetComponent<Herbivore>()){
				stats.feed(other.gameObject.GetComponent<Stats>().fedness);
				Destroy(other.gameObject);
			}
		}*/
	}
	// Update is called once per frame
	void Update () {
	
	}
}
