using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lottery : MonoBehaviour
{
    /// <summary>
    /// おみくじの種類
    /// </summary>
    public enum LotteryType {
        大吉,
        中吉,
        小吉,
        末吉,
        凶,
        大凶,
        Count
    }

    [Header("おみくじの種類の設定")]
    public LotteryType lotteryType;
}
