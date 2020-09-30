using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace RPGSandbox.Abilities
{
    public class Abilities : MonoBehaviour
    {
        public string DataPath = "Assets/Data/Abilities";
        Dictionary<string, Ability> abilities = new Dictionary<string, Ability>();

        public event Action<Dictionary<string, Ability>> LoadedEvent;

        void Start()
        {
            Task.Run(LoadAbilities).ContinueWith(result => LoadedEvent?.Invoke(abilities));
        }

        void LoadAbilities()
        {
            DirectoryInfo directory = new DirectoryInfo(DataPath);
            foreach (var file in directory.GetFiles("*.json"))
            {
                using (StreamReader reader = File.OpenText(file.FullName))
                {
                    string json = reader.ReadToEnd();
                    Ability ability = JsonUtility.FromJson<Ability>(json);
                    abilities.Add(ability.Name, ability);
                    reader.Close();
                }
            }
        }
    }
}