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
}
}