using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XApp1
{
    public abstract class FileList
    {
        public static FileList Current
        {
            get;
            set;
        }
        public abstract List<String> GetFileList(string dir, string filter);
    }
}
