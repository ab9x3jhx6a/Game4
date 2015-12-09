using UnityEngine;
using System.Collections;

public class AggressiveMutation : Mutation {
	bool berzerking = false;
	AI ai;
	public float duration = 5;
	float timer = 0;
	public float berzerkSpeed  = 2;
	public float berzerkHealing = 2;
	public float berzerkCost = 5;
	
	
	DealDamage spike;
	
	
	void OnCollisionEnter(Collision other){
		if(!berzerking && ai.enemy(other.gameObject)){
			berzerking = true;
			timer = duration;
			stats.speed *= berzerkSpeed;
			stats.healing *= berzerkHealing;
			stats.feed(berzerkCost * -1);
		}
		
		
		if(other.contacts[0].thisCollider.gameObject == MutationInstance){
			Stats temp = other.gameObject.GetComponent<Stats>();
			//	print ("collision detected.");
			if(temp && !temp.CompareTag(gameObject.tag)){
				
				//print ("collision is a valid target!");
				temp.takeDamage(spike.damage);
				temp.rigidbody.AddExplosionForce(spike.knockback,spike.transform.position,10);
			}else{
				//Clump clump = other.gameObject.GetComponent<Clump>();
				temp = other.contacts[0].otherCollider.gameObject.GetComponent<Stats>();
				if(temp){
					if(stats.rigidbody){
						stats.rigidbody.AddForce(0,0,spike.knockback);
					}
					temp.takeDamage(spike.damage);
					//temp.gameObject.transform.parent.rigidbody.AddExplosionForce(spike.knockback,spike.transform.position,10);
				}
			}
		}
		
		
	}
	
	
	
	
	void OnCollisionStay(Collision other){
		//Unfortunately, child objects are not responsible for their own collisions. 
		/*	Stats temp = other.contacts[0].otherCollider.gameObject.GetComponent<Stats>();
		if(temp){
			if(stats.rigidbody){
				stats.rigidbody.AddForce(0,0,spike.knockback);
			}
			temp.takeDamage(spike.damage);
			//temp.gameObject.transform.parent.rigidbody.AddExplosionForce(spike.knockback,spike.transform.position,10);
		}*/
		
		//Stats temp = other.gameObject.GetComponent<Stats>();
		//print ("collision detected.");
		if(other.contacts[0].thisCollider.gameObject == MutationInstance){
			Stats temp = other.gameObject.GetComponent<Stats>();
			//	print ("collision detected.");
			if(temp && !temp.CompareTag(gameObject.tag)){
				
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
		}
	}
	
	// Use this for initialization
	void Start () {
		base.Start();
		ai = GetComponent<AI>();
		spike = MutationInstance.GetComponent<DealDamage>();
	}
	// Update is called once per frame
	void Update () {
		if(berzerking){
			timer -= Time.deltaTime;
			if(timer <= 0){
				berzerking = false;
				stats.speed /= berzerkSpeed;
				stats.healing /= berzerkHealing;
			}
		}
	}
}
