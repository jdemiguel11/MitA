using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPstats : MonoBehaviour
{
    [SerializeField] Transform bar;

    public void StatePlayer(float current, float maxHP) // Change to float
    {
        float state = current / maxHP;

        // Make sure the state is not negative so that the bar does not go to the left
        if (state < 0f)
        {
            state = 0f;
        }
        // Scale the bar
        bar.transform.localScale = new Vector3(state, 1f, 1f);
    }
}
