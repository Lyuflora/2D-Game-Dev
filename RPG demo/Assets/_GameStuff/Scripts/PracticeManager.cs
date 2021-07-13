using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gmds{

public class PracticeManager : MonoBehaviour
{
    public List<Tech> m_TechAttained = new List<Tech>();
    public static PracticeManager m_Instance;
    public GameObject techObject;
    public GameObject m_TechsParent;

    private void Awake()
    {
        m_Instance = this;
        m_TechAttained.Clear();
    }

    public void LearnTech(int techId)
    {
        // todo
        Debug.Log("—ßœ∞ºº ı" + techId);
        var newTech = App.Instance.m_Manifest.m_Techs[techId];
        m_TechAttained.Add(newTech);
    }
    public void GeneratePractices()
    {
        // C12 3
        
    }

    public void ReloadTechPanel()
    {
        ClearOldTechProfile();
        var rectTransform = techObject.GetComponent<RectTransform>();
        float yOffset = rectTransform.sizeDelta.y;

        float origionX = m_TechsParent.transform.position.x;
        float origionY = m_TechsParent.transform.position.y;
        for (int i = 0; i < m_TechAttained.Count; i++)
        {
            var p = Instantiate(techObject, new Vector3(origionX, origionY + yOffset * i, 0), Quaternion.identity);
            p.transform.parent = m_TechsParent.transform;
            p.GetComponent<TechProfile>().RefreshTech(m_TechAttained[i]);
        }
    }
    public void ClearOldTechProfile()
    {
        PanelManager.m_Instance.ClearOldChilds(m_TechsParent);
    }
        public void GetP()
    {

    }

    public void GetC(ref List<int>list, int[] l, int max, int min, int[] b, int M)
    {
        
    }
}

}