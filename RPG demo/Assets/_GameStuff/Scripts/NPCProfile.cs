using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gmds
{
    public class NPCProfile : MonoBehaviour
    {
        public TMP_Text m_NameText;
        public TMP_Text m_JobText;
        public TMP_Text m_DevStage;
        public Image m_Image;
        public Slider m_DevProgress;

        public void RefreshProfile(NPC npc)
        {
            m_NameText.text = npc.name;
            m_JobText.text = npc.job.ToString();
            m_Image.sprite = npc.img;
            // todo
            m_DevStage.text = "Brewing";
        }
    }
}
