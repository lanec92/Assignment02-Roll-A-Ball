using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickColor : MonoBehaviour
{
    public Dropdown colorDropDown;

    public static int playerColor;

    public void SwitchColor()
    {
        switch (colorDropDown.value)
        {
            default:
                playerColor = 1;
                break;

            case 1:
                playerColor = 1;
                break;

            case 2:
                playerColor = 2;
                break;
            case 3:
                playerColor = 3;
                break;

        }
    }
}
