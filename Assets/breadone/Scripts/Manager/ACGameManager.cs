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

        ACCube[,] board = null;

        [SerializeField]
        Transform gameBoard;

        [SerializeField]
        ACPlayer player;

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
            board = new ACCube[boardCountX, boardCountY];

            float colStart = boardCountX / 2.0f - 0.5f;
            float rowStart = boardCountY / 2.0f - 0.5f;

            for (int row = 0; row < boardCountY; row++)
            {
                for (int col = 0; col < boardCountX; col++)
                {
                    ACCube cube = ACCubeManager.Instance.GenRandCube();
                    cube.transform.position = new Vector3(-colStart + col, 0, -rowStart + row);
                    cube.transform.parent = gameBoard.transform;

                    board[col, row] = cube;
                }
            }
        }

    }

}