using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC_file", menuName = "NPC_Files_Archive")]
public class NPC : ScriptableObject
{
    public string NPCName;
    [TextArea(3,15)]
    public string[] NPCDialogue;
    
    [TextArea(3,15)]
    public string[] playerDialogue;



}
