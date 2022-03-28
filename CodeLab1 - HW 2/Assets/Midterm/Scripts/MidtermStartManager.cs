using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MidtermStartManager : MonoBehaviour
{

    /// <summary>
    /// When function is ran (through UI button press) scenmanager loads
    /// stage select scene.
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene("Stage Select");
    }

}
