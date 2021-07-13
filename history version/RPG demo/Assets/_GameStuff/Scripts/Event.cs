using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : ScriptableObject
{
    public EventType m_Type;
    public Attribute m_AffectAttrib;
    public float m_Possibulity;
    public bool m_isSuccess;
}
