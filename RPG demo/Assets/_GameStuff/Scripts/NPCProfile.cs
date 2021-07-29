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
        public Text m_Percentage;
        public Image m_Image;
        public Slider m_DevProgressSlider;

        public void RefreshNPCProfile(NPC npc)
        {
            m_NameText.text = npc.NPCname;
            m_JobText.text = npc.job.ToString();
            m_Image.sprite = npc.img;
            // todo
            m_DevStage.text = npc.stage.ToString();
            //m_Percentage.text = ((((int)npc.stage) + 1) * 25).ToString() + "%";
            //m_DevProgressSlider.value = (float)((((int)npc.stage) + 1) * 25) / 100;
        }


    }
}
