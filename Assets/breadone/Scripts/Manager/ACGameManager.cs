using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ACube201810
{
    public class ACGameManager : Singleton<ACGameManager>
    {
        [Header("게임 큐브 개수")]
        public int boardCountX;
        public int boardCountY;

        int[,] board = null;

        [SerializeField]
        Transform gameBoard;

        // Use this for initialization
        void Start()
        {
            GenBoard();
        }

        // Update is called once per frame
        void Update()
        {
        }

        

        public void GenBoard()
        {           
            board = new int[boardCountX, boardCountY];

            float colStart = boardCountX / 2;
            float rowStart = boardCountY / 2;

            for (int row = 0; row < boardCountY; row++)
            {
                for (int col = 0; col < boardCountX; col++)
                {
                    ACCube cube = ACCubeManager.Instance.GenRandCube();
                    cube.transform.position = new Vector3(-colStart + col, 0, -rowStart + row);
                    cube.transform.parent = gameBoard.transform;



                }
            }
        }

    }

}