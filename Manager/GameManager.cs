using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏总管理，负责管理所有的管理者
/// </summary>
public class GameManager : MonoBehaviour
{
    // 其它Manager
    public FactoryManager factoryManager;
    public PlayerManager playerManager;
    public AudioSourceManager audioSourceManager;
    public UIManager uiManager;
    public UIPanelManager uiPanelManager;
    public AnimationManager animationManager;

    // 单例
    //private static GameManager _instance = new GameManager();

    //public static GameManager Instance
    //{
    //    get
    //    {
    //        return _instance;
    //    }
    //}

    //7：当第一个程序运行到这里时，此时会对locker对象“加锁”
    // ·当第二个线程运行该方法时，首先检测locker对象为“加锁”状态，该线程就会挂起等待第一个线程“解锁”
    // ·lock语句运行完之后（即线程运行完之后）会对该对象“解锁”
    // ·双重锁定只需要一句判断就可以了

    // 线程安全
    private static GameManager _instance;                            //2：定义一个私有的静态变量来保持类的实例
    private static readonly object locker = new object();           //3：定义一个标示确保线程同步
    private GameManager() { }                                       //4：定义一个私有的静态构造函数，使外界不能创建该类实例
    public static GameManager Instance()
    {
        if (_instance == null)                                     
        {
            
            lock (locker)
            {
                if (_instance == null)                              
                {
                    _instance = new GameManager();                   
                }
            }
        }
        return _instance;                                        
    }

    // 实例化管理者
    public void Awake()
    {
        _instance = this;
        factoryManager = new FactoryManager();
        uiManager = new UIManager();
        audioSourceManager = new AudioSourceManager();
        playerManager = new PlayerManager();
        uiPanelManager = new UIPanelManager();
        animationManager = new AnimationManager();
    }

    // 获取玩家信息
    public PlayerInfo GetPlayerInfo()
    {
        return playerManager.GetPlayerInfo();
    }

    // 修改玩家信息
    public void SetPlayerInfo(string playerInfoName, int info)
    {
        playerManager.setPlayerInfo(playerInfoName, info);
    }

    // 用于工厂中创建物品
    public GameObject CreateItem(GameObject itemGo)
    {
        GameObject go = Instantiate(itemGo);
        return go;
    }

    //获取图片资源
    public Sprite GetSprite(string resourcePath)
    {
        return factoryManager.spriteFactory.GetSingleResources(resourcePath);
    }

    //获取音频资源
    public AudioClip GetAudioClip(string resourcePath)
    {
        return factoryManager.audioClipFactory.GetSingleResources(resourcePath);
    }

    // 获取动画资源
    public RuntimeAnimatorController GetRunTimeAnimatorController(string resourcePath)
    {
        return factoryManager.runtimeAnimatorControllerFactory.GetSingleResources(resourcePath);
    }

    //获取游戏物体
    public GameObject GetGameObjectResource(FactoryType factoryType, string resourcePath)
    {
        return factoryManager.factoryDict[factoryType].GetItem(resourcePath);
    }
    //将游戏物体放回对象池
    public void PushGameObjectToFactory(FactoryType factoryType, string resourcePath, GameObject itemGo)
    {
        factoryManager.factoryDict[factoryType].PushItem(resourcePath, itemGo);
    }

    // 删除音频资源
    public void PushAudioSource(string name, AudioClip ac)
    {
        factoryManager.audioClipFactory.PushResources(name, ac);
    }

    // 删除动画资源
    public void PushRuntimeAnimatorController(string name, RuntimeAnimatorController rac)
    {
        factoryManager.runtimeAnimatorControllerFactory.PushResources(name, rac);
    }


}
