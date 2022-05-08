using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rbody2D;
    private float currentspeed;
    [SerializeField] private float movementSpeed;


    [SerializeField] SpriteRenderer sprRenderer;
    [SerializeField] Animator anmtr;

    [SerializeField] public AudioSource pasos;


    [SerializeField] Transform feet;
    [SerializeField] float jumpForce;
    [SerializeField] float raycastLenght;
    [SerializeField] LayerMask groundLayer;
    bool willJump;

    [SerializeField] GameObject swordCollider;
    bool isAttacking;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Movement();
        Jump();
    }
    void Update()
    {
        if (!isAttacking)
        {
            Inputs();
        }
            
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
        RaycastHit2D hit = Physics2D.Raycast(feet.position, Vector2.down, raycastLenght, groundLayer);
        if (hit.collider)
        {
            if (Input.GetButtonDown("Jump"))
            {
                willJump = true;
            }
        }
        else
        {
            willJump = false;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Attack();
        }
    }
    void Movement()
    {
        rbody2D.velocity = currentspeed * Vector2.right * movementSpeed + rbody2D.velocity.y * Vector2.up;
    }
    void Jump()
    {
        if (willJump)
        {
            rbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            willJump = false;
        }

    }

    void Attack()
    {
        anmtr.SetTrigger("isAttacking");
        isAttacking = true;
        anmtr.SetBool("isRunning", false);
        if (sprRenderer.flipX)
            swordCollider.transform.localScale = new Vector3(-1, 1, 1);
        else
            swordCollider.transform.localScale = Vector3.one;
    }
    public void EnableSwordCollider()
    {
        swordCollider.SetActive(true);
    }
    public void DisableSwordCollider()
    {
        swordCollider.SetActive(false);
        isAttacking = false;
    }
}
