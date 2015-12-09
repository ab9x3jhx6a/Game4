using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inspector : MonoBehaviour {

    public Camera camera;
    Text textUI;
    private int mutex, mutey;
    private bool inCoroutine = false;
    UIHealth health;
    UIRegen regen;
    UISpeed speed;
    UIMaturation maturation;
    UIMetabolism metabolism;
    UISight sight;
    UIMutations mutations;
    //UIMute mute1, mute2, mute3, mute4, mute5, mute6, mute7, mute8, mute9, mute10;
    UIMute1 mute1; UIMute2 mute2; UIMute3 mute3; UIMute4 mute4; UIMute5 mute5; UIMute6 mute6; UIMute7 mute7; UIMute8 mute8; UIMute9 mute9; UIMute10 mute10;

	// Use this for initialization
	void Start () {
        textUI = GetComponent<Text>();
        mutex = 215;
        mutey = 40;
        health = GameObject.FindObjectOfType<UIHealth>();
        regen = GameObject.FindObjectOfType<UIRegen>();
        speed = GameObject.FindObjectOfType<UISpeed>();
        maturation = GameObject.FindObjectOfType<UIMaturation>();
        metabolism = GameObject.FindObjectOfType<UIMetabolism>();
        sight = GameObject.FindObjectOfType<UISight>();
        mutations = GameObject.FindObjectOfType<UIMutations>();
        mute1 = GameObject.FindObjectOfType<UIMute1>(); mute2 = GameObject.FindObjectOfType<UIMute2>(); mute3 = GameObject.FindObjectOfType<UIMute3>(); mute4 = GameObject.FindObjectOfType<UIMute4>();
        mute5 = GameObject.FindObjectOfType<UIMute5>(); mute6 = GameObject.FindObjectOfType<UIMute6>(); mute7 = GameObject.FindObjectOfType<UIMute7>(); mute8 = GameObject.FindObjectOfType<UIMute8>();
        mute9 = GameObject.FindObjectOfType<UIMute9>(); mute10 = GameObject.FindObjectOfType<UIMute10>();
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.LogWarning("called inspector update");
	    if (Input.GetMouseButtonDown(0) && inCoroutine == false)
        {
            //Debug.LogWarning("started coroutine in inspector");
            inCoroutine = true;
            StartCoroutine(MyCoroutine());
            StartCoroutine(MyCoroutine2());
            inCoroutine = false;
            /*RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                GameObject objectHit = hit.transform.gameObject;
                StartCoroutine(MyCouroutine(objectHit));
                //Stats objectHitStats = objectHit.GetComponent<Stats>();
                //Mutations objectHitMutations = objectHit.GetComponent<Mutations>();
            }*/
            //coroutine = true;
            //StartCoroutine(MyCoroutine());
        }
	}

    private IEnumerator MyCoroutine()
    {
        while (true)
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                GameObject objectHit = hit.collider.gameObject;//transform.gameObject;
                Stats objectHitStats = objectHit.GetComponent<Stats>();
                Mutations objectHitMutations = objectHit.GetComponent<Mutations>();
                if (!objectHitStats)
                {
                    break;
                }
                health.UIupdate(objectHitStats.curHealth, objectHitStats.maxHealth);
                regen.UIupdate(objectHitStats.healing);
                speed.UIupdate(objectHitStats.speed);
                maturation.UIupdate(objectHitStats.maturation);
                metabolism.UIupdate(objectHitStats.metabolism);
                sight.UIupdate(objectHitStats.sightRadius);
                mutations.UIupdate();
                if (objectHitMutations.mutations.Count >= 1) { mute1.UIupdate(objectHitMutations.mutations[0]); } if (objectHitMutations.mutations.Count >= 2) { mute2.UIupdate(objectHitMutations.mutations[1]); }
                if (objectHitMutations.mutations.Count >= 3) { mute3.UIupdate(objectHitMutations.mutations[2]); } if (objectHitMutations.mutations.Count >= 4) { mute4.UIupdate(objectHitMutations.mutations[3]); }
                if (objectHitMutations.mutations.Count >= 5) { mute5.UIupdate(objectHitMutations.mutations[4]); } if (objectHitMutations.mutations.Count >= 6) { mute6.UIupdate(objectHitMutations.mutations[5]); }
                if (objectHitMutations.mutations.Count >= 7) { mute7.UIupdate(objectHitMutations.mutations[6]); } if (objectHitMutations.mutations.Count >= 8) { mute8.UIupdate(objectHitMutations.mutations[7]); }
                if (objectHitMutations.mutations.Count >= 9) { mute9.UIupdate(objectHitMutations.mutations[8]); } if (objectHitMutations.mutations.Count >= 10) { mute10.UIupdate(objectHitMutations.mutations[9]); }
                //mute1.UIupdate(); mute2.UIupdate(); mute3.UIupdate(); mute4.UIupdate(); mute5.UIupdate(); mute6.UIupdate(); mute7.UIupdate(); mute8.UIupdate(); mute9.UIupdate(); mute10.UIupdate();
            }
            yield return null;
        }
    }

    private IEnumerator MyCoroutine2()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                health.UIreset();
                regen.UIreset();
                speed.UIreset();
                maturation.UIreset();
                metabolism.UIreset();
                sight.UIreset();
                mutations.UIreset();
                mute1.UIreset(); mute2.UIreset(); mute3.UIreset(); mute4.UIreset(); mute5.UIreset(); mute6.UIreset(); mute7.UIreset(); mute8.UIreset(); mute9.UIreset(); mute10.UIreset();
                break;
            }
            yield return null;
        }
    }

    /*void OnMouseEnter()
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
    }*/
}
