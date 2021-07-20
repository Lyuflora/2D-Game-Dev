using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gmds 
{
    [CreateAssetMenu(menuName = "gmds/Create Dialogue")]

    public class DialogueDescriptor : ScriptableObject
    {
        // 时间（月 日），对话flowchart
        public string m_BlockName;  // 开启的对话对应的block
        public Sprite m_CG;
    }
}