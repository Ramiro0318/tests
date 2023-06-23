using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pruebas
{
    public class Jump_0 : MonoBehaviour
    {
        int num1 = 0, num2 = 0;
        private void Update()
        {
            Debug.Log($"TilesetFloor_{num1}_{num2}");
            num1++;
            num2++;
        }


    }
}
