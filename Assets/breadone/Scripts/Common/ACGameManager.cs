using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ACube201810
{
    public class ACGameManager : Singleton<ACGameManager>
    {
        [HideInInspector]
        public ACGameBoard gameBoard;

        [HideInInspector]
        public ACPlayer player;


        // Use this for initialization
        void Start()
        {
            gameBoard = ACGameBoardManager.Instance.CreateGameBoard();
            gameBoard.CreateCubes(ACGameSetting.Instance.boardCount);

            player = ACPlayerManager.Instance.CreatePlayer();
            player.Initialize(gameBoard, ACGameSetting.Instance.playerInitPos);
        }

        // Update is called once per frame
        void Update()
        {
            if (player.Inputable)
            {
                var horizontal = Input.GetAxisRaw("Horizontal");
                var vertical = Input.GetAxisRaw("Vertical");

                if (horizontal == -1)
                {
                    player.MoveLeft();
                }
                else if (horizontal == 1)
                {
                    player.MoveRight();
                }
                else if (vertical == -1)
                {
                    player.MoveForward();
                }
                else if (vertical == 1)
                {
                    player.MoveBackward();
                }

                if(Input.GetKeyDown(KeyCode.Space))
                {
                    player.Attack();
                }
                
            }

        }      


    }

}