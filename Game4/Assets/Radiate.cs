﻿using UnityEngine;
using System.Collections;

public class Radiate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
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
            if (Input.GetMouseButtonDown(0))
            {
                Debug.LogWarning("Mouse clicked");
                RaycastHit hit;
                Ray ray = camera.ScreenPointToRay(Input.mouseposition);
                if (Physics.Raycast(ray, out hit))
                {
                    GameObject objectHit = hit.transform.gameObject;
                    Mutations objectHitMutations = objectHit.GetComponent<Mutations>();
                    if (!objectHitMutations)
                    {
                        Debug.LogWarning("Left clicked, stopped looping");
                        break;
                    }

                    objectHitMutations.radiation = true;
                }
            }
            else if(Input.GetMouseButtonDown(1))
            {
                Debug.LogWarning("Right clicked, stopped looping");
                break;
            }

            Debug.LogWarning("Looping");
            yield return null;
        }
    }
}
