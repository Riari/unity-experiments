using UnityEngine;
using UnityEngine.Events;

public class Turret : MonoBehaviour
{
    private bool Active;
    private Renderer Renderer;

    void Start()
    {
        Renderer = GetComponent<Renderer>();
        Renderer.material.color = Color.red;
    }

    void OnEnable()
    {
        EventManager.StartListening("PressurePlatePressed", OnPressurePlatePressed);
    }

    void OnDisable()
    {
        EventManager.StopListening("PressurePlatePressed", OnPressurePlatePressed);
    }

    void OnPressurePlatePressed()
    {
        Active = !Active;
    }

    void Update()
    {
        Renderer.material.color = Active ? Color.green : Color.red;
    }
}
