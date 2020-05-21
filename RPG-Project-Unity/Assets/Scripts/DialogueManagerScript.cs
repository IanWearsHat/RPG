using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerScript : MonoBehaviour
{

    // public Text nameText;
    public Text dialogueText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      // if (go) {
      //   foreach(string output in sentences) {
      //     Debug.Log(output);
      //   }
      //   go = false;
      // }

    }

    public void StartDialogue(GameObject npcObject) {

      NPC npc = npcObject.GetComponent<NPC>();

      // nameText.text = npc.NPC_name;
      dialogueText.text = npc.sentences[0];

      Debug.Log(npc.NPC_name);

    }

}
