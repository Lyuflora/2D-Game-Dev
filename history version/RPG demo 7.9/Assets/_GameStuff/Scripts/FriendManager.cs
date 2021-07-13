using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendManager : MonoBehaviour
{
    public static FriendManager m_Instance;

    public List<NPC> m_NPCArray;    // all 
    [SerializeField] private List<NPC> m_FriendsArray;
    [SerializeField] private List<NPC> m_FriendableArray;

    public GameObject profileObject;
    public GameObject m_FriendsParent;

    public Vector2 origion;

    private void Awake()
    {
        m_Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        ReloadFriendProfile();
    }
    public void ClearOldNPCProfile()
    {
        Debug.Log("开始清除旧的好友资料");
        PanelManager.m_Instance.ClearOldChilds(m_FriendsParent);

    }

    public void ReloadFriendProfile()
    {
        FriendManager.m_Instance.ClearOldNPCProfile();
        var rectTransform = profileObject.GetComponent<RectTransform>();
        float yOffset = rectTransform.sizeDelta.y;
        
        float origionX = m_FriendsParent.transform.position.x;
        float origionY = m_FriendsParent.transform.position.y;
        for (int i = 0; i < m_FriendsArray.Count; i++)
        {
            var p = Instantiate(profileObject, new Vector3(origionX, origionY + yOffset*i, 0), Quaternion.identity);
            p.transform.parent = m_FriendsParent.transform;
            p.GetComponent<NPCProfile>().RefreshProfile(m_FriendsArray[i]);
        }
    }

    public void AddFriend(NPC npc)
    {
        m_FriendsArray.Add(npc);
    }

    public NPC GetFriendByIndex(int i)
    {
        return m_FriendsArray[i];
    }

    public NPC GetNPCByIndex(int i)
    {
        return m_NPCArray[i];
    }
}
