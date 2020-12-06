using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    private static int Selected_Stage = 0;
    private static float Volume = 1;
    public static void Set_SelectedStage(int value)
    {
        Selected_Stage = value;
    }

    public static int Get_SelectedStage()
    {
        return Selected_Stage;
    }

    public static void Set_Volume(float value)
    {
        Volume = value;
    }

    public static float Get_Volume()
    {
        return Volume;
    }
}
