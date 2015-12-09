using UnityEngine;
using System.Collections;

public class Radiate : MonoBehaviour {

    public Camera camera;
    Global global;
	// Use this for initialization
	void Start () {
        global = GameObject.FindObjectOfType<Global>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Radiation()
    {
        StartCoroutine(MyCoroutine());
    }

    private IEnumerator MyCoroutine()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0) && global.resource >= 5)
            {
                //Debug.LogWarning("Mouse clicked");
                RaycastHit hit;
                //Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    GameObject objectHit = hit.transform.gameObject;
                    Mutations objectHitMutations = objectHit.GetComponent<Mutations>();
                    if (!objectHitMutations)
                    {
                        //Debug.LogWarning("Left clicked, stopped looping");
                        break;
                    }

                    objectHitMutations.radiation = true;
                    global.resource -= 5;
                    break;
                }
            }
            else if(Input.GetMouseButtonDown(1))
            {
                //Debug.LogWarning("Right clicked, stopped looping");
                break;
            }

            //Debug.LogWarning("Looping");
            yield return null;
        }
    }
}
