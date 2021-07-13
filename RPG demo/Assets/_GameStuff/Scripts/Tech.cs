using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gmds { 
[CreateAssetMenu(menuName = "gmds/Event/Create Practice Tech")]
public class Tech : ScriptableObject
{
    public string name;
    public string description;
    public int level;
    public TechType type;
    public Sprite icon;
}
}
