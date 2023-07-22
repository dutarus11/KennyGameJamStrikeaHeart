using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
   This script manages the winning scene  
*/
public class WinScene : Timer
{


    void Start()
    {
        StartingTime();

    }

    
    void Update()
    {
        UpdatingWinSceneTime();
    }

    
}
