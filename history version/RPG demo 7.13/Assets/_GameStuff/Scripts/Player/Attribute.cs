using System.Collections.Generic;
using UnityEngine;
namespace Gmds { 
[CreateAssetMenu(menuName = "gmds/Player/Create Attribute")]

public class Attribute : ScriptableObject
{
    // 属性名，该属性下的技能点数，下属细分技能（4项）
    public AttributeType m_type;
    public string m_Description;
    public int m_CurrentPoint;   // 当前属性点
    public Sprite m_Icon;

    public List<Skill> m_Skills = new List<Skill>();

}
}