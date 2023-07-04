using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RPGSandbox.Abilities;

namespace RPGSandbox.GUI
{
    public class AbilityEntryController : MonoBehaviour
    {
        public Image Icon;
        public Text Name;
        public Text Description;

        public void SetAbility(Ability ability)
        {
            Texture2D icon = Resources.Load<Texture2D>(ability.Icon);
            Icon.sprite = Sprite.Create(icon, new Rect(0, 0, icon.width, icon.height), new Vector2(0.5f, 0.5f));
            Name.text = ability.Name;
            Description.text = ability.Description;
        }
    }
}