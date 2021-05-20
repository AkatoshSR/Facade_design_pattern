using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceManager
{
    public void StartAudioSource(AudioClip ac)
    {
        Debug.Log("音频资源" + ac.name +"加载成功");
    }

    public void EndAudioSource(AudioClip ac)
    {
        Debug.Log("音频资源" + ac.name + "删除成功");
    }

    public void RuntimeAction(AudioClip ac)
    {
        // 运行时的处理
    }

}
