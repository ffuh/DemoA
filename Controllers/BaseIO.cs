using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;


namespace DemoA.Controllers
{
    public class BaseIO:Controller
    {
        IWebHostEnvironment _Env;


        public BaseIO(IWebHostEnvironment _env) { _Env = _env; }

        public string DataRootPath { get { return $"{_Env.WebRootPath}\\DATA\\"; } }
        public string AppRootPath { get { return $"{_Env.ContentRootPath}\\DATA\\"; } }


        public string ReadDataFile(string _file)
        {
            string _lines = "";

            string _path = $"{DataRootPath}\\{_file}";

            if(System.IO.File.Exists(_path))
                return System.IO.File.ReadAllText(_path);
            else
                return _lines;
        }
        public IEnumerable<string>  EnumDataFolder(string _path)
        {
            string _full = $"{DataRootPath}\\{_path}";

            if (System.IO.Directory.Exists(_full))           
                return   System.IO.Directory.EnumerateDirectories(_full);
            else
                return null;
        }
    }
}