using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gmds{

public class PracticeManager : MonoBehaviour
{
    public List<Tech> m_TechAttained = new List<Tech>();
    public static PracticeManager m_Instance;

    public GameObject m_TechsParent;

    [Header("UI")]
    public TMP_Text playerNameText;
    public TMP_Text playerAgeText;
    public TMP_Text playerSalaryText;

    public int[] m_Exp = new int[12];

    public int[] m_WeekPractice = new int[3];

    private void Awake()
    {
        m_Instance = this;
        m_TechAttained.Clear();
    }
    private void Start()
    {
        for(int i = 0; i < 24; i++)
        {
            m_TechsParent.transform.GetChild(i).GetComponent<Button>().interactable = false;
        }
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
        //ClearOldTechProfile();
        playerNameText.text = PlayerStatus.m_Instance.GetPlayerName();
        playerAgeText.text = PlayerStatus.m_Instance.GetPlayerAge();
        playerSalaryText.text = PlayerStatus.m_Instance.GetPlayerSalary();
        
        for (int i = 0; i < m_TechAttained.Count; i++)
        {
            int childID = m_TechAttained[i].techID;
            m_TechsParent.transform.GetChild(childID).GetComponent<Button>().interactable = true;              
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