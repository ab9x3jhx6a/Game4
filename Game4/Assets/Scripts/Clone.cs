using UnityEngine;
using System.Collections;

public class Clone : MonoBehaviour {

    public Camera camera;
    Global global;
    public int cloneCost;

	// Use this for initialization
	void Start () {
        global = GameObject.FindObjectOfType<Global>();
        cloneCost = 10;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void clone()
    {
        StartCoroutine(MyCoroutine());
    }

    private IEnumerator MyCoroutine()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0) && global.resource >= cloneCost)
            {
                RaycastHit hit;
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    GameObject objectHit = hit.collider.gameObject;
                    Stats objectHitStats = objectHit.GetComponent<Stats>();
                    if (!objectHitStats)
                    {
                        break;
                    }
                    objectHitStats.feed(objectHitStats.maturation);
                    global.resource -= cloneCost;
                    break;
                }
            }

            //Debug.LogWarning("Looping");
            yield return null;
        }
    }
}
