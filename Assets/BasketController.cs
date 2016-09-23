using UnityEngine;
using System.Collections;

public class BasketController : MonoBehaviour {

	public AudioClip appleSE;
	public AudioClip bombSE;
	AudioSource aud;
	GameObject director;

	// Use this for initialization
	void Start () {
		this.aud = this.GetComponent<AudioSource>();
		this.director = GameObject.Find ("GameDirector");
	}

	void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.tag == "Apple")
		{
			this.aud.PlayOneShot(this.appleSE);
			this.director.GetComponent<GameDirector> ().GetApple ();
		}else{
			this.aud.PlayOneShot(this.bombSE);
			this.director.GetComponent<GameDirector> ().GetBomb ();
		}


		Destroy(other.gameObject);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, Mathf.Infinity))
			{
				float x = Mathf.RoundToInt(hit.point.x);
				float z = Mathf.RoundToInt(hit.point.z);
				transform.position = new Vector3(x, 0.0f, z);
			}
		}
	}


	

}
