using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIController : MonoBehaviour
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
