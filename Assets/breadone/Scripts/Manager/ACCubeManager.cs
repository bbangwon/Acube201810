using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


namespace ACube201810
{
    public class ACCubeManager : Singleton<ACCubeManager>
    {        
        public ACCube[] cubePrefabs;

        public ACCube GenRandCube()
        {
            return Instantiate(cubePrefabs.OrderBy(r => Random.value).First());
        }
    }
}

