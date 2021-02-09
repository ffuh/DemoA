using DemoA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NL;
using NL.CCOMM;
using System.Collections.Generic;

namespace DemoA.Controllers
{
    public class LevelController : Controller
    {
        static Dictionary<string, NLIni> _LevelS = new Dictionary<string, NLIni>();




        public static void INIT()
        {
            _LevelS.Clear();
            IEnumerable<string> _folders= CComm.EnumDataFolder("Data\\Level");

            if(_folders!=null)
            {
                foreach(var f in _folders)
                {
                    string _id = CComm.FolderNameOf(f).ToLower();

                    string _text = CComm.ReadDataFile($"{f}\\.info");
                    NLIni  _info = new NLIni(_text, '\n');
                    _info["id"] = _id;

                    _text = CComm.ReadDataFile($"{f}\\round.info");
                    _info["round"] = NL.Web.NWBase64.Base64Encrypt(_text);

                    _text = CComm.ReadDataFile($"{f}\\army.info");
                    _info["army"] = NL.Web.NWBase64.Base64Encrypt(_text);

                    if(!_LevelS.ContainsKey(_id))
                        _LevelS.Add(_id, _info);
                }
            }

        }
        
        private readonly ILogger<LevelController> _Loger;

        public LevelController(ILogger<LevelController> logger)
        {
            _Loger = logger;
        }



        public IActionResult Index()
        {
            
            return View();
        }
        public    string List()
        {
            return "";     
        }

        public string Of(string _id)
        {
            _id = _id.ToLower();
            if (_LevelS.ContainsKey(_id))
                return _LevelS[_id].ToString();
            else
                return "";
        }


    }
}