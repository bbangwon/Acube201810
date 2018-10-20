using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ACube201810
{
    public class ACGameSetting : Singleton<ACGameSetting>
    {
        [Header("게임 큐브 개수")]
        public Vector2Int boardCount;

        [Header("플레이어 시작 포지션")]
        public Vector2Int playerInitPos;

        [Header("플레이어 이동 속도(n초당 1 이동)")]
        public float playerMoveSpeed;

    } 
}
