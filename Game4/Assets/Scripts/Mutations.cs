using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mutations : MonoBehaviour {
	public List<string> mutations; //list of mutations by name
	public List<Mutation> mutationComponents; //list of components of mutations
	public bool radiation = false; //whether or not this bacteria is affected by radiation

	public void Awake() {
		if (gameObject.name != "Globals") {
			foreach (Transform t in transform) {
				Destroy(t.gameObject);
			}
			int mutRoll = Random.Range (1,11); //rolls an int between 1-10, simulates 10% chance for each number
			//int mutRoll = 2; //100% mutation rate
			bool mutateBool = false; //whether or not to add a mutation
			bool removeMutateBool = false; //whether or not to take away a mutation
			if (radiation) {
				if (mutRoll >= 3 && mutRoll <= 6) {
					mutateBool = true;
				}
				else if (mutRoll <= 2) {
					removeMutateBool = true;
				}
			}
			else {
				if (mutRoll >= 2 && mutRoll <= 3) {
					mutateBool = true;
				}
				else if (mutRoll == 1) {
					removeMutateBool = true;
				}
			}
			if (mutateBool) {
				addMutation();
			}
			else if (removeMutateBool) {
				removeMutation();
			}

		} 
		else {
			Component[] mutationComps = this.gameObject.GetComponents (typeof(Mutation)); //gets the list of all mutations to name check
//			Debug.Log ("mutationComps Length: " + mutationComps.Length);
			for (int i = 0; i < mutationComps.Length; i++) {
				mutationComponents.Add(((Mutation)mutationComps[i]));
				if (((Mutation)mutationComps[i]).mutationName != "") {
					mutations.Add (((Mutation)mutationComps[i]).mutationName);
				}
				((Mutation) mutationComps[i]).enabled = false; //disables the component as it's added
			}
			radiation = false;
		}
	}

	//use this function for deciding what mutations you do or don't have
	public List<string> differenceList (List<string> start, List<string> subtract) {
		List<string> diffList = start;
		foreach(string item in subtract) {
			diffList.Remove(item);
		}
		return diffList; //should be the first list minus the second list now
	}


	Component CopyComponent(Component original, GameObject destination)
	{
		System.Type type = original.GetType();
		Component copy = destination.AddComponent(type);
		// Copied fields can be restricted with BindingFlags
		System.Reflection.FieldInfo[] fields = type.GetFields(); 
		foreach (System.Reflection.FieldInfo field in fields)
		{
			field.SetValue(copy, field.GetValue(original));
		}
		return copy;
	}

	//when it is decided that a mutaiton will occur
	public void addMutation() {
		Mutations globalref = GameObject.Find ("Globals").GetComponent<Mutations> ();
		List<string> NewMutations = differenceList (globalref.mutations, mutations); //finds which mutations this bacteria doesn't have
//		Debug.Log ("Mutation Size: " + NewMutations.Count);
		int num = Random.Range (0, NewMutations.Count); //rolls a random mutation within the range of ones you don't have
		if (NewMutations.Count > 0) {
			string newMutName = NewMutations [num];
//			Debug.Log (newMutName);
			List<Mutation> mutationGlobals = globalref.mutationComponents; //gets the list of all mutations to name check
			for (int i = 0; i < mutationGlobals.Count; i++) {
				if (mutationGlobals [i].mutationName == newMutName) { 
					mutations.Add (newMutName);
					this.CopyComponent (mutationGlobals [i], this.gameObject);
				}
			}
		}
	}

	public void removeMutation() {
		if (mutations.Count > 0) {
			int randRoll = Random.Range (0,mutations.Count);
			Mutation[] mutList = (Mutation[])(this.gameObject.GetComponents<Mutation>()); //typeof(Mutation)
			foreach (Mutation mut in mutList) {
				if (mut.mutationName == mutations[randRoll]) {
					mutations.Remove(mutations[randRoll]); //remove the mutation's name from its list of mutations
					Destroy (mut); //remove the component itself from this object so it never runs to begin with since this is called in Awake()/
					break;
				}
			}
		}
	}
}


