using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Columns : MonoBehaviour
{
        
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<Bird>() != null)
        {
            GameController.instance.BirdScored();
        }
    }
}
