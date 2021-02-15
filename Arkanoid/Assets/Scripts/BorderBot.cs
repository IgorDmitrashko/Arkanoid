using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BorderBot : MonoBehaviour
{
   public  UnityEvent LostCountEvent;

    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision) {
        LostCountEvent?.Invoke();
    }

    void Update()
    {
        
    }
}
