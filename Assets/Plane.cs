using System;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public static event Action Showed;

    public static event Action<string> ShowedText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Showed?.Invoke();

            if (Showed.GetInvocationList().Length > 0) ;
        }
        if (Input.GetKeyDown(KeyCode.F));

    }
}
