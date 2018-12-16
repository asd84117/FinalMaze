using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    public static InterfaceManager Instance;
    UIBase[] allInteraface;
    private void Awake()
    {
        Instance = this;
        allInteraface = GetComponentsInChildren<UIBase>();
    }

    public void InterfaceSetActive(string interfaceName,bool tmpBool)
    {
        for (int i = 0; i < allInteraface.Length; i++)
        {
            GameObject tmpInterface = allInteraface[i].GetControl(interfaceName);
            if (tmpInterface.name== interfaceName)
            {
                Debug.Log(interfaceName);
                tmpInterface.SetActive(tmpBool);
            }
        }
    }


}
