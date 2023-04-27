using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsPlaying : MonoBehaviour
{
    [Header("Sounds")]
    public AudioClip wood_cracking;
    public AudioClip footsteps;

    public AudioSource audioSource;

    bool iscracking = false;
    bool isfootsteps = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wood_Cracking());
        StartCoroutine(Footsteps());
    }

    // Update is called once per frame
    void Update()
    {
        if (iscracking)
        {
            audioSource.PlayOneShot(wood_cracking);

            StartCoroutine(Wood_Cracking());

            iscracking = false;
        }

        if (isfootsteps)
        {
            audioSource.PlayOneShot(footsteps);

            StartCoroutine(Footsteps());

            isfootsteps = false;    
        }
    }

    IEnumerator Wood_Cracking()
    {
        yield return new WaitForSeconds(5 + Random.Range(0, 15));

        iscracking = true;
    }

    IEnumerator Footsteps()
    {
        yield return new WaitForSeconds(10 + Random.Range(0, 15));

        isfootsteps = true;
    }
}
