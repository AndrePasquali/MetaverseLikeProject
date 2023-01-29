using System.Collections.Generic;
using Avatar;
using GameServerFake;
using Genies.Inventory;
using Genies.Menu.Enums;
using Settings;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Genies.Menu
{
    public class MenuCommandController : MonoBehaviour
    {
        private Queue<IMenuCommand> _menuCommands;
        private IMenuCommand _currentCommand;
        private InventoryManager _inventoryManager = new InventoryManager();

        [Header("DEPENDENCIES")]
        [SerializeField] private Material _characterMaterial;
        [SerializeField] private Material _characterHeadMaterial;
        [SerializeField] private Material _backgroundMaterial;
        [SerializeField] private Animator _characterAnimator;
        [SerializeField] private List<MenuOptionButton> _menuOptionButtons;
        [SerializeField] private List<AvatarItemHat> _avatarItemHats;
        [SerializeField] private List<AvatarItemGlasses> _avatarItemGlasses;

        [SerializeField] private ItemSettings _itemSettings;

        private void Start() => Initialize();

        private void Initialize()
        {
            GameServer.Initialize();
            
            MenuOptionButton.OnOptionButtonClick += OnMenuButtonAction;
            MenuItemButton.OnItemButtonClick += OnItemButtonAction;
        }

        private void OnMenuButtonAction(MenuOption actionType, GameObject optionPanel)
        { 
            var optionCommand = new ChangeOptionCommand(actionType, _menuOptionButtons); 
            optionCommand.Execute();
        }

        public void Randomize()
        {
            RandomizedBackground();
            RandomizeGlasses();
            RandomizeBody();
            RandomizeHead();
            RandomizeHat();
        }

        private void RandomizedBackground()
        {
            var randomizedBackground = _itemSettings.BackgroundColors[Random.Range(0, _itemSettings.BackgroundColors.Length)];
            
            var backgroundColorCommand = new ChangeBackgroundCommand(_backgroundMaterial, randomizedBackground);
            backgroundColorCommand.Execute();
            
            _inventoryManager.UpdateBackground(randomizedBackground, 0);
        }

        private void RandomizeBody()
        {
            var randomizedBody = _itemSettings.BodyColors[Random.Range(0, _itemSettings.BodyColors.Length)];
            
            var characterColorChangeCommand = new CharacterBodyCommand(_characterMaterial, randomizedBody);
            characterColorChangeCommand.Execute();
                    
            _inventoryManager.UpdateBody(randomizedBody, 0);
        }

        private void RandomizeHead()
        {
            var randomizedHead = _itemSettings.HeadColors[Random.Range(0, _itemSettings.HeadColors.Length)];
            
            var characterColorChangeCommand = new CharacterHeadCommand(_characterHeadMaterial, randomizedHead);
            characterColorChangeCommand.Execute();
                    
            _inventoryManager.UpdateHead(randomizedHead, 0);
        }

        private void RandomizeHat()
        {
            var randomizedHat = _itemSettings.Hats[Random.Range(0, _itemSettings.Hats.Length)];
            
            var characterHatCommand = new CharacterHatCommand(randomizedHat, _avatarItemHats);
            characterHatCommand.Execute();
                    
            _inventoryManager.UpdateHat(randomizedHat, 0);
        }

        private void RandomizeGlasses()
        {
            var randomizedGlasses = _itemSettings.Glasses[Random.Range(0, _itemSettings.Glasses.Length)];
            
            var characterGlassesCommand = new CharacterGlassesCommand(randomizedGlasses, _avatarItemGlasses);
            characterGlassesCommand.Execute();
                    
            _inventoryManager.UpdateGlasses(randomizedGlasses, 0);
                    
            HandleAnimation();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionType"></param>
        /// <param name="item"></param>
        private void OnItemButtonAction(MenuOption actionType, MenuItemButton item)
        {
            switch (actionType)
            {
                case MenuOption.BACKGROUND:
                {
                    var color = item.GetColor();
                    var backgroundColorCommand = new ChangeBackgroundCommand(_backgroundMaterial, color);

                    backgroundColorCommand.Execute();
                    
                    _inventoryManager.UpdateBackground(color, 0);
                    
                    break;
                }

                case MenuOption.BODY:
                {
                    var color = item.GetColor();
                    
                    var characterColorChangeCommand = new CharacterBodyCommand(_characterMaterial, color);
                    characterColorChangeCommand.Execute();
                    
                    _inventoryManager.UpdateBody(color, 0);
                    break;
                }
                
                case MenuOption.HEAD:
                {
                    var color = item.GetColor();
                    
                    var characterColorChangeCommand = new CharacterHeadCommand(_characterHeadMaterial, color);
                    characterColorChangeCommand.Execute();
                    
                    _inventoryManager.UpdateHead(color, 0);
                    break;
                }

                case MenuOption.ANIMATION:
                {
                    var animationName = item.GetComponent<MenuItemButtonAnimation>().AnimationName;
                    var characterAnimationCommand = new CharacterAnimationCommand(_characterAnimator, animationName);
                    characterAnimationCommand.Execute();
                    
                    break;
                }
                case MenuOption.HAT:
                {
                    var hat = item.GetComponent<MenuItemButtonHat>().AvatarHat;
                    var characterHatCommand = new CharacterHatCommand(hat, _avatarItemHats);
                    characterHatCommand.Execute();
                    
                    _inventoryManager.UpdateHat(hat, 0);
                    
                    HandleAnimation();
                    
                    break;
                }
                case MenuOption.GLASSES:
                {
                    var glasses = item.GetComponent<MenuItemButtonGlasses>().AvatarGlasses;
                    var characterGlassesCommand = new CharacterGlassesCommand(glasses, _avatarItemGlasses);
                    characterGlassesCommand.Execute();
                    
                    _inventoryManager.UpdateGlasses(glasses, 0);
                    
                    HandleAnimation();
                    
                    break;
                }
            }
           
        }

        /// <summary>
        /// 
        /// </summary>
        private void HandleAnimation()
        {
            var allAnimationClipNames = new List<string>{"Wave", "Waving", "Dancing", "HipHop", "Jumping"};
            var animationToPlay = allAnimationClipNames[Random.Range(0, allAnimationClipNames.Count)];
            
            var probability = 3;
            var randomNumber = Random.Range(0, 10);

            if (randomNumber <= probability)
            {
                var characterAnimationCommand = new CharacterAnimationCommand(_characterAnimator, animationToPlay);
                characterAnimationCommand.Execute();
            }
                
        }

        /// <summary>
        /// 
        /// </summary>
        private void ResetColors()
        {
            _characterMaterial.color = Color.white;
            _characterHeadMaterial.color = Color.white;
            _backgroundMaterial.color = Color.black;
            _backgroundMaterial.SetColor("_EmissionColor", Color.black);
        }

        private void OnDestroy() => ResetColors();
    }
}
