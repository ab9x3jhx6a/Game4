using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

	//Here are some variables that will probably be used. 
	public float maxHealth = 10; //the amount of damage the cell can take. 
	float curHealth; 
	
	public float fedness = 50; //The amount of energy the cell possesses. 
	public float metabolism = 2; //the amount of energy the cell uses per second.
	public float maturation = 100;
	public float repoductionEfficiency = 3;//lower is better. lower than 2 means the cells net gain energy when reproducing. below one will quickly crash the game. 
	
	public float aggression = 0; //the odds of going after an enemy cell (per second perhaps?)
	public float herbivorism = 0; //the odds of going after plants.
	public float carnivoreism = 0;
	
	public float sightRadius = 10;
	public float damage = 2; //how much damage this cell will do when attacking. 
	public float speed = 1; //how fast this cell will move. 
	public float healing = .3f;//how much health this cell gains per second

	
	// Use this for initialization
	void Start () {
		curHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if(curHealth < maxHealth){
			curHealth+= healing;
		}
		
		fedness -= metabolism * Time.deltaTime;
		if(fedness < 0){
			Destroy(gameObject);
		}
		resetSize();
	}
	
	void resetSize(){
		//run this whenever 'fedness' is changed.
		float temp = Mathf.Sqrt(fedness);
		transform.localScale.Set(temp,temp,temp);
	}
	
	public void takeDamage(float damage){
		curHealth -= damage;
		if(curHealth <= 0){
			Destroy(this);
		}
	}
	
	public void feed(float amount){
		fedness += amount;
		if(fedness >= maturation){
			fedness/=repoductionEfficiency;
			GameObject temp = GameObject.Instantiate(gameObject);
		}
	}
}
