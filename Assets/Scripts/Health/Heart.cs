using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameControlScript.health += 1;
        Debug.Log(collision.gameObject.name);
    }
}