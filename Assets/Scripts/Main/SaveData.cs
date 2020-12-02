using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    private static int Selected_Stage;
    
    public static void Set_SelectedStage(int value)
    {
        Selected_Stage = value;
    }

    public static int Get_SelectedStage()
    {
        return Selected_Stage;
    }
}
