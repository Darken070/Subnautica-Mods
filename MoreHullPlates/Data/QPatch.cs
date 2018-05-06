using Harmony;
using SMLHelper;
using SMLHelper.Patchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;
using Utilites.Logger;
using Logger = Utilites.Logger.Logger;
using LogType = Utilites.Logger.LogType;

namespace MoreHullPlates
{
    public class QPatch
    {
        public static void Patch()
        {
            try
            {
                HullPlates.Load._existing();
                HullPlates.Load.AlexejheroYTB();
                HullPlates.Load.AHK1221();
                HullPlates.Load.CampsOlderBrother();
                HullPlates.Load.RandyKnapp();
                HullPlates.Load.yenzgaming();
            }
            catch (Exception e)
            {
                e.Log();
            }
        }
    }
}
