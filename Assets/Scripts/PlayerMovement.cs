using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 movement;
    // Start is called before the first frame update
    private void Update()
    {
        movement.x=Input.GetAxisRaw("Horizontal");
        movement.y=Input.GetAxisRaw("Vertical");

    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement*speed*Time.fixedDeltaTime);
    }
}
