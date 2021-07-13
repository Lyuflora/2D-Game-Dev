using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "gmds/Event/Create Rest Event")]
public class RestEvent : DailyEvent
{

    private void Awake()
    {
        base.Awake();
        m_Genre = EventGenre.Rest;
    }

    public override void HandleEvent()
    {
        base.HandleEvent();
       
        // 无其他效果
    }
}
