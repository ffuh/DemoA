using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NL.CCOMM
{
    public static  class CComm
    {
        public static NLIni LoadINIFromFile(string _filepath, bool  _localpath=true )
        {
            if(_localpath)
                _filepath = Webapp._ENV.WebRootPath + "//" + _filepath;

            string _lines = ReadDataFile(_filepath);

            return new NLIni(_lines, '\n');
        }
        public static NLTable LoadTableFromFile(string _filepath ,bool _localpath = true)
        {
            if (_localpath)
                _filepath = Webapp._ENV.WebRootPath + "//" + _filepath;

            string _lines = ReadDataFile(_filepath);

            return new NLTable(_lines, '\n');
        }
        public static string ReadDataFile(string _filepath)
        {
            if (System.IO.File.Exists(_filepath))
                return System.IO.File.ReadAllText(_filepath);
            else
                return "";
        }
        public static IEnumerable<string> EnumDataFolder(string _path)
        {
            _path = $"{Webapp._ENV.WebRootPath}\\{_path}\\";

            if (System.IO.Directory.Exists(_path))
                return System.IO.Directory.EnumerateDirectories(_path);
            else
                return null;
        }

        public static string FolderNameOf(string _path)
        {

            int ii=_path.LastIndexOf('\\');
            try
            {
                return _path.Substring(ii + 1,Math.Max(0,   _path.Length - ii - 1));
            }
            catch
            {
                return _path;
            }
           
        }
    }
}
