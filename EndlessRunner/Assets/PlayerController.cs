using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + Input.GetAxis("Horizontal") * Time.deltaTime * 10, transform.position.y);
        //rb2D.velocity = new Vector2(5, rb2D.velocity.y);
       
        
        if (Input.GetKeyDown(KeyCode.Space) && Physics2D.OverlapCircle(transform.position, 1, groundLayer))
        {
            Jump();
        }
    }

    public void Jump() {
        rb2D.AddForce(new Vector2(0, 400));     
    }
}
