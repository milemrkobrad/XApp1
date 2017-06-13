using System;

namespace XApp1
{
    public static class Helper
    {
       public static string MyRound(string value, string unit)
        {
            //string sValue = value.Replace(".", ",");
            double _value = double.Parse(value);
            int __value = (int)Math.Round(_value);
            return __value.ToString() + unit;
        } 
    }
}
