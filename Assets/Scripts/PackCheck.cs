using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arcanoid
{
    public class PackCheck : MonoBehaviour
    {
        void Update()
        {
            if (transform.childCount == 0)
            {
                Manager.win = true;
                Destroy(gameObject);
            }
        }
    }
}