using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager
{
    public void StartAnimation(RuntimeAnimatorController rac)
    {
        Debug.Log("动画" + rac.name + "加载成功");
    }

    public void EndAniamtion(RuntimeAnimatorController rac)
    {
        Debug.Log("动画" + rac.name +"删除成功");
    }

    public void RuntimeAction(RuntimeAnimatorController rac)
    {
        // 运行时的处理
    }

}
