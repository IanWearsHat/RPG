using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomTrigger : MonoBehaviour
{
  public int id; //id given in inspector, room number found under BuildSettings

  void OnTriggerEnter2D(Collider2D col) {
    SceneManager.LoadScene(id);
  }

}
