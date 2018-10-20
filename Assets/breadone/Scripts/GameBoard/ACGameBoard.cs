using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

using DG.Tweening;

namespace ACube201810
{
    public class ACGameBoard : MonoBehaviour
    {
        ACCube[,] defaultCubes;
        ACCube[,] defenseCubes;

        Vector2 start;  // Cube시작
        Vector2Int cubeCount;

        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }

        public bool IsMoveable(Vector2Int intPosition)
        {
            if (intPosition.x < 0 || intPosition.y < 0)
                return false;

            if (intPosition.x > cubeCount.x - 1 || intPosition.y > cubeCount.y - 1)
                return false;

            if (defaultCubes[intPosition.x, intPosition.y] == null)
                return false;

            return true;
        }

        public void CreateCubes(Vector2Int cubeCount)
        {
            this.cubeCount = cubeCount;

            defaultCubes = new ACCube[cubeCount.x, cubeCount.y];
            defenseCubes = new ACCube[cubeCount.x, cubeCount.y];

            start.x = -(cubeCount.x / 2.0f - 0.5f);
            start.y = -(cubeCount.y / 2.0f - 0.5f);

            for (int row = 0; row < cubeCount.y; row++)
            {
                for (int col = 0; col< cubeCount.x; col++)
                {
                    ACCube cube = ACCubeManager.Instance.CreateRandomCube();
                    cube.transform.position = new Vector3(start.x + col, 0, start.y + row);
                    cube.transform.parent = transform;

                    defaultCubes[col, row] = cube;
                }
            }
        }

        public Vector2 IntPositionToVector2(Vector2Int intPostion)
        {
            return start + intPostion;
        }

        public ACCube GetCube(Vector2Int IntPosition)
        {
            if (IntPosition.x < 0 || IntPosition.y < 0)
                return null;

            if (IntPosition.x > cubeCount.x - 1 || IntPosition.y > cubeCount.y - 1)
                return null;


            return defaultCubes[IntPosition.x, IntPosition.y];
        }

        void ChainCube(ref List<Vector2Int> chainList, Vector2Int IntPosition, ACCube.CubeType cubeType)
        {
            ACCube targetCube = GetCube(IntPosition);

            if (targetCube == null)
                return;

            if (targetCube.cubeType != cubeType)
                return;

            if (chainList.Count(c => c == IntPosition) > 0)
                return;

            chainList.Add(IntPosition);
            ChainCube(ref chainList, new Vector2Int(IntPosition.x - 1, IntPosition.y), cubeType);
            ChainCube(ref chainList, new Vector2Int(IntPosition.x + 1, IntPosition.y), cubeType);
            ChainCube(ref chainList, new Vector2Int(IntPosition.x, IntPosition.y - 1), cubeType);
            ChainCube(ref chainList, new Vector2Int(IntPosition.x, IntPosition.y + 1), cubeType);
        }

        public List<Vector2Int> GetChainCube(Vector2Int IntPosition)
        {
            List<Vector2Int> chainList = new List<Vector2Int>();

            ACCube targetCube = GetCube(IntPosition);

            if(targetCube != null)
                ChainCube(ref chainList, IntPosition, targetCube.cubeType);

            // Debug
            ACGameManager.Instance.player.transform.DOMoveY(1f, 0.3f).SetRelative().SetLoops(2, LoopType.Yoyo);
            chainList.ForEach(_ =>
            {
                ACCube cube = GetCube(_);                
                cube.transform.DOMoveY(1f, 0.3f).SetRelative().SetLoops(2, LoopType.Yoyo);

            });
            //~Debug

            return chainList;
        }
    } 
}
