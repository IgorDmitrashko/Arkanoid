using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    void Start() {
        StartCoroutine(Acceleration());
    }

    IEnumerator Acceleration() {
        while(true)
        {
            yield return new WaitForSeconds(10);
            _ball.AddSpeed();
        }
    }
}
