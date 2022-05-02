using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rbody2D;
    [SerializeField] private float currentspeed;
    [SerializeField] private float movementSpeed;


    [SerializeField] SpriteRenderer sprRenderer;
    [SerializeField] Animator anmtr;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Movement();

    }
    void Update()
    {
        Inputs();
    }
    void Inputs()
    {
        currentspeed = Input.GetAxis("Horizontal");
        
        if (currentspeed != 0)
        {
            if (currentspeed < 0)
            {
                sprRenderer.flipX = true;
                anmtr.SetBool("isRunning", true);
            }
            else
            {
                sprRenderer.flipX = false;
                anmtr.SetBool("isRunning", true);
            }    
        }
        else
        {
            anmtr.SetBool("isRunning", false);
        }
    }
    void Movement()
    {
        rbody2D.velocity = currentspeed * Vector2.right * movementSpeed + rbody2D.velocity.y * Vector2.up;
    }
}
