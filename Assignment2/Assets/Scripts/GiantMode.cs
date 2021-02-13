using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GiantMode : MonoBehaviour
{
    public static bool giant;
    public void Toggle_Changed(bool newValue)
    {
        giant = newValue;
    }

}
