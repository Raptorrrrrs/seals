using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PistolShooting : MonoBehaviour
{
    [Header("Gun")]
    public Animator animator;
    public ParticleSystem bulletEffect;
    public ParticleSystem shoot;
    public ParticleSystem blood;
    public GameObject pistol;
    public GameObject enemy;
    public TextMeshProUGUI ammoN;

    [Header("Variables")]
	public float range = 80f;
	public float damage = 5f;
	public float impact = 0.1f;

	[Header("Cam")]
    public GameObject cam;

    [Header("Audio")]
    public AudioClip shooting;
    public AudioClip reloading;
    public AudioSource audioSource;

    RaycastHit hit;
    int ammo = 0;

	// Start is called before the first frame update
	void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && pistol.activeSelf == true && ammo < 10)
        {
            animator.Play("Shooting");
			shoot.Play();
			Shooting();
        }    

        if (Input.GetKeyUp(KeyCode.R))
        {
            animator.Play("Reload");
            audioSource.PlayOneShot(reloading);

            ammo = 0;

			ammoN.text = (10 - ammo).ToString();
		}
    }

    private void Shooting()
    {
		ammo += 1;

		ammoN.text = (10 - ammo).ToString();

		audioSource.PlayOneShot(shooting);

		if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range) && ammo < 10)
        {
			GameObject impactOB = Instantiate(bulletEffect, hit.point, Quaternion.LookRotation(hit.normal)).gameObject;

            Destroy(impactOB, 3f);

			if (hit.rigidbody != null)
			{
				hit.rigidbody.AddForce(-hit.point * impact);
			}

            if (hit.collider.gameObject == enemy)
            {
				GameObject bloodOB = Instantiate(blood, hit.point, Quaternion.LookRotation(hit.normal), enemy.transform).gameObject;

				Destroy(bloodOB, 5f);
                
			}

            if (hit.collider.gameObject.name == "seal (1)(Clone)")
            {
				GameObject bloodOB = Instantiate(blood, hit.point, Quaternion.LookRotation(hit.normal), hit.collider.gameObject.transform).gameObject;

				Destroy(bloodOB, 5f);
			}
		}

		if (ammo >= 10)
		{
			animator.Play("Reload");
			audioSource.PlayOneShot(reloading);
			ammo = 0;
		}
	}
}
