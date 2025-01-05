using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramerateCap : MonoBehaviour
{
    [SerializeField] private int targetFrameRate = 60;

    void Start()
    {
        Application.targetFrameRate = targetFrameRate;
    }
}