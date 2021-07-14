using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Gmds
{
    public class PanelManager : MonoBehaviour
    {
        public static PanelManager m_Instance;
        public GameObject m_PopupPanel;
        public GameObject m_FriendsPanel;
        public GameObject m_TechsPanel;
        public GameObject m_ProjPanel;
        private void Awake()
        {
            m_Instance = this;
            // 关闭好友界面显示
            Animator animator = m_FriendsPanel.GetComponent<Animator>();
            animator.SetBool("isOpen", false);
        }

        public void RefreshPopup(GameObject Panel, BaseEvent rEvent)
        {
            string popupText = string.Format("Coin: {0:D}\nStrength: {1:D}\nMental: {2:D}\nStrengthExp: {3:D}\nMentalExp: {4:D}", rEvent.dCoin, rEvent.dStrength, rEvent.dMental, rEvent.dStrengthExp, rEvent.dMentalExp);
            m_PopupPanel.GetComponentInChildren<TMP_Text>().text = popupText;
        }

        public void OpenPanel(GameObject Panel)
        {
            Animator animator = Panel.GetComponent<Animator>();
            if (animator)
            {
                bool isOpen = animator.GetBool("isOpen");
                animator.SetBool("isOpen", !isOpen);
            }
        }

        public void OpenFriendsPanel()
        {
            FriendManager.m_Instance.ReloadFriendPanel();
            OpenPanel(PanelManager.m_Instance.m_FriendsPanel);
        }
        public void OpenPopupPanel()
        {
            OpenPanel(PanelManager.m_Instance.m_PopupPanel);
        }
        public void OpenProjPanel()
        {
            OpenPanel(PanelManager.m_Instance.m_ProjPanel);
        }
        public void OpenTechPanel()
        {
            PracticeManager.m_Instance.ReloadTechPanel();
            Debug.Log(App.Instance.m_Manifest.m_Techs.Length);
            for (int i = 0; i < App.Instance.m_Manifest.m_Techs.Length; i++)
            {
                Debug.Log(App.Instance.m_Manifest.m_Techs[i].name);
            }
            OpenPanel(PanelManager.m_Instance.m_TechsPanel);
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                OpenFriendsPanel();
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                OpenPopupPanel();
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                OpenProjPanel();
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                OpenTechPanel();
            }
        }
        public void ClearOldChilds(GameObject parent)
        {
            int evCount = parent.transform.childCount;
            List<GameObject> childList = new List<GameObject>();
            for (int i = 0; i < evCount; i++)
            {
                GameObject child = parent.transform.GetChild(i).gameObject;
                childList.Add(child);
            }
            for (int i = 0; i < childList.Count; i++)
            {
                Destroy(childList[i]);
            }
        }
    }
}