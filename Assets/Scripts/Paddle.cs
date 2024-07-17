using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool isPlayer1;
    public float speed;
    public Rigidbody2D rb;
    public Vector3 startPosition;
    public GameObject bullet;

    private float movement;

    private void Start()
    {
        startPosition = transform.position;
    }
    private void Update()
    {
        if (isPlayer1)
        {
            movement = Input.GetAxisRaw("Vertical");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject b = (GameObject)(Instantiate(bullet, transform.position + transform.right * 1.5f, Quaternion.identity));
                b.GetComponent<Rigidbody2D>().AddForce(transform.right * 1000);
            }
        }
        else 
        {
            movement = Input.GetAxisRaw("Vertical2");
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                GameObject b = (GameObject)(Instantiate(bullet, transform.position + transform.right * 1.5f, Quaternion.identity));
                b.GetComponent<Rigidbody2D>().AddForce(transform.right * 1000);
            }
        }

        rb.velocity = new Vector2(rb.velocity.x, movement * speed);
        
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
    }
}
