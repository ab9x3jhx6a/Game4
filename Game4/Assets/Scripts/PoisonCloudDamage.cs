using UnityEngine;
using System.Collections;

public class PoisonCloudDamage : MonoBehaviour {
	public float damage;
	public float range;
	public string type;
	
	
	void OnDestroy(){
		Collider[] colliders = Physics.OverlapSphere(transform.position,range);
		for(int i = 0; i < colliders.Length; i++){
			Stats temp = colliders[i].gameObject.GetComponent<Stats>();
			if(temp && !temp.immunity.Contains(type)){
				temp.takeDamage(damage);
			}
		}
		
	}
	
	/*
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}*/
}
