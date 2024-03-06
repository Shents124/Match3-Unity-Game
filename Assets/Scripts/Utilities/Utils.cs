using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using URandom = UnityEngine.Random;

public class Utils
{
    public static NormalItem.eNormalType GetRandomNormalType()
    {
        Array values = Enum.GetValues(typeof(NormalItem.eNormalType));
        NormalItem.eNormalType result = (NormalItem.eNormalType)values.GetValue(URandom.Range(0, values.Length));

        return result;
    }

    public static NormalItem.eNormalType GetRandomNormalTypeExcept(NormalItem.eNormalType[] types)
    {
        List<NormalItem.eNormalType> list = Enum.GetValues(typeof(NormalItem.eNormalType)).Cast<NormalItem.eNormalType>().Except(types).ToList();

        int rnd = URandom.Range(0, list.Count);
        NormalItem.eNormalType result = list[rnd];

        return result;
    }

    public static NormalItem.eNormalType GetNormalTypeLeastAmountExcept(Dictionary<NormalItem.eNormalType, int> normalTypeCount, HashSet<NormalItem.eNormalType> types)
    {
        var normalTypeCountExcept = new Dictionary<NormalItem.eNormalType, int>();


        foreach (var entry in normalTypeCount)
        {
            if (types.Contains(entry.Key))
                continue;

            normalTypeCountExcept.Add(entry.Key, entry.Value);
        }

        return normalTypeCountExcept.OrderBy(x => x.Value).FirstOrDefault().Key;
    }
}
