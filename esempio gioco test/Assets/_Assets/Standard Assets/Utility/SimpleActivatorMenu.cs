using System;
using UnityEngine;

namespace UnityStandardAssets.Utility
{
    public class SimpleActivatorMenu : MonoBehaviour
    {
        // An incredibly simple menu which, when given references
        // to gameobjects in the scene
<<<<<<< HEAD
        public GUIText camSwitchButton;
=======
        //public GUIText camSwitchButton;
>>>>>>> test-scene
        public GameObject[] objects;


        private int m_CurrentActiveObject;


        private void OnEnable()
        {
            // active object starts from first in array
            m_CurrentActiveObject = 0;
<<<<<<< HEAD
            camSwitchButton.text = objects[m_CurrentActiveObject].name;
=======
       //     camSwitchButton.text = objects[m_CurrentActiveObject].name;
>>>>>>> test-scene
        }


        public void NextCamera()
        {
            int nextactiveobject = m_CurrentActiveObject + 1 >= objects.Length ? 0 : m_CurrentActiveObject + 1;

            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(i == nextactiveobject);
            }

            m_CurrentActiveObject = nextactiveobject;
<<<<<<< HEAD
            camSwitchButton.text = objects[m_CurrentActiveObject].name;
=======
        //    camSwitchButton.text = objects[m_CurrentActiveObject].name;
>>>>>>> test-scene
        }
    }
}
