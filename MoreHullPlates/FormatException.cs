using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoreHullPlates
{
    public class FormatEx
    {
        public static string FormatException(Exception e)
        {
            if (e == null)
                return string.Empty;
            return $"\"Exception: {e.GetType()}\"\n\tMessage: {e.Message}\n\tStacktrace: {e.StackTrace}\n" +
            FormatException(e.InnerException);
        }
    }
}
