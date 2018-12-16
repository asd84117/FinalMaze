using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCtrl : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            AudioManager.Instance.StartAudio("A");
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            AudioManager.Instance.StopAudio("A");
        }
    }

}
