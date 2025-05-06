using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{

    // variables 

    public float moveSpeed = 10f;
    public float gravity = -9.81f;

    // For camera based movement (camera follows the character) 
    public Transform cameraTransform;


    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
