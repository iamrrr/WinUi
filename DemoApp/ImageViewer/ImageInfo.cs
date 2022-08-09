using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageViewer
{
    public class ImageInfo
    {
        public string Name { get; }
        public string FullName { get; }

        public ImageInfo(string name, string fullName)
        {
            Name = name;
            FullName = fullName;
        }
    }
}
