using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PixelPer : MonoBehaviour
{
    [SerializeField] private CanvasScaler canvasScaler;
    [SerializeField] private float refXWindows;
    [SerializeField] private float refYWindows;
    [SerializeField] private float refXMobile;
    [SerializeField] private float refYMobile;
    private void Awake()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor)
            canvasScaler.referenceResolution = new Vector2(refXWindows, refYWindows);
        else
        {
            canvasScaler.referenceResolution = new Vector2(refXMobile, refYMobile);
        }
    }
}
