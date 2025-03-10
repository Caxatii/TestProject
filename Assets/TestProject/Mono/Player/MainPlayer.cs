using TestProject.Mono.Environment;
using TestProject.Mono.Interactions;
using UnityEngine;

namespace TestProject.Mono.Player
{
    [RequireComponent(typeof(PlayerInputReader), typeof(PlayerLook), typeof(PlayerMover))]
    [RequireComponent(typeof(CharacterController), typeof(ItemHolder), typeof(TouchRaycaster))]
    public class MainPlayer : MonoBehaviour { }
}