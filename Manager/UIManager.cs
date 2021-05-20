using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 负责管理UI的管理者
/// </summary>
public class UIManager
{
    public void StartUI(GameObject obj)
    {
        Debug.Log("UI" + obj.name + "成功加载");
    }

    public void EndUI(GameObject obj)
    {
        Debug.Log("UI" + obj.name + "成功删除");
    }

    public void RuntimeAction(GameObject obj)
    {
        // 运行时的处理
    }

}
