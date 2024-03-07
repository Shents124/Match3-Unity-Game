﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCondition : MonoBehaviour
{
    public event Action ConditionCompleteEvent = delegate { };

    protected Text m_txt;

    protected bool m_conditionCompleted = false;

    public virtual void Setup(float value, Text txt)
    {
        m_conditionCompleted = false;
        m_txt = txt;
    }

    public virtual void Setup(float value, Text txt, GameManager mngr)
    {
        m_conditionCompleted = false;
        m_txt = txt;
    }

    public virtual void Setup(float value, Text txt, BoardController board)
    {
        m_conditionCompleted = false;
        m_txt = txt;
    }

    protected virtual void UpdateText() { }

    protected void OnConditionComplete()
    {
        m_conditionCompleted = true;

        ConditionCompleteEvent?.Invoke();
    }

    protected virtual void OnDestroy()
    {

    }

    public virtual void Clear()
    {
        m_conditionCompleted = true;
        ConditionCompleteEvent = null;
    }
}
