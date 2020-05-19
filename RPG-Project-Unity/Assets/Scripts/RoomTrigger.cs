using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomTrigger : MonoBehaviour
{
  public int id; //id should be given through the unity editor

  void OnTriggerEnter2D(Collider2D col) {
    SceneManager.LoadScene(id);
  }

}
