using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ACube201810
{
    public class ACGameBoard : MonoBehaviour
    {
        ACCube[,] defaultCubes;
        ACCube[,] defenseCubes;

        float startX = 0f;
        float startY = 0f;

        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }


        public void CreateCubes(int cubeCountX, int cubeCountY)
        {
            defaultCubes = new ACCube[cubeCountX, cubeCountY];
            defenseCubes = new ACCube[cubeCountX, cubeCountY];

            startX = -(cubeCountX / 2.0f - 0.5f);
            startY = -(cubeCountY / 2.0f - 0.5f);

            for (int row = 0; row< cubeCountY; row++)
            {
                for (int col = 0; col< cubeCountX; col++)
                {
                    ACCube cube = ACCubeManager.Instance.CreateRandomCube();
                    cube.transform.position = new Vector3(startX + col, 0, startY + row);
                    cube.transform.parent = transform;

                    defaultCubes[col, row] = cube;
                }
            }
        }

        public Vector2 PositionToVector2(int posIndexX, int posIndexY)
        {
            return new Vector2(startX + posIndexX, startY + posIndexY);
        }
    } 
}
