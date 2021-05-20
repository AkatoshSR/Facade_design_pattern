using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 策略，观察者，装饰者，三个工厂模式，多线程单件模式，命令模式，适配器，迭代器
public class Facade
{
    // 玩家数据
    private PlayerInfo playerInfo;

    // 管理者
    private GameManager mGameManager;
    private UIManager uiManager;
    private UIPanelManager uiPanelManager;
    private AudioSourceManager audioSourceManager;
    private PlayerManager playerManger;
    private AnimationManager animationManager;

    // 获取管理者
    public Facade()
    {
        mGameManager = GameManager.Instance();
        uiManager = GameManager.Instance().uiManager;
        audioSourceManager = GameManager.Instance().audioSourceManager;
        playerManger = GameManager.Instance().playerManager;
        uiPanelManager = GameManager.Instance().uiPanelManager;
        animationManager = GameManager.Instance().animationManager;
    }

    // UI面板管理者相关方法
    public void StartUIPanel(GameObject obj)
    {
        uiPanelManager.StartUIPanel(obj);
        uiPanelManager.RuntimeAction(obj);
    }

    public void EndUIPanel(GameObject obj)
    {
        uiPanelManager.EndUIPanel(obj);
    }

    // UI组件管理者控制相关方法
    public void StartUI(GameObject obj)
    {
        uiManager.StartUI(obj);
        uiManager.RuntimeAction(obj);
    }

    public void EndUI(GameObject obj)
    {
        uiManager.EndUI(obj);
    }

    // 动画管理者相关方法
    public void StartAnimation(RuntimeAnimatorController rac)
    {
        animationManager.StartAnimation(rac);
        animationManager.RuntimeAction(rac);
        GetSprite("EXP_PLAYER");
    }

    public void EndAnimation(RuntimeAnimatorController rac)
    {
        animationManager.EndAniamtion(rac);
    }

    // 音频管理者相关方法
    public void StartAudioSource(AudioClip ac)
    {
        audioSourceManager.StartAudioSource(ac);
        audioSourceManager.RuntimeAction(ac);
    }

    public void EndAudioSource(AudioClip ac)
    {
        audioSourceManager.EndAudioSource(ac);
    }

    // 获取玩家信息
    public int GetPlayerInfo(string flag)
    {
        this.playerInfo = mGameManager.GetPlayerInfo();
        
        
        

        if (StringManager.PlayerLevel.Equals(flag))
        {
            Debug.Log("玩家等级：" + this.playerInfo.GetLevel());
            return this.playerInfo.GetLevel();
            
        }
        if (StringManager.PlayerCoins.Equals(flag))
        {
            Debug.Log("玩家金币：" + this.playerInfo.GetCoins());
            return this.playerInfo.GetCoins();

        }
        return 0;
        
    }

    // 修改玩家信息
    public void SetPlayerInfo(string playerInfoType, int info)
    {
        mGameManager.SetPlayerInfo(playerInfoType, info);
    }

    //获取资源
    public Sprite GetSprite(string resourcePath)
    {
        return mGameManager.GetSprite(resourcePath);
    }

    public AudioClip GetAudioSource(string resourcePath)
    {
        return mGameManager.GetAudioClip(resourcePath);
    }

    public RuntimeAnimatorController GetRuntimeAnimatorController(string resourcePath)
    {
        return mGameManager.GetRunTimeAnimatorController(resourcePath);
    }

    //获取游戏物体
    public GameObject GetGameObjectResource(FactoryType factoryType, string resourcePath)
    {
        return mGameManager.GetGameObjectResource(factoryType, resourcePath);
    }
    //将游戏物体放回对象池
    public void PushGameObjectToFactory(FactoryType factoryType, string resourcePath, GameObject itemGo)
    {
        mGameManager.PushGameObjectToFactory(factoryType, resourcePath, itemGo);
    }

    // 移除音频资源
    public void PushAudioSource(string name, AudioClip ac)
    {
        mGameManager.PushAudioSource(name, ac);
    }

    // 移除动画资源
    public void PushRuntimeAnimatorController(string name, RuntimeAnimatorController rac)
    {
        mGameManager.PushRuntimeAnimatorController(name, rac);
    }

}
