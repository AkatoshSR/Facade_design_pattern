using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFactory : BaseFactory
{
    public GameFactory()
    {
        // 修改基类的资源加载路径
        loadPath += StringManager.GameLoadPath;
    }
}
