using UnityEngine;
using System.Collections;

public class PoisonCloudStarve : MonoBehaviour {
	public float starvation;
	public float range;
	public string type;
	
	
	void OnDestroy(){
		Collider[] colliders = Physics.OverlapSphere(transform.position,range);
		for(int i = 0; i < colliders.Length; i++){
			Stats temp = colliders[i].gameObject.GetComponent<Stats>();
			if(temp && !temp.immunity.Contains(type)){
				temp.feed(starvation * -1);
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
