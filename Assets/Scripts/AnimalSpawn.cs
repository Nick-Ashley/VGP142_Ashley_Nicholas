using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimalSpawn : MonoBehaviour
{
    public AnimalsSP[] animallist;
    bool isSpawned = false;



    public void StartBoxSpawn()
    {
        try
        {
            Instantiate(animallist[UnityEngine.Random.Range(0, animallist.Length)].gameObject, transform.position, Quaternion.identity);
        }
        catch 
        {
            Debug.Log("Need to set a prefab");
        }

    }
    public void Start()
    {
        
    }
    private void Update()
    {
       
        if (gameObject.activeSelf == true && isSpawned == false ) 
        {
            StartBoxSpawn();
            isSpawned = true;
        }
    }
}
