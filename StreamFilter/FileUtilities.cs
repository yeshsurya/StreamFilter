using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamFilter
{
    class FileUtilities
    {
        //Gets the path of the file palced adjacent to the executable
        public static String GetFilePathAdjacentToModule(String fileName)
        {
            String path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            String moduleName = System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.Name;
            String replacedPath = path.Replace(moduleName, fileName);
            return replacedPath;
        }
        //Converts read stream to string
        public static String ConvertStreamToString(String path)
        {
            String fullLine = null;
            using (StreamReader SR = new StreamReader(path))
            {
                string line = SR.ReadLine();
                fullLine = line;
                while (line != null)
                {
                    line = SR.ReadLine();

                    fullLine += line;
                }
            }
            return fullLine;
        }
    }
}
