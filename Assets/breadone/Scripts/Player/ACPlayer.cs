using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


namespace ACube201810
{
    public class ACPlayer : MonoBehaviour
    {

        const float yPos1LvHeight = 1.5f;
        const float yPos2LvHeight = 2.5f;


        public enum ActionState
        {
            Stay,   //대기상태
            Moving  //이동상태
        }

        ActionState currentActionState = ActionState.Stay;

        public bool Inputable   //입력을 받을수 있는 상태인가?
        {
            get { return currentActionState == ActionState.Stay; }
        }

        float playerMoveSpeed = 1f;

        Vector2Int currentPostion;
        ACGameBoard gameBoard;

        // Use this for initialization
        void Start()
        {
            playerMoveSpeed = ACGameSetting.Instance.playerMoveSpeed;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Initialize(ACGameBoard gameBoard, Vector2Int intPosition)
        {            
            this.gameBoard = gameBoard;
            currentPostion = intPosition;

            MoveTo(currentPostion, true);
        }

        void MoveTo(Vector2Int intPosition, bool noDelay = false)
        {
            if(gameBoard.IsMoveable(intPosition))
            {
                Vector2 vPos = gameBoard.IntPositionToVector2(intPosition);
                float yPos = yPos1LvHeight; // 1층일때..
                Vector3 destinationVec = new Vector3(vPos.x, yPos, vPos.y);

                if (noDelay)
                {
                    transform.position = destinationVec;
                    currentPostion = intPosition;
                }
                else
                {
                    currentActionState = ActionState.Moving;
                    transform.DOMove(destinationVec, playerMoveSpeed).OnComplete(() => {
                        currentActionState = ActionState.Stay;
                        currentPostion = intPosition;
                    });
                }
            }
        }

        public void MoveLeft()
        {            
            MoveTo(new Vector2Int(currentPostion.x - 1, currentPostion.y));
        }

        public void MoveRight()
        {
            MoveTo(new Vector2Int(currentPostion.x + 1, currentPostion.y));
        }

        public void MoveForward()
        {
            MoveTo(new Vector2Int(currentPostion.x, currentPostion.y - 1));
        }

        public void MoveBackward()
        {
            MoveTo(new Vector2Int(currentPostion.x, currentPostion.y + 1));
        }

        public void Attack()
        {
            gameBoard.GetChainCube(currentPostion);
        }


    } 
}
