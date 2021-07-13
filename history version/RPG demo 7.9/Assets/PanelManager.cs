using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public static PanelManager m_Instance;
    public GameObject m_PopupPanel;
    public GameObject m_FriendsPanel;
    private void Awake()
    {
        m_Instance = this;
        // 关闭好友界面显示
        Animator animator = m_FriendsPanel.GetComponent<Animator>();
        animator.SetBool("isOpen", false);
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

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            FriendManager.m_Instance.ReloadFriendProfile();
            OpenPanel(PanelManager.m_Instance.m_FriendsPanel);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            OpenPanel(PanelManager.m_Instance.m_PopupPanel);
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
