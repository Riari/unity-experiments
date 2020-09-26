using System.Collections.Generic;
using UnityEngine;

public class PlayerSpellCaster : MonoBehaviour
{
    float maxTargetDistance = 100f;
    bool isTargeting = false;
    bool hasValidTarget = false;
    RaycastHit targetPosition;
    GameObject selectedSpell;

    public Light targetLight;

    public List<GameObject> spells;

    void Update()
    {
        if (spells.Count == 0) return;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartTargeting();
            selectedSpell = spells[0];
        }
        else if (spells.Count > 1 && Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartTargeting();
            selectedSpell = spells[1];
        }
        else if (spells.Count > 2 && Input.GetKeyDown(KeyCode.Alpha3))
        {
            StartTargeting();
            selectedSpell = spells[2];
        }

        RaycastHit hit = new RaycastHit();
        if (GetTargetPosition(ref hit))
        {
            hasValidTarget = true;
            targetPosition = hit;
        }
        else
        {
            hasValidTarget = false;
        }

        if (isTargeting && Input.GetMouseButton(1))
        {
            EndTargeting();
        }
        else if (isTargeting && Input.GetMouseButton(0))
        {
            EndTargeting();
            Cast(selectedSpell);
        }

        UpdateTargetLight();
    }

    void StartTargeting()
    {
        isTargeting = true;
        targetLight.enabled = true;
    }

    void EndTargeting()
    {
        isTargeting = false;
        targetLight.enabled = false;
    }

    bool GetTargetPosition(ref RaycastHit hit)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        return Physics.Raycast(ray, out hit, maxTargetDistance);
    }

    void UpdateTargetLight()
    {
        if (!isTargeting || !hasValidTarget) return;

        Vector3 targetPos = targetPosition.point;
        targetLight.transform.position = new Vector3(targetPos.x, targetPos.y + 10, targetPos.z);
    }

    void Cast(GameObject spell)
    {
        spell.transform.position = targetPosition.point;
        ParticleSystem particles = spell.GetComponent<ParticleSystem>();
        particles.Play();
    }
}
