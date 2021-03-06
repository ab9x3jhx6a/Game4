﻿using UnityEngine;
using System.Collections;

public class CellulaseMutation : Mutation {
	
	DealDamage spike;
	
	
	void OnCollisionEnter(Collision other){
		//Unfortunately, child objects are not responsible for their own collisions. 
		
		//Stats temp = other.gameObject.GetComponent<Stats>();
		//print ("collision detected.");
		if(other.contacts[0].thisCollider.gameObject == MutationInstance){
			/*Stats temp = other.gameObject.GetComponent<Stats>();
		//	print ("collision detected.");
			if(temp){
				
				//print ("collision is a valid target!");
				temp.takeDamage(spike.damage);
				temp.rigidbody.AddExplosionForce(spike.knockback,spike.transform.position,10);
			}else{*/
			//Clump clump = other.gameObject.GetComponent<Clump>();
			Chloroplast temp = other.contacts[0].otherCollider.gameObject.GetComponent<Chloroplast>();
			
			if(temp){
				if(stats.rigidbody){
					stats.rigidbody.AddForce(0,0,spike.knockback);
				}
				temp.stats.takeDamage(spike.damage);
				//temp.gameObject.transform.parent.rigidbody.AddExplosionForce(spike.knockback,spike.transform.position,10);
			}
		}
		//}
	}
	
	void OnCollisionStay(Collision other){
		//Unfortunately, child objects are not responsible for their own collisions. 
		Chloroplast temp = other.contacts[0].otherCollider.gameObject.GetComponent<Chloroplast>();
		
		if(temp){
			if(stats.rigidbody){
				stats.rigidbody.AddForce(0,0,spike.knockback);
			}
			temp.stats.takeDamage(spike.damage);
			//temp.gameObject.transform.parent.rigidbody.AddExplosionForce(spike.knockback,spike.transform.position,10);
		}
	
		/*
		//Stats temp = other.gameObject.GetComponent<Stats>();
		//print ("collision detected.");
		if(other.contacts[0].thisCollider.gameObject == MutationInstance){
			Stats temp = other.gameObject.GetComponent<Stats>();
			//	print ("collision detected.");
			if(temp){
				
				//print ("collision is a valid target!");
				temp.takeDamage(spike.damage);
				temp.rigidbody.AddExplosionForce(spike.knockback,spike.transform.position,10);
			}else{
				//Clump clump = other.gameObject.GetComponent<Clump>();
				temp = other.contacts[0].otherCollider.gameObject.GetComponent<Stats>();
				if(temp){
					stats.rigidbody.AddForce(0,0,spike.knockback);
					temp.takeDamage(spike.damage);
					//temp.gameObject.transform.parent.rigidbody.AddExplosionForce(spike.knockback,spike.transform.position,10);
				}
			}
		}*/
	}
	
	// Use this for initialization
	void Start () {
		base.Start();
		spike = MutationInstance.GetComponent<DealDamage>();
	}
	/*
	// Update is called once per frame
	void Update () {
	
	}*/
}
