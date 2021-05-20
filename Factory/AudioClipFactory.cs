using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 音频资源工厂
/// </summary>
public class AudioClipFactory : IBaseRescrousFactory<AudioClip>
{
    protected Dictionary<string, AudioClip> factoryDict = new Dictionary<string, AudioClip>();
    protected string loadPath;

    public AudioClipFactory()
    {
        loadPath = StringManager.AudioClipsLoadPath;
    }

    public AudioClip GetSingleResources(string resourcePath)
    {
        AudioClip itemGo = null;
        string itemLoadPath = loadPath + resourcePath;
        if (factoryDict.ContainsKey(resourcePath))
        {
            itemGo = factoryDict[resourcePath];
        }
        else
        {
            itemGo = Resources.Load<AudioClip>(itemLoadPath);
            factoryDict.Add(resourcePath, itemGo);
        }
        if (itemGo == null)
        {
            Debug.Log(resourcePath + "的资源获取失败，失败路径为:" + itemLoadPath);
        }
        return itemGo;
    }

    public void PushResources(string name, AudioClip ac)
    {
        Debug.Log("已将资源" + name + "放入栈中");
    }
}
