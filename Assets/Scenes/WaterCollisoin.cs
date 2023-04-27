using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollisoin : MonoBehaviour
{
    public GameObject player;
    public GameObject deathScene;
    public GameObject cam;

    bool isdeath = false;
    // Start is called before the first frame update
    void Start()
    {
        deathScene.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isdeath)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject == player)
        {
            deathScene.SetActive(true);

			player.SetActive(false);

            isdeath = true;
		} 
        else if (collision.gameObject != player)
        {
            deathScene.SetActive(false);
        }
	}
}
