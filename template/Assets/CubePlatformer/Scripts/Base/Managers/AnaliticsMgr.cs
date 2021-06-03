using CubePlatformer.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

namespace CubePlatformer
{
    public class AnaliticsMgr : BaseManager<AnaliticsMgr>
    {
        const string RESULT_PARAMS = "Result";

        Dictionary<string, object> resultParams = new Dictionary<string, object>();

        public void AddResultParams(string _name, object _obj) 
        {
            resultParams.Add(_name, _obj);
        } 

        public void AddResultAnalitics() 
        {
            AnalyticsEvent.Custom(RESULT_PARAMS, resultParams);
        }
    }
    public static class ParamsNames
    {
        public const string Time = "VictoryTime";
        public const string Level = "Level";
    }

}
