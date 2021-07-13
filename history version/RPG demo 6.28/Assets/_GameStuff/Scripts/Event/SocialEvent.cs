using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "gmds/Event/Create Social Event")]
public class SocialEvent : BaseEvent
{

    private void Awake()
    {
        base.Awake();
        m_Genre = EventGenre.Social;
    }

    public override void HandleEvent()
    {
        base.HandleEvent();
        
        // �����ջ�
        Debug.Log("�������...");
    }
}
