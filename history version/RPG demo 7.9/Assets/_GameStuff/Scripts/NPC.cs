using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "gmds/Player/Create NPC")]
public class NPC : ScriptableObject
{
    public string name;
    public int age;
    public Sprite img;
    public string description;
    public NPCJob job;
    public int level;   //  出身等级

    public NpcAttribute states;
    

}
