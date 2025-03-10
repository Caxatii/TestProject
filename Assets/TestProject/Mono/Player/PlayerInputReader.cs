using UnityEngine;
using Zenject;

namespace TestProject.Mono.Player
{
    public class PlayerInputReader : MonoBehaviour
    {
        [Inject] private FixedJoystick _joystick;
        
        public Vector2 JoystickDirection {get; private set;}

        private void Update()
        {
            JoystickDirection = _joystick.Direction;
        }
    }
}

