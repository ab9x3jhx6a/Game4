using UnityEngine;
using System.Collections;

public class DealDamage : MonoBehaviour {

	public float damage = 5;
	public float knockback = 50;



	void OnCollisionEnter(Collision other){
		Stats temp = other.gameObject.GetComponent<Stats>();
		print ("collision detected.");
		if(temp){
			
			print ("collision is a valid target!");
			temp.takeDamage(damage);
			temp.rigidbody.AddExplosionForce(knockback,transform.position,10);
		}

	}
	// Use this for initialization
/*	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}*/
}
