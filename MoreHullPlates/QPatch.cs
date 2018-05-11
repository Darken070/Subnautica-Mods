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
                Items.Load.Existing.All();
                Items.Load.Custom.AlexejheroYTB();
                Items.Load.Custom.AHK1221();
                Items.Load.Custom.Camp_s_Older_Brother();
                Items.Load.Custom.Cougarific();
                Items.Load.Custom.RandyKnapp();
                Items.Load.Custom.Vlad_00003();
                Items.Load.Custom.yenzgaming();
            }
            catch (Exception e)
            {
                e.Log();
            }
        }
    }
}
