using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


namespace ACube201810
{
    public class ACPlayer : MonoBehaviour
    {

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

        // Use this for initialization
        void Start()
        {
            playerMoveSpeed = ACGameSetting.Instance.playerMoveSpeed;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetPosition(Vector2 vPos)
        {
            transform.position = new Vector3(vPos.x, 1.5f, vPos.y);
        }

        public void MoveLeft()
        {
            currentActionState = ActionState.Moving;
            transform.DOMoveX(-1, playerMoveSpeed).SetRelative().OnComplete(()=> {
                currentActionState = ActionState.Stay;
            });            
        }

        public void MoveRight()
        {
            currentActionState = ActionState.Moving;
            transform.DOMoveX(1, playerMoveSpeed).SetRelative().OnComplete(() => {
                currentActionState = ActionState.Stay;
            });
        }

        public void MoveForward()
        {
            currentActionState = ActionState.Moving;
            transform.DOMoveZ(-1, playerMoveSpeed).SetRelative().OnComplete(() => {
                currentActionState = ActionState.Stay;
            });
        }

        public void MoveBackward()
        {
            currentActionState = ActionState.Moving;
            transform.DOMoveZ(1, playerMoveSpeed).SetRelative().OnComplete(() => {
                currentActionState = ActionState.Stay;
            });
        }


    } 
}
