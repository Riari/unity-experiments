using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    void OnCollisionEnter()
    {
        EventManager.TriggerEvent("PressurePlatePressed");
    }
}
