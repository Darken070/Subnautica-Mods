using System;
using Utilites.Logger;

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
