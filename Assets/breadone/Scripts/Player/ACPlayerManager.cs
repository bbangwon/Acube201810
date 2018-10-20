using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ACube201810
{
    public class ACPlayerManager : Singleton<ACPlayerManager>
    {
        [SerializeField]
        ACPlayer[] playerPrefabs;

        public ACPlayer CreatePlayer()
        {
            return Instantiate<ACPlayer>(playerPrefabs[0]);
        }
        
    } 
}
