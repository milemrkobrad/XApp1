using System;

namespace XApp1
{
    public static class ConvertUnixDate
    {
      public static string ConvertOutputDateTime(double unixDateTime)
        {
            // First make a System.DateTime equivalent to the UNIX Epoch.
            DateTime _result = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);

            // Add the number of seconds in UNIX timestamp to be converted.
            _result = _result.AddSeconds(unixDateTime);

            //return _result.ToLocalTime().ToShortDateString() + _result.ToLocalTime().ToShortTimeString();  //metoda "ToShortTimeString()" nije podržana od strane Xamarina
            return _result.ToLocalTime().ToString("dd.MM.yy") + _result.ToLocalTime().ToString("HH:mm");
        }

        public static string ConvertOutputDate(double unixDateTime)
        {
            // First make a System.DateTime equivalent to the UNIX Epoch.
            DateTime _result = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);

            // Add the number of seconds in UNIX timestamp to be converted.
            _result = _result.AddSeconds(unixDateTime);

            return _result.ToLocalTime().ToString("dd.MM.yy");
        }

        public static string ConvertOutputTime(double unixDateTime)
        {
            // First make a System.DateTime equivalent to the UNIX Epoch.
            DateTime _result = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);

            // Add the number of seconds in UNIX timestamp to be converted.
            _result = _result.AddSeconds(unixDateTime);

            //return _result.ToLocalTime().ToShortDateString() + _result.ToLocalTime().ToShortTimeString();  //metoda "ToShortTimeString()" nije podržana od strane Xamarina
            return _result.ToLocalTime().ToString("HH:mm");
        }
    }
}
