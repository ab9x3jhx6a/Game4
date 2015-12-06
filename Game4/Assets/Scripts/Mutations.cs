using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mutations : MonoBehaviour {
	public List<string> mutations; //list of mutations by name


	List<string> differenceList (List<string> start, List<string> subtract) {
		List<string> diffList = start;
		foreach(string item in subtract) {
			diffList.Remove(item);
		}
		return diffList; //should be the first list minus the second list now
	}
}
