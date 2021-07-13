using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gmds
{
    [CreateAssetMenu(fileName = "Manifest", menuName = "Gmds Manifest")]
    public class GmdsManifest : ScriptableObject
    {
        public Attribute[] m_Attributes;

        [Header("Events")]
        public PracticeEvent[] m_PracticeEvents;
        public RestEvent[] m_RestEvents;
        public DevEvent[] m_DevEvents;
        public SocialEvent[] m_SocialEvents;

        [Header("NPCs")]
        public List<NPC> m_NPCArray;    // all 

        [Header("Techs")]
        public Tech[] m_Techs;    // all 

        

    }
}