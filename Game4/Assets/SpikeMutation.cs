using UnityEngine;
using System.Collections;

public class SpikeMutation : Mutation {

	DealDamage spike;

	void OnCollisionEnter(Collision other){
		//Unfortunately, child objects are not responsible for their own collisions. 
		if(spike == null){
			spike = MutationInstance.GetComponent<DealDamage>();
		}
		Stats temp = other.gameObject.GetComponent<Stats>();
		//print ("collision detected.");
		if(other.contacts[0].thisCollider.gameObject == MutationInstance){
			Stats temp2 = other.gameObject.GetComponent<Stats>();
		//	print ("collision detected.");
			if(temp2){
				
	//			print ("collision is a valid target!");
				temp2.takeDamage(spike.damage);
				temp2.rigidbody.AddExplosionForce(spike.knockback,spike.transform.position,10);
			}
		}
	//	print("Thiscollider: " + other.contacts[0].thisCollider.name + " othercollider: " + other.contacts[0].otherCollider.name);
		//if(temp){
			
		//	print ("collision is a valid target!");
		//	temp.takeDamage(damage);
		//	temp.rigidbody.AddExplosionForce(knockback,transform.position,10);
		//}
	}
	/*
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}*/
}
