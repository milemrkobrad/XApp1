using System;
using System.Collections.Generic;

namespace XApp1
{
    public class SlideShow
    {
        public string DirPath { get; set; }
        public string ImageTypeFilter { get; set; }
        public int ImageSlideInterval { get; set; }
        string[] ImageFiles { get; set; }
        public int FilePositionNumber { get; set; }


        public SlideShow()
        {
            DirPath = String.Empty;
            ImageTypeFilter = "*.jpg";
            ImageSlideInterval = 3000; //in ms
            FilePositionNumber = 0;
        }

        public void CreateList()
        {
            //ImageFiles = Directory.GetFiles(DirPath, ImageTypeFilter);
            List<string> list = new List<string>();
            //list = FileList.Current.GetFileList(@"mnt/sdcard/Pictures/Screenshots", "*.jpg");
            list = FileList.Current.GetFileList(@"mnt/sdcard/DCIM/100MEDIA/", "*.jpg");
            //list = FileList.Current.GetFileList(@"mnt/sdcard/Download/", "*.jpg");
            ImageFiles = list.ToArray();

        }

        public string GetNextImage()
        {
            string _result = String.Empty;

            if (ImageFiles != null && ImageFiles.Length > 0)
            {
                _result = ImageFiles[FilePositionNumber];

                FilePositionNumber += 1;
                if (ImageFiles.Length <= FilePositionNumber)
                    FilePositionNumber = 0;
            }

            return _result;
        }
    }
}
