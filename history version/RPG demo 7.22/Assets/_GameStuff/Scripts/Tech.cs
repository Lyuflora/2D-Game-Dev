using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gmds { 
[CreateAssetMenu(menuName = "gmds/Event/Create Practice Tech")]
public class Tech : ScriptableObject
{
    public string name;
    public string effect;
    public string requirement;
    public TechType type;
    public int level;
    public TechRare rare;
    public int id;
    public Sprite icon;
}
}
