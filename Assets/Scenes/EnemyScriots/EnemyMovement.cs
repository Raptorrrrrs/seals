using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [Header("Enemy")]
    public Rigidbody rb;

    [Header("Player")]
	public GameObject Player;
	public Rigidbody playerRb;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 pos = Vector3.MoveTowards(transform.position, Player.transform.position, 25 * Time.deltaTime);

		rb.MovePosition(pos);
        transform.LookAt(Player.transform);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject == Player)
		{
			print(Vector3.forward);
			playerRb.AddForce(Vector3.forward * 120);
		}
	}
}
