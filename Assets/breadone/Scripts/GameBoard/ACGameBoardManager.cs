using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ACube201810
{
    public class ACGameBoardManager : Singleton<ACGameBoardManager>
    {

        [SerializeField]
        ACGameBoard gameBoardPrefabs;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public ACGameBoard CreateGameBoard()
        {
            return Instantiate<ACGameBoard>(gameBoardPrefabs);
        }
    }

}