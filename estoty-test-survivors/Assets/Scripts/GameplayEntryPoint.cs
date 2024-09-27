using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace estoty_test
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        [Inject] 
        private void Construct(CharacterConfigScriptableObject playerConfig)
        {
            Instantiate(playerConfig.View);
        }
    }
}