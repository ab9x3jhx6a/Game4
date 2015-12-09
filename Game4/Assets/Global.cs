using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {
	public int clumps = 0;
	public int maxClumps = 20;
	
	public void addClump(Clump clump){
		clumps++;
	}
	public void removeClump(Clump clump){
		clumps--;
	}
	public bool canSpawn(){
		if(clumps < maxClumps){
			return true;
		}
		return false;
	}
	
}
