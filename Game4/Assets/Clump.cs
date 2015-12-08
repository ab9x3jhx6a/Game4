using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Clump : MonoBehaviour {
	public float speed = 1;
	public float fedness = 50;
	public float maturation = 100;
	public IList<Stats> children;
	
	public Vector2 direction;
	
	public float patience = 5;
	public float timer = 0;
	
	public float maxChildFedness = 30;
	public float minChildFedness = 10;
	Rigidbody r;
	
	public float explosionForce = 2;
	
	public int maxSize = 20;
	public Global globalObj;
	
	void Awake(){
		children = new List<Stats>();
	}
	
	void OnCollisionEnter(Collision other){
		if(other.gameObject.CompareTag("Wall")){
			print("clump hitting wall.");
			direction = Random.insideUnitCircle.normalized;
			/*Vector3 temp = AI.towards(transform.position,other.transform.position);
			direction = new Vector2(temp.x,temp.z) * -1;*/
		}
	}
	void OnCollisionStay(Collision other){
		if(other.gameObject.CompareTag("Wall")){
			direction = Random.insideUnitCircle.normalized;
		}
	}
	// Use this for initialization
	void Start () {
		globalObj = FindObjectOfType<Global>();
		globalObj.addClump(this);
		direction = Random.insideUnitCircle.normalized;
		
		r = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 temp = new Vector3(direction.x,0,direction.y) * speed;
		r.AddForce(temp);
		timer -= Time.deltaTime;
		if(fedness <= 0 && globalObj.canSpawn()){
			for(int i = 0; i < children.Count; i++){
				children[i].transform.parent = null;
				children[i].GetComponent<ClumpingMutation>().unPack();
				
				//children[i].SendMessage("makeClump");
			}
			Destroy(gameObject);
		}
	}
	
	void OnDestroy(){
		globalObj.removeClump(this);
	}
	
	void tryChangeDirection(Vector2 newDir){
		if( timer <= 0){
			timer = patience;
			direction = newDir;	
//			print ("clump is changing direction.");
		}
	}
	
	public void check(Stats childstats){
		if(childstats.curHealth < childstats.maxHealth){
			Vector2 tempdir = new Vector2(childstats.transform.position.x,childstats.transform.position.z).normalized * -1;
			tryChangeDirection(tempdir);
		}
		if(childstats.fedness < minChildFedness && fedness > 0){
			float temp = minChildFedness - childstats.fedness;
			fedness -= temp;
			childstats.feed(temp);
		}else if(childstats.fedness > maxChildFedness){
			if(fedness > maturation && maxSize >= children.Count){
				float temp = childstats.maturation;
				fedness -= temp;
				childstats.feed(temp);
			}else{
				float temp = childstats.fedness - maxChildFedness;
				fedness += temp;
				childstats.feed (temp * -1);
				Vector2 tempdir = new Vector2(childstats.transform.position.x,childstats.transform.position.z).normalized;
				tryChangeDirection(tempdir);
			}
		}
	}
	
	public void remove(Stats childStats){
		children.Remove(childStats);
		if(children.Count == 0){
			Destroy(gameObject);
		}
	}
	
	public void add(Stats childStats){
		children.Add(childStats);
	}
	
	public Vector3 placeNew(){
//		print("normal position of child: " + children[0].transform.position);
//		print ("local position of child: " + children[0].transform.localPosition);
		Vector3 temp = Random.onUnitSphere * children[Random.Range(0,children.Count)].transform.localPosition.magnitude;
//		print (temp);
		return new Vector3(temp.x + (Random.value - 2),0,temp.z + Random.value - 2);
		//return new Vector3(0,0,0);
	}
}
