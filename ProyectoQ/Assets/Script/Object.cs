using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public float speedMovement;
    public Rigidbody2D rbody;
    public SpriteRenderer sprRenderer;
    public float lifetime;

    // Start is called before the first frame update
    public void SetUp()
    {
        rbody.velocity = Vector2.right * speedMovement;

        if (rbody.velocity.x < 0) 
            sprRenderer.flipX = true;
        else
            sprRenderer.flipX = false;
        Destroy(gameObject, lifetime);
    }
}
