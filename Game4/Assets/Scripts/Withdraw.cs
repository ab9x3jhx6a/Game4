using UnityEngine;
using System.Collections;

public class Withdraw : MonoBehaviour {

    public Camera camera;
    //public Stats carnivore;
    public float minimum_fedness;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Extract()
    {
        StartCoroutine(MyCoroutine());
    }

    private IEnumerator MyCoroutine()
    {
        //****************************************
        //minimum_fedness = 2000;
        //****************************************
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Debug.LogWarning("Mouse clicked");
                RaycastHit hit;
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    GameObject objectHit = hit.transform.gameObject;
                    Stats objectHitStats = objectHit.GetComponent<Stats>();
                    if (!objectHitStats)
                    {
                        break;
                    }
                    //Stats objectHitStats = hit.transform.gameObject.getComponent<Stats>();
                    //Debug.LogWarning(objectHitStats.carnivoreism);
                    //Debug.LogWarning(objectHitStats.fedness);

                    if (objectHitStats.carnivoreism > 0 && objectHitStats.fedness > minimum_fedness)
                    {
                        GameObject.Destroy(objectHitStats.gameObject);
                        //Debug.LogWarning("Left clicked, done looping");
                        break;
                    }
                    //Debug.LogWarning(objectHitStats.GetType());
                    //if (objectHit.GetType() = "")
                }
            }
            else if(Input.GetMouseButtonDown(1))
            {
                //Debug.LogWarning("Right clicked, done looping");
                break;
            }

            //Debug.LogWarning("Looping");
            yield return null;
        }
    }
}
