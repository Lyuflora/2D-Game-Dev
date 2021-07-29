using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gmds{

public class EventCatalog : MonoBehaviour
{
    public static EventCatalog m_Instance;

    public List<BaseEvent> m_GuiEventList;
    void Awake()
    {
        m_Instance = this;

        m_GuiEventList = new List<BaseEvent>(); // 总的列表
    }
    // 从app读取事件button，加载到界面，点击后加入列表，重载后重新加载button
    void Reload()
    {

    }

}
}