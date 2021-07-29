using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gmds { 
[CreateAssetMenu(menuName = "gmds/Event/Create Practice Tech")]
public class Tech : ScriptableObject
{
    public string techname;
    public int techID;  //   unique id to distinguish techs (0~23)
    public string effect;
    public string requirement;
    public int level;
    public TechType type;
    public Sprite icon;
}
}
