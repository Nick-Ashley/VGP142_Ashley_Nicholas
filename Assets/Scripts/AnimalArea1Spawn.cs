using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalArea1Spawn : MonoBehaviour
{
    public GameObject spawners;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Spawn Stuff");
        if (collision.gameObject.tag == "ASpawn1")
        {
            spawners.SetActive(true);
            Debug.Log("Spawn Stuff");




        }
    }

    
}
