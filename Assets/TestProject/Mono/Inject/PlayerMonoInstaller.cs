using TestProject.Mono.Environment;
using TestProject.Mono.Interactions;
using TestProject.Mono.Player;
using TestProject.Mono.UI;
using UnityEngine;
using Zenject;

namespace TestProject.Mono.Inject
{
    public class PlayerMonoInstaller : MonoInstaller
    {
        [SerializeField] private FirstPersonCamera _firstPersonCamera;
        [SerializeField] private MainPlayer _player;
        
        [SerializeField] private FixedJoystick _joystick;
        [SerializeField] private TouchZoneInputReader _touchZoneInput;
        [SerializeField] private ItemDropButton _itemDropButton;
        
        public override void InstallBindings()
        {
            Container.Bind<MainPlayer>().FromInstance(_player).AsSingle();
            Container.Bind<CharacterController>().FromInstance(_player.GetComponent<CharacterController>()).AsSingle();
            Container.Bind<PlayerInputReader>().FromInstance(_player.GetComponent<PlayerInputReader>()).AsSingle();
            Container.Bind<TouchRaycaster>().FromInstance(_player.GetComponent<TouchRaycaster>()).AsSingle();
            Container.Bind<ItemHolder>().FromInstance(_player.GetComponent<ItemHolder>()).AsSingle();
            
            Container.Bind<TouchZoneInputReader>().FromInstance(_touchZoneInput).AsSingle();
            Container.Bind<FirstPersonCamera>().FromInstance(_firstPersonCamera).AsSingle();
            Container.Bind<FixedJoystick>().FromInstance(_joystick).AsSingle();
        }
    }
}
