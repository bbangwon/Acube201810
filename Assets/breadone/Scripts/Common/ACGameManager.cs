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
            gameBoard = ACGameBoardManager.Instance.CreateGameBoard(ACGameSetting.Instance.boardCountX, ACGameSetting.Instance.boardCountY);
            gameBoard.CreateCubes(ACGameSetting.Instance.boardCountX, ACGameSetting.Instance.boardCountY);

            player = ACPlayerManager.Instance.CreatePlayer();
            var playerInitPos = gameBoard.PositionToVector2(ACGameSetting.Instance.playerInitPosX, ACGameSetting.Instance.playerInitPosY);
            player.SetPosition(playerInitPos);
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
            }

        }      


    }

}