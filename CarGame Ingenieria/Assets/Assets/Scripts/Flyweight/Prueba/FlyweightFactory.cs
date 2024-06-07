using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlyweightFactory
{
    private Dictionary<AbejaData, IAbejaFlyweight> flyweights = new Dictionary<AbejaData, IAbejaFlyweight>();

    public IAbejaFlyweight GetAbejaFlyweight(AbejaData data)
    {
        if (!flyweights.ContainsKey(data))
        {
            flyweights[data] = new AbejaFlyweight(data);
        }

        return flyweights[data];
    }
}
