using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsSP : MonoBehaviour
{
    
    BoxCollider trigger;

    // Start is called before the first frame update
    public enum CollectibleType
    {
        DEER,
        PIG,
        WOLF,
        RABBIT,
        BEAR,
        CHICKEN,
        COW
    }
    public CollectibleType currentCollectible;
    private void Start()
    {
       
        trigger = GetComponent<BoxCollider>();
      
    }
    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        CanvisManager canvisManager = FindObjectOfType<CanvisManager>();

        switch (currentCollectible)
        {
            case CollectibleType.DEER:
                Debug.Log("Deer");
               
                trigger.enabled = false;
                break;
            case CollectibleType.PIG:
                Debug.Log("Pig");
                
                
                trigger.enabled = false;
                break;
            case CollectibleType.WOLF:
                Debug.Log("Wolf");
                
                trigger.enabled = false;
                break;
            case CollectibleType.RABBIT:
                Debug.Log("Rabbit");
                
                trigger.enabled = false;
                break;
            case CollectibleType.BEAR:
                Debug.Log("Bear");
                
                trigger.enabled = false;


                break;
            case CollectibleType.CHICKEN:
                Debug.Log("Chicken");

                trigger.enabled = false;
                break;
            case CollectibleType.COW:
                Debug.Log("Cow");

                trigger.enabled = false;
                break;
        }
    }
}
