using System;
using System.Collections.Generic;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;

namespace Unity.VRTemplate
{
    /// <summary>
    /// Controls the steps in the in coaching card.
    /// </summary>
    public class StepManager : MonoBehaviour
    {
        [Serializable]
        class Step
        {
            [SerializeField]
            public GameObject stepObject;

            [SerializeField]
            public GameObject affectedGameobject;

            [SerializeField]
            public string buttonText;
        }

        [SerializeField]
        public TextMeshProUGUI m_StepButtonTextField;

        [SerializeField]
        List<Step> m_StepList = new List<Step>();
        List<GameObject> children = new List<GameObject>();


        int m_CurrentStepIndex = 0;

        public void Next()
        {
            // Yes, this is hacky, and I apologize! We're on a deadline here, unfortunately :c
            switch (m_CurrentStepIndex)
            {
                case 2:
                    // Clone cuz we're getting it from a Prefab :p
                    if (GameObject.Find("Cable(Clone)") != null)
                    {
                        continueToNextStep();
                    }
                    break;
                case 3:
                    // Plug into Laptop
                    if (m_StepList[m_CurrentStepIndex].affectedGameobject.GetComponent<Collider>().enabled == false)
                    {
                        continueToNextStep();
                    }
                    break;
                case 4:
                    // Plug into Server Rack
                    if (m_StepList[m_CurrentStepIndex].affectedGameobject.GetComponent<Collider>().enabled == false)
                    {
                        continueToNextStep();
                    }
                    break;
                default:
                    continueToNextStep();
                    break;
            }
        }

        private void continueToNextStep()
        {
            m_StepList[m_CurrentStepIndex].stepObject.SetActive(false);
            m_CurrentStepIndex = (m_CurrentStepIndex + 1) % m_StepList.Count;
            m_StepList[m_CurrentStepIndex].stepObject.SetActive(true);
            m_StepButtonTextField.text = m_StepList[m_CurrentStepIndex].buttonText;
        }
    }
}
