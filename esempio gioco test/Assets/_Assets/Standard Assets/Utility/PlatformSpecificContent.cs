using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UnityStandardAssets.Utility
{
#if UNITY_EDITOR

    [ExecuteInEditMode]
#endif
    public class PlatformSpecificContent : MonoBehaviour
<<<<<<< HEAD
#if UNITY_EDITOR
        , UnityEditor.Build.IActiveBuildTargetChanged
#endif
=======
>>>>>>> test-scene
    {
        private enum BuildTargetGroup
        {
            Standalone,
            Mobile
        }

<<<<<<< HEAD
        [SerializeField]
        private BuildTargetGroup m_BuildTargetGroup;
        [SerializeField]
        private GameObject[] m_Content = new GameObject[0];
        [SerializeField]
        private MonoBehaviour[] m_MonoBehaviours = new MonoBehaviour[0];
        [SerializeField]
        private bool m_ChildrenOfThisObject;
=======
        [SerializeField] private BuildTargetGroup m_BuildTargetGroup;
        [SerializeField] private GameObject[] m_Content = new GameObject[0];
        [SerializeField] private MonoBehaviour[] m_MonoBehaviours = new MonoBehaviour[0];
        [SerializeField] private bool m_ChildrenOfThisObject;
>>>>>>> test-scene

#if !UNITY_EDITOR
	void OnEnable()
	{
		CheckEnableContent();
	}
<<<<<<< HEAD
#else
        public int callbackOrder
        {
            get
            {
                return 1;
            }
        }
=======
>>>>>>> test-scene
#endif

#if UNITY_EDITOR

        private void OnEnable()
        {
<<<<<<< HEAD
=======
          //  EditorUserBuildSettings.activeBuildTargetChanged += Update;
>>>>>>> test-scene
            EditorApplication.update += Update;
        }


        private void OnDisable()
        {
<<<<<<< HEAD
            EditorApplication.update -= Update;
        }

        public void OnActiveBuildTargetChanged(BuildTarget previousTarget, BuildTarget newTarget)
        {
            CheckEnableContent();
        }
=======
          //  EditorUserBuildSettings.activeBuildTargetChanged -= Update;
            EditorApplication.update -= Update;
        }

>>>>>>> test-scene

        private void Update()
        {
            CheckEnableContent();
        }
#endif


        private void CheckEnableContent()
        {
<<<<<<< HEAD
#if (UNITY_IPHONE || UNITY_ANDROID || UNITY_WP8 || UNITY_TIZEN)
=======
#if (UNITY_IPHONE || UNITY_ANDROID || UNITY_WP8 || UNITY_BLACKBERRY )
>>>>>>> test-scene
		if (m_BuildTargetGroup == BuildTargetGroup.Mobile)
		{
			EnableContent(true);
		} else {
			EnableContent(false);
		}
#endif

<<<<<<< HEAD
#if !(UNITY_IPHONE || UNITY_ANDROID || UNITY_WP8 || UNITY_TIZEN)
=======
#if !(UNITY_IPHONE || UNITY_ANDROID || UNITY_WP8 || UNITY_BLACKBERRY )
>>>>>>> test-scene
            if (m_BuildTargetGroup == BuildTargetGroup.Mobile)
            {
                EnableContent(false);
            }
            else
            {
                EnableContent(true);
            }
#endif
        }


        private void EnableContent(bool enabled)
        {
            if (m_Content.Length > 0)
            {
                foreach (var g in m_Content)
                {
                    if (g != null)
                    {
                        g.SetActive(enabled);
                    }
                }
            }
            if (m_ChildrenOfThisObject)
            {
                foreach (Transform t in transform)
                {
                    t.gameObject.SetActive(enabled);
                }
            }
            if (m_MonoBehaviours.Length > 0)
            {
                foreach (var monoBehaviour in m_MonoBehaviours)
                {
                    monoBehaviour.enabled = enabled;
                }
            }
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> test-scene
