using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	
	public Camera camera;
	//public Stats carnivore;
	//public float minimum_fedness;
	Global global;
	int lastClick =0;
	public int cost = 5;
	public GameObject target;
	
	// Use this for initialization
	void Start () {
		global = GameObject.FindObjectOfType<Global>();
	}
	
	// Update is called once per frame
	void Update () {
		//lastClick += Time.deltaTime;
	}
	
	public void move()
	{
		StartCoroutine(MyCoroutine());
	}
	
	private IEnumerator MyCoroutinePlace()
	{
		
		while (true)
		{	
			//System.Threading.Thread.Sleep(1000);
			if (lastClick > 0 && Input.GetMouseButtonDown(0))
			{
				RaycastHit hit;
				
				
				Ray ray = camera.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out hit))
				{
					Vector3 location;
					location.x = hit.point.x;
					location.y = 0;
					location.z = hit.point.z;
//					GameObject objectHit = hit.transform.gameObject;
					target.transform.position = location;
					break;
				}
			}
			lastClick++;
			
			yield return null;
		}
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
					//Stats objectHitStats = objectHit.GetComponent<Stats>();
					//if (!objectHitStats)
					//{
					//	break;
					//}
					//Stats objectHitStats = hit.transform.gameObject.getComponent<Stats>();
					//Debug.LogWarning(objectHitStats.carnivoreism);
					//Debug.LogWarning(objectHitStats.fedness);
					target = objectHit;
					
					lastClick = 0;
					StartCoroutine(MyCoroutinePlace());
					global.resource -= cost;
					break;
					//if (objectHitStats.carnivoreism > 0 && objectHitStats.fedness > minimum_fedness)
					//{
					//	GameObject.Destroy(objectHitStats.gameObject);
					//	global.extracted();
						//Debug.LogWarning("Left clicked, done looping");
					//	break;
					//}
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