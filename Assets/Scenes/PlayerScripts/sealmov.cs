using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sealmov : MonoBehaviour
{
  public Rigidbody player;
  public GameObject nplayer;
  private GameObject seal;
  private Vector3 newPosition;
  private Vector3 newPosition2;
  private bool playerfocus;
  public int currentCube = 1;
  private bool go = true;

  private Transform cube1;
  private Transform cube2;
  private Transform poscube;
  public float speed = 10f;
  public float stoppingDistance = 0.1f;
  public Camera animcamera;
   private Animator anim;
  public Light light1;
  public Light light2;
  private Rigidbody rigidbodi;
  void Start()
  {
    anim = gameObject.GetComponent<Animator>();
    light1.intensity = 0;
    light2.intensity = 0;
    rigidbodi = GetComponent<Rigidbody>();
    seal = gameObject;

    //transform.position = getRandomPosition(seal.transform);
    StartCoroutine(MoveTo(rigidbodi));
  }

  // Update is called once per frame
  void Update()
  {
    //GetComponent<Rigidbody>().AddForce(getRandomPosition(seal.transform), ForceMode.Force);
  }

  Vector3 getRandomPosition(Transform pos)
  {
    if (playerfocus)
    {
      newPosition = player.position;
    }
    else
    {
      cube1 = GameObject.Find("Cube" + currentCube).transform;
      cube2 = cube1.transform.Find("Cube");

      Vector3 direction = cube2.position - cube1.position;
      float length = direction.magnitude;

      float t = Random.Range(0.0f, 1.0f);
      Vector3 randomPosition = cube1.position + t * direction;

      newPosition = new Vector3(randomPosition.x, pos.position.y  , randomPosition.z);
    }
    return newPosition;
  }

  IEnumerator MoveTo(Rigidbody rigidbody)
  {
    while (go)
    {
      newPosition2 = getRandomPosition(rigidbody.transform);
      while (Vector3.Distance(rigidbody.transform.position, new Vector3(newPosition2.x, rigidbody.transform.position.y, newPosition2.z)) > stoppingDistance && go)
      {
        if (playerfocus)
        {
          newPosition2 = getRandomPosition(rigidbody.transform);
        }
        rigidbody.transform.LookAt(newPosition2);
        rigidbody.transform.position = Vector3.MoveTowards(rigidbody.transform.position, newPosition2, speed * Time.deltaTime);
        if (Vector3.Distance(rigidbody.transform.position, player.transform.position) < 100)
        {
          playerfocus = true;
        }
        else
        {
          playerfocus = false;
        }
        yield return null;
      }
      if (playerfocus)
      {
        print("dead");
        animcamera.enabled = true;
        anim.SetTrigger("trigger");
        go = false;
      }
      else
      {
        if(currentCube == 0){
          currentCube = 1;
        }else{
          currentCube = 0;
        }
      }
    }
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject == nplayer)
    {
      print(Vector3.forward);
      player.AddForce(Vector3.forward * 120);
    }
  }
}
