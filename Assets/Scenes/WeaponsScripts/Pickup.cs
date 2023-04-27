using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pickup : MonoBehaviour
{
    [Header("Pick up")]
    public float range = 0.1f;
    public GameObject cam;
    public TextMeshProUGUI textMeshPro;

    public RaycastHit hit;

    [Header("Box")]
    public Animator animator;

    [Header("player")]
    public Animator playerAnimator;
    public TextMeshPro task;

    [Header("Pistol")]
    public GameObject pistol_ground;
    public GameObject pistol;
    public GameObject ammo;

	// Start is called before the first frame update
	void Start()
    {
        pistol_ground.SetActive(true);
        pistol.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {

            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Highlight"))
            {
                textMeshPro.text = "Press E to interact";
            }

            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("whatisground"))
            {
                textMeshPro.text = "";
            }

            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("door"))
            {
				textMeshPro.text = "Press E to enter";
			}

            if (hit.transform.gameObject.name == "Cube" && Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene("map-beta");
            }

			if (hit.transform.gameObject.name == "Box" && Input.GetKey(KeyCode.E))
            {
                animator.Play("open");

                StartCoroutine(seconds());

                playerAnimator.Play("Gathering");

                task.text = "Task: Kill the seals";
			}

		} else
        {
            textMeshPro.text = "";
        }

    }

    IEnumerator seconds()
    {
        yield return new WaitForSeconds(1);

		pistol.SetActive(true);
		pistol_ground.SetActive(false);

        ammo.SetActive(true);
	}
}
