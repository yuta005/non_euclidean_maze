﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timer : MonoBehaviour {

  float countTime = 0;
    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
    countTime += Time.deltaTime; //スタートしてからの秒数を格納
    GetComponent<Text>().text = countTime.ToString("F2"); //小数2桁にして表示
    }
}
