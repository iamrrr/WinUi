using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageViewer
{
    public class ImagesRepo
    {
        public ObservableCollection<ImageInfo> Images { get; } = new();

        public void GetImages(string folderPath)
        {
            Images?.Clear();
            DirectoryInfo di = new DirectoryInfo(folderPath);
            var files = di.GetFiles("*.jpg");

            foreach(var file in files)
            {
                Images.Add(new ImageInfo(file.Name, file.FullName));
            }
        }
    }
}
