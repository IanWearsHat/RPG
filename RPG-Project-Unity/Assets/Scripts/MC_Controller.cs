using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MC_Controller : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    public float speed = 3f;

    Facing direction = Facing.DOWN;
    Vector2 lookDirection;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        lookDirection = new Vector2(0,-1);
    }

    // Update is called once per frame
    void Update()
    {
      float horizontal = Input.GetAxisRaw("Horizontal");
      float vertical = Input.GetAxisRaw("Vertical");


      if (vertical == 1) {
        lookDirection = Vector2.up;
      }
      else if (vertical == -1) {
        lookDirection = Vector2.down;
      }

      if (horizontal == 1) {
        lookDirection = Vector2.right;
      }
      else if (horizontal == -1) {
         lookDirection = Vector2.left;
       }


      speed = 0.05f;
      if (Input.GetKey(KeyCode.LeftShift)) {
        speed = 0.1f;
      }

      Vector2 position = rigidbody2d.position;
      position.x += speed * horizontal;
      position.y += speed * vertical;

      rigidbody2d.MovePosition(position);

      if (Input.GetKeyDown(KeyCode.X)) {
        RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position, lookDirection, 0.4f, LayerMask.GetMask("NPC"));
        if (hit.collider != null) {
          // SceneManager.LoadScene("Room2");
          Debug.Log("Raycast has hit " + hit.collider.gameObject);
        }
      }
    }

    enum Facing
    {
      UP,
      RIGHT,
      DOWN,
      LEFT
    }
}
