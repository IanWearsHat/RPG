using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerScript : MonoBehaviour
{

    // public Text nameText;
    public Text dialogueText;
    private Queue<string> sentences;


    void Start()
    {
        sentences = new Queue<string>();
    }


    public void StartDialogue(GameObject npcObject) {

      sentences.Clear();

      NPC npc = npcObject.GetComponent<NPC>();

      foreach (string sentence in npc.sentences) {
        sentences.Enqueue(sentence);
      }
      // nameText.text = npc.NPC_name;

      DisplayNextSentence();

      Debug.Log(npc.NPC_name);

    }


    public bool DisplayNextSentence() {

      if (sentences.Count == 0) {
        EndDialogue();
        return false;
      }

      string sentence = sentences.Dequeue();
      StopAllCoroutines();
      StartCoroutine(TypeSentence(sentence));

      return true;

    }


    IEnumerator TypeSentence(string sentence) {
      dialogueText.text = "";

      foreach (char letter in sentence.ToCharArray()) {
        dialogueText.text += letter;
        yield return null; //1 frame delay

      }

    }


    public void EndDialogue() {
      GameObject all = GameObject.Find("All");
      Vector2 position = all.transform.position;
      position.y -= 2;
      all.transform.position = position;

      GameObject dialogueBackground = GameObject.Find("DialogueBackground");
      position = dialogueBackground.transform.position;
      position.y -= 2;
      dialogueBackground.transform.position = position;

      Debug.Log("Dialogue ended.");
    }

}
