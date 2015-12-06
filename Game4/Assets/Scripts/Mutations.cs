using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mutations : MonoBehaviour {
	public List<string> mutations; //list of mutations by name
	public List<Mutation> mutationComponents; //list of components of mutations

	public void Start() {
		if (gameObject.name != "Globals") {
			addMutation ();
		} 
		else {
			Component[] mutationComps = this.gameObject.GetComponents (typeof(Mutation)); //gets the list of all mutations to name check
			Debug.Log ("mutationComps Length: " + mutationComps.Length);
			for (int i = 0; i < mutationComps.Length; i++) {
				mutationComponents.Add(((Mutation)mutationComps[i]));
				if (((Mutation)mutationComps[i]).mutationName != "") {
					mutations.Add (((Mutation)mutationComps[i]).mutationName);
				}
				((Mutation) mutationComps[i]).enabled = false; //disables the component as it's added
			}
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
		Debug.Log ("Mutation Size: " + NewMutations.Count);
		int num = Random.Range (0, NewMutations.Count); //rolls a random mutation within the range of ones you don't have
		string newMutName = NewMutations [num];
		Debug.Log (newMutName);
		List<Mutation> mutationGlobals = globalref.mutationComponents; //gets the list of all mutations to name check
		for (int i = 0; i < mutationGlobals.Count; i++) {
			if (mutationGlobals[i].mutationName == newMutName) {
				this.CopyComponent(mutationGlobals[i],this.gameObject);
			}
		}
	}
}


