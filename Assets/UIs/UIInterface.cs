using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface UIInterface
{
    public abstract bool isInit { get; set; }

    public abstract void Init();
}
