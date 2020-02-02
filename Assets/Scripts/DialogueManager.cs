using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Dialogue Conversation;

    public static int i { get; private set; }

    public static int j { get; private set; }

    public static bool InConversation { get; private set; }
    public static bool InSentence { get; private set;}

    //public Text NameTxt;
    public Text SentenceTxt;
    public Image FaceUI;

    public GameObject DialogueUI;

    public static DialogueManager MeInThis { get; private set; }
    void Awake() {
        MeInThis = this;
        DialogueUI.SetActive(false);
        InConversation = false;
    }
	    
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown(KeyCode.X))
        //    StartDialogue();
        if (Input.GetKeyDown(KeyCode.E) && InConversation) {
            if(!InSentence){
                NextSentence();
                print(i + "and" + j);
            }
            else{
                StopAllCoroutines();
                SentenceTxt.text = Conversation.Conversation[i].Sentences[j-1];
                InSentence = false;
            }

        }
		
	}

    //public void StartDialogue(){
    //    Dialogue Conv = Conversation;
    //    if(Conv != null){
    //        StartConversation();
    //    }else{
    //        print("Invalid Conversation");
    //    }
    //}


    public void StartConversation(Dialogue dialogue) {
        i = 0;
        j = 0;
        Conversation = dialogue;
        InConversation = true;
        InSentence = false;
        DialogueUI.SetActive(true);
        NextSentence();
        
    }
    public void NextSentence() {
        
        if (j > Conversation.Conversation[i].Sentences.ToArray().Length-1) {
            NextChat();
            return;
        }
        FaceUI.sprite = Conversation.Conversation[i].Face;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(Conversation.Conversation[i].Sentences[j]));
        j++;


    }

    public void NextChat() {
        i++;
        if (i > Conversation.Conversation.ToArray().Length-1) {
            EndConversation();
            return;
        }
        j = 0;
        
        NextSentence();
    }

    public int Speed;

    IEnumerator TypeSentence(string sentence) {
        SentenceTxt.text = "";
        InSentence = true;
        int i = 0;
        foreach (char letter in sentence.ToCharArray()) {
            SentenceTxt.text += letter;
            if (i == Speed) {
                i = 0;
                yield return null;
            }
            else
                i++;
        }
        InSentence = false;
    }

    public void EndConversation() {
        InConversation = false;
        DialogueUI.SetActive(false);
    }

}
[System.Serializable]
public class Dialogue {
    public List<Chat> Conversation;
}
[System.Serializable]
public class Chat {
    public string Name;
    public List<string> Sentences;
    public Sprite Face;
}