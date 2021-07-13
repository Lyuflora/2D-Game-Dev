using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace Gmds
{
    public class EventButton : MonoBehaviour
    {
        public TMP_Text m_Text;

        public void Awake()
        {

        }
        public void SetButtonProperties(BaseEvent rEvent)
        {
            //m_Event = rEvent;

            Texture2D buttonTexture = rEvent.m_ButtonTexture;
            //if (buttonTexture == null)
            //{
            //    Debug.LogWarningFormat(
            //        rEvent,
            //        "Button Texture not set for {0}, {1}", rBrush.DurableName, rBrush.m_Guid);
            //    buttonTexture = BrushCatalog.m_Instance.DefaultBrush.m_ButtonTexture;
            //}
            //m_BrushIconTexture = buttonTexture;
            //m_PreviewCubeScript.SetSampleQuadTexture(buttonTexture);
            //SetButtonTexture(buttonTexture);

        }
        virtual public void OnEventButtonPressed()
        {
            EventManager.m_Instance.AddEventToWishlist(this.gameObject);
        }
        public void SetButtonSelected()
        {


        }
    }
}