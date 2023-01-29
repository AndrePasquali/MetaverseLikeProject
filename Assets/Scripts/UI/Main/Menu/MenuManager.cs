using System;
using System.Threading.Tasks;
using DG.Tweening;
using Genies.Menu;
using Genies.Menu.Enums;
using Settings;
using UnityEngine;

namespace Genies.UI.Main
{
    public sealed class MenuManager: MonoBehaviour
    {
        [Header("Content Sections Parents")]
        [SerializeField] private Transform _backgroundSectionParent;
        [SerializeField] private Transform _bodySectionParent;
        [SerializeField] private Transform _headSectionParent;
        [SerializeField] private Transform _animationsSectionParent;
        [SerializeField] private Transform _hatSectionParent;
        [SerializeField] private Transform _glassesSectionParent;
        
        [SerializeField] protected ItemSettings Items;

        [SerializeField] private MenuItemButton _itemPrefab;
        [SerializeField] private MenuItemButtonAnimation _itemAnimationPrefab;
        [SerializeField] private MenuItemButtonGlasses _itemGlassesPrefab;
        [SerializeField] private MenuItemButtonHat _itemHatPrefab;

        private void Start() => CreateItems();

        private void CreateItems()
        {
            CreateHeadBackgroundSection();
            CreateBackgroundSection();
            CreateAnimationSection();
            CreateGlassesSection();
            CreateBodySection();
            CreateHatSection();
        }

        private async void CreateBackgroundSection()
        {
            var backgroundItems = Items.BackgroundColors;

            for (int i = 0; i < backgroundItems.Length; i++)
            {
                var item = Instantiate(_itemPrefab);
                item.SetupOption(MenuOption.BACKGROUND);
                item.Image.color = backgroundItems[i];
                item.transform.SetParent(_backgroundSectionParent);
                item.Image.DOFade(1, 0.25F);

                await Task.Delay(TimeSpan.FromSeconds(0.1F));
            }
        }

        private async void CreateBodySection()
        {
            var bodyItems = Items.BodyColors;

            for (int i = 0; i < bodyItems.Length; i++)
            {
                var item = Instantiate(_itemPrefab);
                item.SetupOption(MenuOption.BODY);
                item.Image.color = bodyItems[i];
                item.transform.SetParent(_bodySectionParent);
                
                item.Image.DOFade(1, 0.25F);

                await Task.Delay(TimeSpan.FromSeconds(0.1F));
            }
        }

        private async void CreateHeadBackgroundSection()
        {
            var headItems = Items.HeadColors;

            for (int i = 0; i < headItems.Length; i++)
            {
                var item = Instantiate(_itemPrefab);
                item.SetupOption(MenuOption.HEAD);
                item.Image.color = headItems[i];
                item.transform.SetParent(_headSectionParent);
                
                item.Image.DOFade(1, 0.25F);

                await Task.Delay(TimeSpan.FromSeconds(0.1F));
            }
        }

        private async void CreateAnimationSection()
        {
            var AnimationItems = Items.Animations;

            for (var i = 0; i < AnimationItems.Length; i++)
            {
                var item = Instantiate(_itemAnimationPrefab);
                item.SetupOption(MenuOption.ANIMATION);
                var animationClipName = AnimationItems[i];
                item.AnimationName = animationClipName;
                item.transform.SetParent(_animationsSectionParent);
                
                item.Image.DOFade(1, 0.25F);

                await Task.Delay(TimeSpan.FromSeconds(0.1F));

            }
        }

        private async void CreateHatSection()
        {
            var hatItems = Items.Hats;

            for (int i = 0; i < hatItems.Length; i++)
            {
                var item = Instantiate(_itemHatPrefab);
                item.SetupOption(MenuOption.HAT);
                item.AvatarHat = hatItems[i];
                item.transform.SetParent(_hatSectionParent);
                
                item.Image.DOFade(1, 0.25F);

                await Task.Delay(TimeSpan.FromSeconds(0.1F));
            }
        }

        private async void CreateGlassesSection()
        {
            var glassesItems = Items.Glasses;

            for (int i = 0; i < glassesItems.Length; i++)
            {
                var item = Instantiate(_itemGlassesPrefab);
                item.SetupOption(MenuOption.GLASSES);
                item.AvatarGlasses = glassesItems[i];
                item.transform.SetParent(_glassesSectionParent);
                
                item.Image.DOFade(1, 0.25F);

                await Task.Delay(TimeSpan.FromSeconds(0.1F));
            }
        }
    }
}