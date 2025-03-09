using UnityEngine;

namespace TestProject.Mono.Player
{
    public class PlayerInputReader : MonoBehaviour
    {
        [SerializeField] private FixedJoystick _joystick;
        
        public Vector2 JoystickDirection {get; private set;}

        private void Update()
        {
            JoystickDirection = _joystick.Direction;
        }
    }
}

