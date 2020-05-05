using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_Controller : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      float horizontal = Input.GetAxisRaw("Horizontal");
      float vertical = Input.GetAxisRaw("Vertical");

      speed = 0.1f;
      if (Input.GetKey(KeyCode.LeftShift)) {
        speed = 0.2f;
      }

      Vector2 position = rigidbody2d.position;
      position.x += speed * horizontal;
      position.y += speed * vertical;

      rigidbody2d.MovePosition(position);
    }
}
