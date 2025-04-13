using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockWand : MonoBehaviour
{
    static public bool IsWandOpen;


    public void OpenTheWand()
    {
        IsWandOpen = true;
    }
}
