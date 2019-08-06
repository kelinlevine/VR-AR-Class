using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchLevel : MonoBehaviour
{    private void OnTriggerEnter()
    {
        SceneManager.LoadScene(1);
    }
}
