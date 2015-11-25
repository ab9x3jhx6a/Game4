using UnityEngine;
using System.Collections;

public class Mutation : MonoBehaviour {
	public GameObject damageMutationObject; //Preset visual object for this mutation
	GameObject damageMutationInstance = null; //instance of the mutation (will be parented to the bacteria)
	public bool damageMutation = false; //whether or not the mutation should be on
	public float damageChange = 0; //effect the mutation has on the object

	public GameObject regrowthMutationObject;
	GameObject regrowthMutationInstance = null;
	public bool regrowthMutation = false;
	public float regrowthChange = 0;

	public GameObject healthMutationObject;
	GameObject healthMutationInstance = null;
	public bool healthMutation = false;
	public float healthChange = 0;

	void Start () {
		visualUpdate ();
	}
	//call this function whenever a mutation is added or taken away from this Bacteria
	public void visualUpdate(){
		//runs through each possible mutation, adding the proper ones
		if (damageMutationInstance == null)
		{
			if (damageMutation)
			{
				damageMutationInstance = (GameObject)GameObject.Instantiate(damageMutationObject,this.transform.position + new Vector3(0.4f,0.4f,0.4f),Quaternion.identity);
				damageChange = Random.Range (-2,3);
				damageMutationInstance.transform.parent = this.transform;
				this.GetComponent<Stats>().damage += damageChange;
			}
		}
		else if (!damageMutation) //remove this mutation
		{
			this.GetComponent<Stats>().damage -= damageChange;
			damageChange = 0;
			Destroy(damageMutationInstance);	
			damageMutationInstance = null;
		}

		if (regrowthMutationInstance == null)
		{
			if (regrowthMutation)
			{
				regrowthMutationInstance = (GameObject)GameObject.Instantiate(regrowthMutationObject,this.transform.position + new Vector3(-0.4f,0.4f,0.4f),Quaternion.identity);
				regrowthChange = Random.Range (-0.2f,0.2f);
				regrowthMutationInstance.transform.parent = this.transform;
				this.GetComponent<Stats>().healing += regrowthChange;
			}

		}
		else if (!regrowthMutation) //remove this mutation
		{
			this.GetComponent<Stats>().healing -= damageChange;
			regrowthChange = 0;
			Destroy(regrowthMutationInstance);	
			regrowthMutationInstance = null;			
		}

		if (healthMutationInstance == null)
		{
			if (healthMutation)
			{
			healthMutationInstance = (GameObject)GameObject.Instantiate(healthMutationObject,this.transform.position + new Vector3(0.4f,0.4f,-0.4f),Quaternion.identity);
			healthChange = Random.Range (-2,3);
			healthMutationInstance.transform.parent = this.transform;
			this.GetComponent<Stats>().maxHealth += healthChange;
			}
		}
		else if (!healthMutation) //remove this mutation
		{
			this.GetComponent<Stats>().maxHealth -= healthChange;
			healthChange = 0;
			Destroy(healthMutationInstance);	
			healthMutationInstance = null;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
