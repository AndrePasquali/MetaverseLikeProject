using System;
using System.Collections.Generic;
using System.Linq;
using Avatar.Equipment;
using Genies.Extensions;
using Genies.Inventory;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Avatar
{
    public class AvatarFactory: MonoBehaviour
    {
        [SerializeField] private int AICharactersAmount;
        private List<Inventory> _inventoryList = new List<Inventory>();

        public List<Transform> SpawnPointList => _spawnPointList ??
                                                 (_spawnPointList = _spawnPointTransform
                                                     .GetComponentsInChildren<Transform>().ToList());
        private List<Transform> _spawnPointList;
        [SerializeField] private Transform _spawnPointTransform;
        [SerializeField] private GameObject AvatarPrefab;

        private void Start()
        {
            BuildAvatarCharacters();
        }

        public void BuildAvatarCharacters()
        {
            RandomizeData();
            
            for (var i = 0; i < _inventoryList.Count; i++)
            {
                var wayPoint = SpawnPointList[Random.Range(0, SpawnPointList.Count)];
                if (wayPoint.childCount > 0)
                    wayPoint = SpawnPointList[Random.Range(0, SpawnPointList.Count)];
                
                var avatar = Instantiate(AvatarPrefab, wayPoint);
                
                avatar.GetComponent<AvatarEquipment>().Setup(_inventoryList[i]);
            }
        }

        public void RandomizeData()
        {
            for (int i = 0; i < AICharactersAmount; i++)
            {
                _inventoryList.Add(new Inventory
                {
                    PlayerId = i+1,
                    AvatarHat = (Hat)Random.Range(0, Enum.GetValues(typeof(Hat)).Length) - 1,
                    AvatarGlasses = (Glasses)Random.Range(0, Enum.GetValues(typeof(Glasses)).Length) - 1,
                    BodyColor = Color.white.ToHexString(),
                    HeadColor = Color.white.ToHexString()
                });
            }
        }
    }
}