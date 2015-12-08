using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mutation : MonoBehaviour {
	public string mutationName = ""; //name of this mutation (can be set publically or within inherited component)
	public GameObject MutationObject = null; //Preset visual object for this mutation
	public GameObject MutationInstance = null; //instance of the mutation (will be parented to the bacteria)
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
		if (mutationName != "" && this.gameObject.GetComponent<Mutations>() != null) { //If you levae a mutationName empty it will not account for it, so use this if you want non-tranferable mutations
			this.gameObject.GetComponent<Mutations>().mutations.Add(mutationName); //adds mutation to this bacteria's current list of mutations
			List<string> wedge;
		}
		stats = this.gameObject.GetComponent<Stats> ();
		MutationInstance = null;
		if (MutationObject != null) {
			MutationInstance =(GameObject)Instantiate (MutationObject);
			Vector3 ang = transform.eulerAngles; //holds current rotation for simple no-math solution
			Vector3 scale = transform.localScale;
			transform.localScale = Vector3.one;
			transform.eulerAngles = Vector3.zero;
			MutationInstance.transform.position = new Vector3(transform.position.x + MutationInstance.transform.position.x,transform.position.y + MutationInstance.transform.position.y,transform.position.z + MutationInstance.transform.position.z);
			MutationInstance.transform.SetParent(this.gameObject.transform); //attaches the new mutation to its owner
			transform.eulerAngles = ang;
			transform.localScale = scale;
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
	//If you decomment this update function, please tell me as it will not be called on certain mutations unless
	// you make it protected and call it from subclasses that don't comment it out.
/*	void Update () {
	
	}
*/
}
