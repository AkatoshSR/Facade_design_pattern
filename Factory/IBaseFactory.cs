using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBaseFactory{

    // 获得GameObject
    GameObject GetItem(string itemName);

    // 将GameObject放入池中
    void PushItem(string itemName, GameObject item);
}
