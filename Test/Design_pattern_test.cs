using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Design_pattern_test : MonoBehaviour
{
    public Facade facade;

    // Canvas
    public GameObject canvas;

    // GameObject
    public GameObject go1;
    public GameObject go2;
    public GameObject go3;
    public AudioClip ac1;

    // float 
    float go2_a = -375f;
    float go2_b = 275f;

    float go3_a = 380f;
    float go3_b = 275f;

    // GameObject
    public GameObject go_test_01;

    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        facade = new Facade();
    }

    // 初始化

    // 更新
    private void Update()
    {

        // 开始
        // 创建UIPanel、UI、加载音乐，动画
        if (Input.GetKeyDown(KeyCode.A))
        {
            // 加载UI面板
            go1 = facade.GetGameObjectResource(FactoryType.UIPanelFactory, 
                                               StringManager.DefaultPanel);
            FixPosition(go1, canvas, 0, 0, 0);
            // 运行
            facade.StartUIPanel(go1);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {

            // 加载UI组件
            go_test_01 = GameObject.Find("DefaultPanel(Clone)");
            go2 = facade.GetGameObjectResource(FactoryType.UIFactory, "go2");
            FixPosition(go2, go_test_01, go2_a, go2_b, 0);
            go3 = facade.GetGameObjectResource(FactoryType.UIFactory, "go3");
            FixPosition(go3, go_test_01, go3_a, go3_b, 0);

            //加载资源
            ac1 = facade.GetAudioSource(StringManager.MainButton);

            //运行
            facade.StartUI(go2);
            facade.StartUI(go3);
            facade.StartAudioSource(ac1);
        }

        // 获取玩家信息
        if (Input.GetKeyDown(KeyCode.C))
        {
            facade.GetPlayerInfo(StringManager.PlayerCoins);
            facade.GetPlayerInfo(StringManager.PlayerLevel);
        }

        // 结束显示
        if (Input.GetKeyDown(KeyCode.D))
        {
            // 结束相关处理
            facade.EndAudioSource(ac1);
            facade.EndUIPanel(go1);

            // 回收物体
            facade.PushGameObjectToFactory(FactoryType.UIPanelFactory, 
                                           StringManager.GameLoadPanel, go1);
            facade.PushGameObjectToFactory(FactoryType.UIFactory, "go2", go2);
            facade.PushGameObjectToFactory(FactoryType.UIFactory, "go3", go3);


            // 释放资源
            facade.PushAudioSource(StringManager.MainButton, ac1);

        }

    }

    private void FixPosition(GameObject obj, GameObject parent, float a, float b, float c)
    {
        obj.transform.SetParent(parent.transform);
        obj.transform.localPosition = new Vector3(a, b, c);
    }


    

}
