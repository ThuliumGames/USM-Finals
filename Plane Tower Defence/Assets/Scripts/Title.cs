using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{

    public void Update()
    {
        if (SSInput.A[0] == "Pressed")
        {
            Application.LoadLevel("Tutorial");
        }
    }
}
