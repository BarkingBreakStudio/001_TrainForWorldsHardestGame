using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGraphicsSettings : MonoBehaviour
{

    public virtual bool IsFullscreen()
    {
        return Screen.fullScreen;
    }

    public virtual void SetFullscreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }


    public virtual string[] GetQualitySettingNames()
    {
        return QualitySettings.names;
    }

    public virtual int GetQualitySettingLevel()
    {
        return QualitySettings.GetQualityLevel();
    }

    public virtual void SetQualitySettingLevel(int level)
    {
        QualitySettings.SetQualityLevel(level);
    }

}
