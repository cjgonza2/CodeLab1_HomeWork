using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MidtermStartManager : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("Stage Select");
    }

}
