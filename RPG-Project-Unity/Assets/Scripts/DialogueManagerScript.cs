using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManagerScript : MonoBehaviour
{

    public string[] sentences;
    bool go = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if (go) {
        foreach(string output in sentences) {
          Debug.Log(output);
        }
        go = false;
      }

    }
}
