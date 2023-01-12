using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private NPC npc;
    bool isTalking = false;
    float distance;
    float curResponseTracker = 0;
    public GameObject player;
    public GameObject dialogueUI;
    public GameObject canWeTalk;

    public TextMeshProUGUI npcName;
    public TextMeshProUGUI npcDialogueBox;
    public TextMeshProUGUI playerResponse;
    void Start()
    {
        dialogueUI.SetActive(false);
    }
    void Update(){
        
        detection();

    }

    void OnMouseOver(){

        
    }

    void detection(){
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5f);
        foreach (var hitCollider in hitColliders)
        {
             if (hitCollider.gameObject.tag == "Player")
                    {  
                    distance = Vector3.Distance(player.transform.position, this.transform.position);
        if(distance <= 2.5f){
            if(Input.GetKeyDown(KeyCode.E) && isTalking == false){
            StartConversation();

            
            }
            else if(Input.GetKeyDown(KeyCode.C) && isTalking==true){
                if(curResponseTracker -2 < npc.NPCDialogue.Length){
                    curResponseTracker++;
                    npcDialogueBox.text = npc.NPCDialogue[(int)curResponseTracker];
                    playerResponse.text = npc.playerDialogue[(int)curResponseTracker];
                    if(curResponseTracker == npc.NPCDialogue.Length -1){
                        curResponseTracker = 0;
                        EndConversation();
                    }
                }
                else{
                    curResponseTracker = 0;
                    EndConversation();
                }

            }
            else if (Input.GetKeyDown(KeyCode.E) && isTalking == true){
             EndConversation();

            }
        }


                    }
        }


    }

    void StartConversation(){
        isTalking = true;
        curResponseTracker = 0;
        dialogueUI.SetActive(true);
        npcName.text = npc.NPCName;
        npcDialogueBox.text = npc.NPCDialogue[0];
        playerResponse.text = npc.playerDialogue[0];


    }

    void EndConversation(){
        isTalking = false;
        dialogueUI.SetActive(false);
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            canWeTalk.SetActive(true);
        }
    }
    
    void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "Player"){
            canWeTalk.SetActive(false);
        }
    }


}
