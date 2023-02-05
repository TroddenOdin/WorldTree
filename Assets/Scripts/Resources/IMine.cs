using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldTree;

public interface IMine
{

    bool IsIdle();
    void MoveTo(Vector3 position, float stopDistance, Action onArrivedPosition);
    void PlayAnimationMine(Vector3 lookAtPosition, Action onAnimationCompleted);
}
