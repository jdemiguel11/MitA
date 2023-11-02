using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour 
{
    public void TakeDamage (int damage)
    {
        Destroy(gameObject);
    }
}
