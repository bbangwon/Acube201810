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

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(currentActionState == ActionState.Stay)
            {
                var horizontal = Input.GetAxisRaw("Horizontal");
                var vertical = Input.GetAxisRaw("Vertical");

                if(horizontal == -1)
                {
                    MoveLeft();  
                }
                else if(horizontal == 1)
                {
                    MoveRight();
                }
                else if(vertical == -1)
                {
                    MoveForward();
                }
                else if(vertical == 1)
                {
                    MoveBackward();
                }
            }
        }

        public void MoveLeft()
        {
            currentActionState = ActionState.Moving;

            transform.DOMoveX(-1, 1).SetRelative().OnComplete(()=> {
                currentActionState = ActionState.Stay;
            });
            
        }

        public void MoveRight()
        {
            currentActionState = ActionState.Moving;
            transform.DOMoveX(1, 1).SetRelative().OnComplete(() => {
                currentActionState = ActionState.Stay;
            });
        }

        public void MoveForward()
        {
            currentActionState = ActionState.Moving;
            transform.DOMoveZ(-1, 1).SetRelative().OnComplete(() => {
                currentActionState = ActionState.Stay;
            });
        }

        public void MoveBackward()
        {
            currentActionState = ActionState.Moving;
            transform.DOMoveZ(1, 1).SetRelative().OnComplete(() => {
                currentActionState = ActionState.Stay;
            });
        }


    } 
}
