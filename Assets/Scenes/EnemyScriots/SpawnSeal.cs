using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSeal : MonoBehaviour
{
    public GameObject seal;
    public int count;
    // Start is called before the first frame update
    void Start()
    {
		for (int i = 0; i < count; i++)
		{
			GameObject seal2 = Instantiate(seal);
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
