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
}
}