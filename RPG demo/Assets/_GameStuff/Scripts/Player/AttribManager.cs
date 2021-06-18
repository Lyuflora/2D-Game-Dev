using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class AttribManager : MonoBehaviour
{

    [Serializable]
    public struct Attribute
    {
        // ���������������µļ��ܵ���
        public string name;
        public int points;
    }
    public Attribute[] m_Attribs;  // 5�����ԣ�������4��ϸ�ֵ�������

    static public AttribManager m_Instance;
    [SerializeField]
    private int m_TotalPoints = 15;  // ��ʼ�ܵ�����15
    [SerializeField]
    private int m_CurrentPoints = 0;
    private int m_RemainedPoints = 15;

    public TMP_Text m_RemainedPointsText;
    public TMP_Text[] m_AttribPointsText;


    private void Awake()
    {
        m_Instance = this;
    }
    private void Start()
    {
        // initialize skills for each attribute
        InitializeAttribs();
    }

    void InitializeAttribs()
    {
        Debug.Log(m_Attribs.Length);
        for (int i = 0; i < m_Attribs.Length; i++)
        {
            m_Attribs[i].points = 0;
        }
    }

    // ���µ�����ʾ
    void UpdatePointsDisplay()
    {
        m_RemainedPointsText.text = m_RemainedPoints.ToString();

        for(int i = 0; i < m_AttribPointsText.Length; i++)
        {
            m_AttribPointsText[i].text = m_Attribs[i].points.ToString();
        }
    }

    public void OnPointsIncreaseButtonClick(int attribID)
    {
        if (m_CurrentPoints >= m_TotalPoints|| m_Attribs[attribID].points >= m_TotalPoints)
        {
            // ��ִ��
            return;
        }
        // Debug.Log(attribID);
        m_Attribs[attribID].points++;
        m_CurrentPoints++;
        m_RemainedPoints--;
        UpdatePointsDisplay();
    }

    public void OnPointsDecreaseButtonClick(int attribID)
    {
        if (m_CurrentPoints <=0|| m_Attribs[attribID].points<=0)
        {
            // ��ִ��
            return;
        }
        // Debug.Log(attribID);
        m_Attribs[attribID].points--;
        m_CurrentPoints--;
        m_RemainedPoints++;
        UpdatePointsDisplay();
    }

}
