using UnityEngine;
using System.Collections;

public class Instantiate_Food : MonoBehaviour {

    public Transform plant;
    public Camera camera;
    //private Vector3 location;
    //private bool left_click, right_click;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public void Instantiate()
    {
        StartCoroutine(MyCoroutine());

        /*left_click = Input.GetMouseButtonDown(0);
        right_click = Input.GetMouseButtonDown(1);

        while (!left_click || !right_click)
        {
            left_click = Input.GetMouseButtonDown(0);
            right_click = Input.GetMouseButtonDown(1);
            yield return null;
        }
        
        if (left_click)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.y = 0;

            Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            Instantiate(plant, objectPos, Quaternion.identity);
            Debug.LogWarning("Plant instantiated");
        }*/

            //Instantiate(plant, new Vector3(-10,0,0), Quaternion.identity);
    }

    private IEnumerator MyCoroutine()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Vector3 location;
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    //Transform objectHit = hit.transform;
                    location.x = hit.point.x;
                    location.y = 0;
                    location.z = hit.point.z;
                    Instantiate(plant, location, Quaternion.LookRotation(ray.direction));
                    //Debug.LogWarning(location);
                }
                //location = transform.position;
                //location.y = 0;
                //Instantiate(plant, location, Quaternion.LookRotation(ray.direction));

                //Debug.LogWarning("Mouse clicked");
                //Debug.LogWarning(location);
                /*Vector3 mousePos = Input.mousePosition;
                mousePos.y = 0;

                Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
                objectPos.y = 0;
                Instantiate(plant, objectPos, Quaternion.identity);
                Debug.LogWarning(objectPos);*/
                //Debug.LogWarning("End Loop");
                break;
            }
            //Debug.LogWarning("Looped");
            yield return null;
        }
    }
}
