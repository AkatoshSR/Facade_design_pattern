using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelManager
{
    // UI面板运行时相关方法
    public void StartUIPanel(GameObject obj)
    {
        Debug.Log("UIPanel" + obj.name + "加载成功");
    }

    public void EndUIPanel(GameObject obj)
    {
        Debug.Log("UIPanel" + obj.name +"删除成功");
    }

    public void RuntimeAction(GameObject obj)
    {
        // 运行时的处理
    }

}
