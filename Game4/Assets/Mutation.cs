using UnityEngine;
using System.Collections;

public class Mutation : MonoBehaviour {
	public GameObject MutationObject = null; //Preset visual object for this mutation
	GameObject MutationInstance = null; //instance of the mutation (will be parented to the bacteria)
	public float maxHealth = 0; //the amount of damage the cell can take. 

	public float metabolism = 0; //the amount of energy the cell uses per second.
	public float maturation = 0;
	public float reproductionEfficiency = 0;//lower is better. lower than 2 means the cells net gain energy when reproducing. below one will quickly crash the game. 
	
	public float aggression = 0; //the odds of going after an enemy cell (per second perhaps?)
	public float herbivorism = 0; //the odds of going after plants.
	public float carnivoreism = 0;
	
	public float sightRadius = 0;
	public float damage = 0; //how much damage this cell will do when attacking. 
	public float speed = 0; //how fast this cell will move. 
	public float healing = 0;//how much health this cell gains per second
	public Stats stats;

	protected void Start () {
		stats = this.GetComponent<Stats> ();
		MutationInstance = null;
		if (MutationObject != null) {
			MutationInstance = (GameObject)Instantiate (MutationObject);
		}
		//all set changes for mutations from public input are made onto the cell's stats
		stats.maxHealth += maxHealth;
		stats.metabolism += metabolism;
		stats.maturation += maturation;
		stats.reproductionEfficiency += reproductionEfficiency;
		stats.aggression += aggression;
		stats.herbivorism += herbivorism;
		stats.carnivoreism += carnivoreism;
		stats.sightRadius += sightRadius;
		stats.damage += damage;
		stats.speed += speed;
		stats.healing += healing;
		
		stats.notifyInitialized(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
