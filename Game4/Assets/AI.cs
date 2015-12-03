using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AI : MonoBehaviour {
	//public float sightRadius;
	public float wanderDistance = 50;
	public Stats stats;
	Rigidbody r;

	protected delegate void Action();
	Action action;
	GameObject target;
	public Vector3 destination;
	// Use this for initialization
	void Start () {
		transform.position = new Vector3(transform.position.x,0,transform.position.z);
		stats = gameObject.GetComponent<Stats>();
		r = GetComponent<Rigidbody>();
		resetAction();
	}
	
	// Update is called once per frame
	void Update () {
		action();
	}
	
	void OnCollisionEnter(Collision other){
		if(!enabled){
			return;
		}
		if(other.gameObject.CompareTag("Wall")){
			resetAction();
			return;
		}
		if(target == other.gameObject){
			target = null;
			resetAction();
		}
		
		Stats temp = other.gameObject.GetComponent<Stats>();
		if(temp && (temp.herbivorism != stats.herbivorism || temp.carnivoreism != stats.carnivoreism)){
			temp.takeDamage(stats.damage);
		}
		
		if(stats.herbivorism > 0){
			FoodPlant food = other.gameObject.GetComponent<FoodPlant>();
			if(!food){
				return;
			}
			stats.feed(food.amount);
			Destroy(food.gameObject);
		}else if(stats.carnivoreism > 0){
			FoodAnimal food = other.gameObject.GetComponent<FoodAnimal>();
			if(!food){
				return;
			}
			stats.feed(food.amount);
			Destroy(food.gameObject);
		}
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
	void OnCollisionStay(Collision other){
		if(other.gameObject.CompareTag("Wall")){
			resetAction();
			return;
		}
	}
	
	void idle(){
		
	}
	
	void resetAction(){
		destination = new Vector3(transform.position.x + wanderDistance - wanderDistance * 2 * Random.value,0,
		                          transform.position.z + wanderDistance - wanderDistance * 2 * Random.value);
		action = wander;
	}
	
	void wander(){
		r.AddRelativeForce(0,0,stats.speed);
		r.rotation = Quaternion.LookRotation(towards(transform.position,destination));
		//print("before: " + r.rotation.eulerAngles);
		//r.rotation.eulerAngles.Set(0,r.rotation.eulerAngles.y + 5 - Random.value * 10,0);
		//print ("after " + r.rotation.eulerAngles);
		//print (r.rotation.eulerAngles.y + (50 - Random.value * 100));
		//r.rotation = Quaternion.FromToRotation(r.rotation.eulerAngles,new Vector3(0,r.rotation.eulerAngles.y + (50 - Random.value * 100),0));//Quaternion.LookRotation(randomFlatRotation());
		if(stats.herbivorism > Random.value){
			action = findFood<FoodPlant,Chloroplast>;
		}
		if(stats.carnivoreism > Random.value){
			action = findFood<FoodAnimal,FoodAnimal>;
		}
		if(stats.aggression > Random.value){
			if(stats.herbivorism > 0){
				action = findEnemy<Carnivore>;
			}else{
				action = findEnemy<Herbivore>;
			}
		}
		if(Vector3.Distance(transform.position,destination) < wanderDistance/50){
			resetAction();
		}
	}
	
	void findFood<Food,Prey>()where Food:MonoBehaviour where Prey:MonoBehaviour{
		wander ();
		target = scan<Food>();
		
		if(target != null){
			action = persue;//TO PERSUE
		}else{
			target = scan<Prey>();
			if(target != null){
				action = persue;
			}
		}
	}
	
	void findEnemy<Enemy>()where Enemy:MonoBehaviour{
 		wander ();
		target = scan<Enemy>();
		
		if(target != null){
			action = persue;//TO PERSUE
		}
	}
	/*
	void findPrey(){
		wander();
		target = scan<Herbivore>();
		
		if(target != null){
			action = persue;//TO PERSUE
		}
	}*/
	
	void persue(){
		if(target == null || Vector3.Distance(transform.position,target.transform.position) > stats.sightRadius){
			resetAction();//TO WANDER
		}
		r.AddRelativeForce(0,0,stats.speed);
		r.rotation = Quaternion.LookRotation(towards(transform.position,target.transform.position));
	}
	
	GameObject scan<T>() where T:MonoBehaviour{
		Collider[] temp = Physics.OverlapSphere(transform.position,stats.sightRadius);
		List<T> valids = new List<T>();
		for(int i = 0; i < temp.Length; i++){
			T component = temp[i].GetComponent<T>();
			if(component){
				valids.Add(component);
			}
		}
		if(valids.Count < 1){
			return null;
		}else{
			int index = Random.Range(0,valids.Count);
			return valids[index].gameObject;
		}
	}
	
	
	
	
	static Vector3 towards(Vector3 origin, Vector3 destination){
		Vector3 temp = destination - origin;
		temp.Normalize();
		//print (temp);
		return temp;
	}/*
	static Vector3 randomFlatRotation(){
	//not currently used...
		Vector2 temp = Random.insideUnitCircle;
		return new Vector3(temp.x,0,temp.y);
	}*/
}
