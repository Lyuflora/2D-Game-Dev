using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gmds 
{
    [CreateAssetMenu(menuName = "gmds/Create Dialogue")]

    public class DialogueDescriptor : ScriptableObject
    {
        // 时间（月 日），对话flowchart
        public int m_Id;
        public string m_BlockName;
    }
}