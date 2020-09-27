using System.Collections.Generic;
using UnityEngine;

namespace RPGSandbox.Player
{
    public class AbilitiesController : MonoBehaviour
    {
        float maxTargetDistance = 100f;
        bool isTargeting = false;
        bool hasValidTarget = false;
        RaycastHit targetPosition;
        GameObject selectedAbility;

        public Light targetLight;

        public List<GameObject> abilities;

        void Update()
        {
            if (abilities.Count == 0) return;

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                StartTargeting();
                selectedAbility = abilities[0];
            }
            else if (abilities.Count > 1 && Input.GetKeyDown(KeyCode.Alpha2))
            {
                StartTargeting();
                selectedAbility = abilities[1];
            }
            else if (abilities.Count > 2 && Input.GetKeyDown(KeyCode.Alpha3))
            {
                StartTargeting();
                selectedAbility = abilities[2];
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
                Use(selectedAbility);
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

        void Use(GameObject ability)
        {
            ability.transform.position = targetPosition.point;
            ParticleSystem particles = ability.GetComponent<ParticleSystem>();
            particles.Play();
        }
    }
}