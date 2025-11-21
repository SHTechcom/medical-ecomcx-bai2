using System.Collections.Generic;
using Bai11;
using Frank;
using UnityEngine;

public class GameViewManager : Singleton<GameViewManager>
{
    [SerializeField] private List<BaseView> views = new List<BaseView>();
}
