using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
{
    private PlayerInfo playerInfo;

    // 从场景中获取玩家信息
    public PlayerInfo GetPlayerInfo()
    {
        PlayerInfo playerInfo = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>();
        this.playerInfo = playerInfo;
        return playerInfo;
    }

    // 设置玩家信息
    public void setPlayerInfo(string playerInfoName, int info)
    {
        // 设置玩家等级
        if (StringManager.PlayerLevel.Equals(playerInfoName))
        {
            playerInfo.SetLevel(info);
        }
        // 设置玩家金币
        if (StringManager.PlayerCoins.Equals(playerInfoName))
        {
            playerInfo.SetCoins(info);
        }
    }

}
