using UnityEngine;
using System.Collections;

public class BasketController : MonoBehaviour {

	public AudioClip appleSE;
	public AudioClip bombSE;
	AudioSource aud;

	// Use this for initialization
	void Start () {
		this.aud = this.GetComponent<AudioSource>();
	}

	void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.tag == "Apple")
		{
			this.aud.PlayOneShot(this.appleSE);
		}else{
			this.aud.PlayOneShot(this.bombSE);
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
