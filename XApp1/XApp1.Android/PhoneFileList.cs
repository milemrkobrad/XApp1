using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XApp1.Droid
{
    //Andorid Implementation
    public class PhoneFileList : FileList
    {
        public override List<string> GetFileList(string dir, string filter)
        {
            //// Make a reference to a directory.
            //DirectoryInfo di1 = new DirectoryInfo(@"mnt/sdcard/");

            //// Get a reference to each directory in that directory.
            //DirectoryInfo[] diArr = di1.GetDirectories();

            //// Display the names of the directories.
            //foreach (DirectoryInfo dri in diArr)
            //    Console.WriteLine(dri.Name);


            List<string> fileList = new List<string>();
            DirectoryInfo di = new DirectoryInfo(dir);
            foreach (var fi in di.GetFiles(filter))
            {
                fileList.Add(fi.DirectoryName + "/" + fi.Name);
            }
            return fileList;
        }

    }
}
