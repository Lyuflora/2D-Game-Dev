using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gmds{

[CreateAssetMenu(menuName = "gmds/Event/Create Dev Event")]
public class DevEvent : BaseEvent
{
    public DevType type;
    // ���۵��������鴢��
    public Image icon;
    public int m_Progress;

    public override void HandleEvent()
    {
        base.HandleEvent();

        // ����
        // ��Ŀ���ԣ��ؿ�/ϵͳ/��ֵ/���飩
        GameStatus.m_Instance.m_GameFeatures[((int)type)]++;
        Debug.Log("��������+1");
        
    }
    }
}