using UnityEngine;
using System.Collections;

public class ClumpingMutation : Mutation {
	public Clump parent;
	public Clump clump;
	// Use this for initialization
	
	void Awake(){
		
	}
	
	void Start () {
		base.Start();
		if(parent){
			//pack ();
			//stats.rigidbody.isKinematic = true;
			this.transform.parent = parent.transform;
			this.transform.localPosition = parent.placeNew();
			parent.add(this.stats);
		}
	}
	
	public void pack(){
		
		GameObject.Destroy(stats.rigidbody);
		GetComponent<AI>().enabled = false;
	}
	
	public void unPack(){
		Rigidbody temp = gameObject.AddComponent<Rigidbody>();
		//Rigidbody temp2 = temp.GetComponent<Rigidbody>();
		temp.drag = 1;
		temp.angularDrag = 1;
		temp.useGravity = false;
		temp.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
	}
	
	public void makeClump(){
		
		pack ();
		parent = (Clump)GameObject.Instantiate(clump);
		parent.transform.position = transform.position;
		transform.SetParent(parent.transform);
		parent.add(stats);
	}
	
	// Update is called once per frame
	void Update () {
		if(parent){
			parent.check(stats);
		}else if(stats.fedness > (4f/5f) * stats.maturation){
			makeClump();
		}
	}
	
	void OnDestroy(){
		if(parent){
			parent.remove(this.stats);
		}
	}
}
