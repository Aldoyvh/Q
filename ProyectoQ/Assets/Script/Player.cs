using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public bool isAttacking;


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

        Inputs();
        

            
    }
    void Inputs()
    {
        currentspeed = Input.GetAxis("Horizontal");
        anmtr.SetFloat("walkspeed", currentspeed);
        if (currentspeed != 0)
        {
            if (currentspeed < 0)
            {
                sprRenderer.flipX = true;
                
            }
            else
            {
                sprRenderer.flipX = false;
                
            }    
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Piedra"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            Score.points = 0;
        }
        else if (collision.CompareTag("Hazard"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            Score.points = 0;
        }
        else if (collision.CompareTag("Stone"))
        {
            Score.points++;
            Destroy(collision.gameObject);
        }
    }
}


