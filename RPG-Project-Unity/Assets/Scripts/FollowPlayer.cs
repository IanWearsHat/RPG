using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rigidbody2d;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("vigilius");
        Vector2 playerPosition = player.GetComponent<Rigidbody2D>().position;

        Vector2 position = rigidbody2d.position;
        float distance = Vector2.Distance(position, playerPosition);
        position = Vector2.Lerp(position, playerPosition, (4f * Time.deltaTime)/distance);
        rigidbody2d.MovePosition(position);

    }
}
