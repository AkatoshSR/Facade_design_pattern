using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    // 等级
    [SerializeField]
    private int level;

    // 金币
    [SerializeField]
    private int coins;
    // ....

    // 等级金币的Getter、Setter
    public int GetLevel()
    {
        return level;
    }

    public int GetCoins()
    {
        return coins;
    }

    // 修改等级和金币
    public void SetLevel(int info)
    {
        int temp = this.level;
        this.level = info;
        Debug.Log("玩家等级从" + temp + "被修改为" + this.level);
    }

    public void SetCoins(int info)
    {
        int temp = this.coins;
        this.coins = info;
        Debug.Log("玩家金币从" + temp + "被修改为" + this.coins);
    }

}
