using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSingletonObject
{
    //
    protected bool bInited = false;

    public BaseSingletonObject()
    {

    }

    //
	public void Initialize()
    {
        if (bInited == true)
            DeinitInternal();

        InitInternal();
        bInited = true;
	}

    //
    public void Deinitialize()
    {
        DeinitInternal();

        bInited = false;
    }

    //
    protected virtual void InitInternal()
    {

    }

    //
    protected virtual void DeinitInternal()
    {

    }
}
