
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustScale : MonoBehaviour
{
    public Vector3 newScale = new Vector3(0.5f, 0.5f, 0.5f);

    void Start()
    {
        transform.localScale = newScale;
    }
}

