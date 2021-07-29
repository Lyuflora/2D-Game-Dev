using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Gmds
{
    public class chat1 : MonoBehaviour
    {

        public InputField chatInput;
        public Text chatText;
        public ScrollRect scrollRect;
        Animator ani;
        bool appear;
        public GameObject chatframe;
        public TMP_Text m_NameText;
        public TMP_Text m_NameText2;

        public Text textbutton1;
        public Text textbutton2;
        public Text textbutton3;
        public Text textbutton4;

        // Use this for initialization
        void Start()
        {
            ani = chatframe.GetComponent<Animator>();
            chatText.text = "系统消息：你已成功添加好友好友：" + "<color=red>" + m_NameText.text + "</color>" + "\n" + "<color=red>" + m_NameText.text + "</color>" + "：好久不见！真是太好了，你也选择了在南门一居住？\n这里很棒的哦，我下了船也没有感觉不适应——等你到了，要不要来我家一趟？妈咪她也很想你。\n要是能继续一起学习就好了，你打算选什么学院？读什么专业？和你父亲一样？";
            if (chatText.text == "系统消息：你已成功添加好友好友：" + "<color=red>" + m_NameText.text + "</color>" + "\n" + "<color=red>" + m_NameText.text + "</color>" + "：好久不见！真是太好了，你也选择了在南门一居住？\n这里很棒的哦，我下了船也没有感觉不适应——等你到了，要不要来我家一趟？妈咪她也很想你。\n要是能继续一起学习就好了，你打算选什么学院？读什么专业？和你父亲一样？")
            {
                textbutton1.text = "1";
                textbutton2.text = "2";
                textbutton3.text = "3";
                textbutton4.text = "4";
            }
        }
        public void RefreshProfile(NPC npc)
        {
            m_NameText.text = npc.name;
            m_NameText2.text = "player";
        }
        public void Clickani()
        {
            appear = !appear;
            if (appear == true)
            {
                ani.SetBool("chat", true);
            }
            else
            {
                ani.SetBool("chat", false);
            }
        }
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (chatInput.text != string.Empty)
                {
                    string addText = "<color=red>" + m_NameText2.text + "</color>: " + chatInput.text;
                    chatText.text += "\n" + addText;
                    chatInput.text = string.Empty;
                    chatInput.ActivateInputField();

                }

                Canvas.ForceUpdateCanvases();       //关键代码
                scrollRect.verticalNormalizedPosition = 0f;  //关键代码
                Canvas.ForceUpdateCanvases();   //关键代码
            }


        }
        public void Clickbutton1()
        {
            if (textbutton1.text == "1")
            {
                chatInput.text = "1";
            }
            chatText.text += "\n" + "<color=red>" + m_NameText2.text + "</color>: " + chatInput.text;
            chatInput.text = string.Empty;
            chatInput.ActivateInputField();
            Canvas.ForceUpdateCanvases();       //关键代码
            scrollRect.verticalNormalizedPosition = 0f;  //关键代码
            Canvas.ForceUpdateCanvases();   //关键代码

        }

        public void Clickbutton2()
        {
            if (textbutton2.text == "2")
            {
                chatInput.text = "2";
            }
            chatText.text += "\n" + "<color=red>" + m_NameText2.text + "</color>: " + chatInput.text;
            chatInput.text = string.Empty;
            chatInput.ActivateInputField();
            Canvas.ForceUpdateCanvases();       //关键代码
            scrollRect.verticalNormalizedPosition = 0f;  //关键代码
            Canvas.ForceUpdateCanvases();   //关键代码
        }
        public void Clickbutton3()
        {
            if (textbutton3.text == "3")
            {
                chatInput.text = "3";
            }
            chatText.text += "\n" + "<color=red>" + m_NameText2.text + "</color>: " + chatInput.text;
            chatInput.text = string.Empty;
            chatInput.ActivateInputField();
            Canvas.ForceUpdateCanvases();       //关键代码
            scrollRect.verticalNormalizedPosition = 0f;  //关键代码
            Canvas.ForceUpdateCanvases();   //关键代码
        }
        public void Clickbutton4()
        {
            if (textbutton4.text == "4")
            {
                chatInput.text = "4";
            }
            chatText.text += "\n" + "<color=red>" + m_NameText2.text + "</color>: " + chatInput.text;
            chatInput.text = string.Empty;
            chatInput.ActivateInputField();
            Canvas.ForceUpdateCanvases();       //关键代码
            scrollRect.verticalNormalizedPosition = 0f;  //关键代码
            Canvas.ForceUpdateCanvases();   //关键代码
        }

    }
}
