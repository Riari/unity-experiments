using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSandbox.GUI
{
    public class MainCanvasController : MonoBehaviour
    {
        public GameObject AbilitiesPanel;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                AbilitiesPanel.SetActive(!AbilitiesPanel.activeSelf);
            }
        }
    }
}
