using System;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.UI;

namespace UnityStandardAssets.Utility
{
    [RequireComponent(typeof (Text))]
=======

namespace UnityStandardAssets.Utility
{
   // [RequireComponent(typeof (GUIText))]
>>>>>>> test-scene
    public class FPSCounter : MonoBehaviour
    {
        const float fpsMeasurePeriod = 0.5f;
        private int m_FpsAccumulator = 0;
        private float m_FpsNextPeriod = 0;
        private int m_CurrentFps;
<<<<<<< HEAD
        const string display = "{0} FPS";
        private Text m_Text;
=======
       // const string display = "{0} FPS";
     //   private GUIText m_GuiText;
>>>>>>> test-scene


        private void Start()
        {
            m_FpsNextPeriod = Time.realtimeSinceStartup + fpsMeasurePeriod;
<<<<<<< HEAD
            m_Text = GetComponent<Text>();
=======
           // m_GuiText = GetComponent<GUIText>();
>>>>>>> test-scene
        }


        private void Update()
        {
            // measure average frames per second
            m_FpsAccumulator++;
            if (Time.realtimeSinceStartup > m_FpsNextPeriod)
            {
<<<<<<< HEAD
                m_CurrentFps = (int) (m_FpsAccumulator/fpsMeasurePeriod);
                m_FpsAccumulator = 0;
                m_FpsNextPeriod += fpsMeasurePeriod;
                m_Text.text = string.Format(display, m_CurrentFps);
=======
             //   m_CurrentFps = (int) (m_FpsAccumulator/fpsMeasurePeriod);
                m_FpsAccumulator = 0;
                m_FpsNextPeriod += fpsMeasurePeriod;
               // m_GuiText.text = string.Format(display, m_CurrentFps);
>>>>>>> test-scene
            }
        }
    }
}
