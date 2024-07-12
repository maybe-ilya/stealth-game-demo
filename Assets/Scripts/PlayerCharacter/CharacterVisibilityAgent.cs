using MIG.API;
using UnityEngine;

namespace MIG.PlayerCharacter
{
    public sealed class CharacterVisibilityAgent : MonoBehaviour, IVisibilityAgent
    {
        [SerializeField]
        [CheckObject]
        private Character _character;

        public bool IsVisible { get; private set; }

        public IGameActor Actor => _character;

        public void MakeVisible()
        {
            IsVisible = true;
        }

        public void MakeInvisible()
        {
            IsVisible = false;
        }

#if UNITY_EDITOR
        private void Reset()
        {
            _character = GetComponent<Character>();
        }
#endif
    }
}