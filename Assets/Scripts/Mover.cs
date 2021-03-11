using UnityEngine;

public class Mover : MonoBehaviour
{
	public float speed;
	private Vector3 movement;
	private Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();

		movement = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));

		if(rb.gameObject.tag == "Bolt")
        {
			rb.velocity = transform.forward * speed;
		}
        else
        {
			rb.velocity = movement * speed;
		}
	}
}
