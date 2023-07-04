using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RPGSandbox.Abilities;

namespace RPGSandbox.GUI
{
    public class AbilitiesPanelController : MonoBehaviour
    {
        public GameObject ContentContainer;
        public GameObject AbilityEntry;
        public AbilitiesLoader AbilitiesLoader;

        void RegisterEvents()
        {
            AbilitiesLoader.LoadedEvent += OnAbilitiesLoaded;
        }

        void UnregisterEvents()
        {
            AbilitiesLoader.LoadedEvent -= OnAbilitiesLoaded;
        }

        void OnAbilitiesLoaded(Dictionary<string, Ability> abilities)
        {
            float entryHeight = (AbilityEntry.transform as RectTransform).rect.height;
            float verticalPosition = -(entryHeight / 2);

            foreach (Ability ability in abilities.Values)
            {
                var entry = Instantiate(AbilityEntry);

                entry.transform.SetParent(ContentContainer.transform);
                entry.transform.localPosition = new Vector3(0, verticalPosition, 0);

                verticalPosition -= entryHeight;

                entry.GetComponent<AbilityEntryController>().SetAbility(ability);
            }
        }

        private void OnEnable() => RegisterEvents();
        private void OnDisable() => UnregisterEvents();
        private void OnDestroy() => UnregisterEvents();
    }
}