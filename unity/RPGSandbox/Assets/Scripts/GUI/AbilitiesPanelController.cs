using System.Collections.Generic;
using UnityEngine;
using RPGSandbox.Abilities;

namespace RPGSandbox.GUI
{
    public class AbilitiesPanelController : MonoBehaviour
    {
        public GameObject ContentContainer;
        public GameObject AbilityEntry;
        public Abilities.Abilities Abilities;

        void Start()
        {
            Abilities = FindObjectOfType<Abilities.Abilities>();
            RegisterEvents();
        }

        void RegisterEvents()
        {
            Abilities.LoadedEvent += OnAbilitiesLoaded;
        }

        void UnregisterEvents()
        {
            Abilities.LoadedEvent -= OnAbilitiesLoaded;
        }

        void OnAbilitiesLoaded(Dictionary<string, Ability> abilities)
        {
            Debug.Log("Received Abilities.LoadedEvent");
        }

        private void OnEnable() => RegisterEvents();
        private void OnDisable() => UnregisterEvents();
        private void OnDestroy() => UnregisterEvents();
    }
}