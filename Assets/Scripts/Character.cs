using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    CharacterController controller;

    [Header("PlayerSettings")]
    [Space(2)]
    [Tooltip("How Fast The Character Can Move")]
    [Range(1.0f,6.0f)]
    public float speed;
    public float jumpSpeed;
    public float rotationSpeed;
    public float gravity;

    Vector3 moveDirection;

    enum ControllerType { SimpleMove, Move};
    [SerializeField] ControllerType type;

    [Header("Weapon Settings")]
    public float projectileForce;
    public Rigidbody projectilePrefab;
    public Transform projectileSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            controller = GetComponent<CharacterController>();
            controller.minMoveDistance = 0.0f;

            if (speed <= 0)
            {
                speed = 6.0f;
                Debug.Log(" Defaulting Speed to " + speed + "on" + name);
            }
            if (jumpSpeed <= 0)
            {
                jumpSpeed = 6.0f;
                Debug.Log(" Defaulting JumpSpeed to " + jumpSpeed + "on" + name);
            }
            if (rotationSpeed <= 0)
            {
                rotationSpeed = 10.0f;
                Debug.Log(" Defaulting rotationSpeed to " + rotationSpeed + "on" + name);
            }
            if (gravity <= 0)
            {
                gravity = 9.81f;
                Debug.Log(" Defaulting Gravity to " + gravity + "on" + name);
            }
            if (projectileForce <= 0)
            {
                projectileForce = 150.0f;
                Debug.Log(" Defaulting projectileForce to " + projectileForce +"on" + name);
            }
            if(!projectilePrefab)
                Debug.Log(" Defaulting projectilePrefab to " + name);
            if(!projectileSpawnPoint)
                Debug.Log(" Defaulting projectileSpawnPoint to " + name);

            moveDirection = Vector3.zero;
            
        }
        catch (NullReferenceException e)
        {
            Debug.LogWarning(e.Message);
        }
        catch (UnassignedReferenceException e)
        {
            Debug.LogWarning(e.Message);
        }
        finally
        {
            Debug.Log("Always Gets Called");
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (type)
        {
            case ControllerType.SimpleMove:

                //to many get component makes the program run slower
                //if(!GetComponent<MouseLook>())
                //transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed, 0);

                controller.SimpleMove(transform.forward * Input.GetAxis("Vertical") * speed);


                break;

            case ControllerType.Move:

                if (controller.isGrounded)
                {
                    moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                    moveDirection *= speed;
                    moveDirection = transform.TransformDirection(moveDirection);

                    if (Input.GetButtonDown("Jump"))
                    {
                        moveDirection.y = jumpSpeed;
                    }
                }

                moveDirection.y -= gravity * Time.deltaTime;

                controller.Move(moveDirection * Time.deltaTime);


                break;

        }
        if (Input.GetButtonDown("Fire1"))
        {
            fire();
        }
    }
    public void fire()
    {
        if (projectileSpawnPoint && projectilePrefab)
        {

            Debug.Log("Pew Pew!");

            // Make Projectile
            Rigidbody temp = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);

            // Shoot projectile
            temp.AddForce(projectileSpawnPoint.forward * projectileForce, ForceMode.Impulse);

            // Destroy projectile after 2.0s
            Destroy(temp.gameObject, 2.0f);
        }
    }



    [ContextMenu("Reset Stats")]
    void ResetStats()
    {
        speed = 6.0f;
    }
}
