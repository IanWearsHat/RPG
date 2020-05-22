using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    Vector2 lookDirection;
    private float speed;

    bool talking = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        lookDirection = new Vector2(0,-1);
    }

    // Update is called once per frame
    void Update()
    {
      if (!talking) {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        speed = 6f;
        if (Input.GetKey(KeyCode.LeftShift)) {
          speed *= 1.5f;
        }

        Vector2 position = rigidbody2d.position;
        position.x += speed * horizontal * Time.deltaTime;
        position.y += speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);


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

       }

      //interact key should go here as a variable to change in settings
      if (Input.GetKeyDown(KeyCode.X)) {
        if (!talking) {
          RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position, lookDirection, 0.4f, LayerMask.GetMask("NPC"));
          if (hit.collider != null && hit.collider.gameObject.layer == 11) {

            FindObjectOfType<DialogueManagerScript>().StartDialogue(hit.collider.gameObject);
            Debug.Log("Raycast has hit " + hit.collider.gameObject);

            talking = true;
        }

      }
        else if (talking) {
          talking = FindObjectOfType<DialogueManagerScript>().DisplayNextSentence();

        }

      }

    }


}
