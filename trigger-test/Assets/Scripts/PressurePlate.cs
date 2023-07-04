using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] List<GameObject> TargetTurretObjects;
    List<Turret> TargetTurrets = new List<Turret>();

    private void Start()
    {
        foreach (var obj in TargetTurretObjects)
        {
            TargetTurrets.Add(obj.GetComponent<Turret>());
        }
    }

    void OnCollisionEnter()
    {
        foreach (var turret in TargetTurrets)
        {
            turret.Toggle();
        }
    }
}
