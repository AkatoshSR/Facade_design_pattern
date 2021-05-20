using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFactory : BaseFactory
{
    public UIFactory()
    {
        // 修改基类的资源加载路径
        loadPath += StringManager.UILoadPath;
    }
}
