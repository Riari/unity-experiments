using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGSandbox.GUI
{
    public class MainCanvasController : MonoBehaviour
    {
        public GameObject SpellsPanel;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                SpellsPanel.SetActive(!SpellsPanel.activeSelf);
            }
        }
    }
}
