using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour {
	public int clumps = 0;
	public int maxClumps = 20;
    public int extractedSoFar = 0;
    public int endGoal;
    public int resource;
	
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

    public void extracted()
    {
        extractedSoFar++;
        if (extractedSoFar == endGoal)
        {
            //************************************************
            //****************END THE GAME HERE***************
            //************************************************
            Application.LoadLevel("VictoryLevel");
        }
    }
	
}
