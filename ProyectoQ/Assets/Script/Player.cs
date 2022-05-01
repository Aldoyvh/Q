using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbody2D;
    [SerializeField] private float currentspeed;
    [SerializeField] private float movementSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentspeed = Input.GetAxis("Horizontal");
        rbody2D.velocity = currentspeed * Vector2.right * movementSpeed + rbody2D.velocity.y * Vector2.up;
    }
}
