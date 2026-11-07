using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFall : MonoBehaviour
{
    private void Update()
    {
        if (gameObject.transform.position.y <= -10)
        {
            gameObject.transform.position = new Vector3(0f, 1.17f, 0f);
        }
    }
}
