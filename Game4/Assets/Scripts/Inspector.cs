using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inspector : MonoBehaviour {

    public Camera camera;
    Text textUI;
    private int mutex, mutey;

	// Use this for initialization
	void Start () {
        textUI = GetComponent<Text>();
        mutex = 215;
        mutey = 40;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnMouseEnter()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.LogWarning("Entered input");
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                GameObject objectHit = hit.collider.gameObject;
                Stats objectHitStats = objectHit.GetComponent<Stats>();
                Mutations objectHitMutations = objectHit.GetComponent<Mutations>();
                if (!objectHitStats || !objectHitMutations)
                {
                    return;
                }
                else if(!objectHitStats)
                {
                    int length = objectHitMutations.mutations.Count;
                    for (int i=0; i<length; i++)
                    {
                        GUI.Label(new Rect(mutex, mutey + i * 20, 200, 20), objectHitMutations.mutations[i]);
                    }
                }
                else
                {
                    if (textUI.text[0] == 'H')
                    {
                        Debug.LogWarning("Health");
                        textUI.text = "Health:" + objectHitStats.curHealth + "/" + objectHitStats.maxHealth;
                    }
                }
            }
        }
    }
}
