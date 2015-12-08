using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

	//Here are some variables that will probably be used. 
	public float maxHealth = 10; //the amount of damage the cell can take. 
	public float curHealth; 
	
	public float fedness = 50; //The amount of energy the cell possesses. 
	public float metabolism = 2; //the amount of energy the cell uses per second.
	public float maturation = 100;
	public float reproductionEfficiency = 3;//lower is better. lower than 2 means the cells net gain energy when reproducing. below one will quickly crash the game. 
	
	public float aggression = 0; //the odds of going after an enemy cell (per second perhaps?)
	public float herbivorism = 0; //the odds of going after plants.
	public float carnivoreism = 0;
	
	public float sightRadius = 10;
	public float damage = 2; //how much damage this cell will do when attacking. 
	public float speed = 1; //how fast this cell will move. 
	public float healing = .3f;//how much health this cell gains per second

	public Rigidbody rigidbody;

	public GameObject drops;
	public ParticleSystem blood;
	public float decayTime = 30;
	//public HealthLifeTime timer;
	public string immunity = "";

//	public Mutation[] mutations;
	public int initializedMutations = 0;
	public int totalMutations = 0;
	
	
	
	void Awake(){
		maxHealth = 0; //the amount of damage the cell can take. 
		//curHealth; 
		
		//fedness = 0; //The amount of energy the cell possesses. 
		metabolism = 0; 
		maturation = 0;
		reproductionEfficiency = 0;
		
		aggression = 0; 
		herbivorism = 0; 
		carnivoreism = 0;
		
		sightRadius = 0;
		damage = 0; 
		speed = 0; 
		healing = 0;
		
		initializedMutations = 0;
		totalMutations = 0;
	}
	
	
	// Use this for initialization
	void Start () {
		//curHealth = maxHealth;
		/*if(fedness == 0){
			fedness = maturation/3;		
		}*/
		rigidbody = GetComponent<Rigidbody>();
		totalMutations = GetComponents<Mutation>().Length;
		if(initializedMutations == totalMutations){
			curHealth = maxHealth;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(curHealth < maxHealth){
			curHealth+= healing*Time.deltaTime;
		}
		
		fedness -= metabolism * Time.deltaTime;
		if(fedness < 0){
			AI temp = GetComponent<AI>();
			temp.enabled = false;
			fedness = maturation/5;
			enabled = false;
			HealthLifeTime timer = gameObject.AddComponent<HealthLifeTime>();
			timer.time = decayTime;
			resetSize();
			//Destroy(gameObject);
		}
		if(Random.value > .8f){
			resetSize();
		}
	}
	
	
	public void notifyInitialized(Mutation mutation){
		//mutations[initializedMutations++] = mutation;
		initializedMutations++;
		if(initializedMutations==totalMutations){
			curHealth = maxHealth;
		}
	}
	
	public void OnDestroy(){
		
	}
	
	void resetSize(){
		//run this whenever 'fedness' is changed.
		//if(Random.value > .8f){
			float temp = Mathf.Sqrt(fedness)/5 + .2f;
			transform.localScale = new Vector3(temp,temp,temp);
	//	}
	}
	
	public void takeDamage(float damage){
		curHealth -= damage;
		SendMessage("hit",null,SendMessageOptions.DontRequireReceiver);
		if(curHealth <= 0){
			while(fedness > 0){
				fedness -= 10;
				GameObject temp = GameObject.Instantiate(drops);
				temp.transform.position = transform.position;
				Vector2 position = Random.insideUnitCircle;
				temp.transform.Translate(position.x,0,position.y);
			}
			ParticleSystem temp2 = GameObject.Instantiate(blood);
			temp2.transform.position = transform.position;
			SendMessage("preDestroy",null,SendMessageOptions.DontRequireReceiver);
			Destroy(this.gameObject);
		}
	}
	
	public void feed(float amount){
		fedness += amount;
		if(fedness >= maturation){
			fedness/=reproductionEfficiency;
			GameObject temp = GameObject.Instantiate(gameObject);
			Vector2 position = Random.insideUnitCircle * transform.localScale.x * 2;
			temp.transform.Translate(position.x,0,position.y);
		}
	}
}
