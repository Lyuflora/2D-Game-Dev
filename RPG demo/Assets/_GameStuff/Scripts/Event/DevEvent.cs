using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gmds{

[CreateAssetMenu(menuName = "gmds/Event/Create Dev Event")]
public class DevEvent : BaseEvent
{
    public DevType type;
    // 积累点数用数组储存
    public Image icon;
    public int m_Progress;

    public override void HandleEvent()
    {
        base.HandleEvent();

        // 开发
        // 项目属性（关卡/系统/数值/剧情）
        GameStatus.m_Instance.m_GameFeatures[((int)type)]++;
        Debug.Log("开发进度+1");
        
    }
    }
}