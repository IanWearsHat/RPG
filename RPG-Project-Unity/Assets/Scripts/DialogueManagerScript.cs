using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerScript : MonoBehaviour
{
    private Queue<string> sentences;

    // public Text nameText;
    public GameObject dialogueCanvas;
    public Text dialogueText;
    public GameObject icon;

    void Start()
    {
        sentences = new Queue<string>();
    }


    public void StartDialogue(GameObject npcObject) {

      dialogueCanvas.SetActive(true);

      sentences.Clear();

      NPC npc = npcObject.GetComponent<NPC>();
      icon.GetComponent<SpriteRenderer>().sprite = npc.icon;

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
      dialogueCanvas.SetActive(false);
    }

}
