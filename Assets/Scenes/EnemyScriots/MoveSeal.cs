using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSeal : MonoBehaviour
{
	[Header("Gun")]
	public GameObject pistol;
	public GameObject Player;
	public Transform orientation;

	[Header("Seal")]
	public GameObject seal;
	public Transform seal_pos;
	public Rigidbody seal_rb;

	// Start is called before the first frame update

	// Update is called once per frame
	void Update()
	{
		if (pistol.activeSelf)
		{
			Vector3 pos = Vector3.MoveTowards(seal_pos.position, Player.transform.position, 8 * Time.deltaTime);

			seal_rb.MovePosition(pos);
			seal_pos.LookAt(orientation);
		}
	}

	void Start()
	{

	}
}
