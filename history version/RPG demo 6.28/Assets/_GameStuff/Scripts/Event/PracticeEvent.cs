using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "gmds/Event/Create Practice Event")]
public class PracticeEvent : BaseEvent
{
    [SerializeField]
    private int difficulty; // 练习项目难度（与积累exp相关）
    [SerializeField]
    private PlayerMode mode;    // 云玩或真玩

    // 积累exp
    // 技术（为了区分“技能”）收获

    private void Awake()
    {
        base.Awake();
        m_Genre = EventGenre.Practice;
    }
    public override void HandleEvent()
    {
        base.HandleEvent();

        // 显示CG画面

        // 好友收获
        Debug.Log("获得朋友...");
    }
}
