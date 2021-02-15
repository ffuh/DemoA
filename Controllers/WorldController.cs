using Microsoft.AspNetCore.Mvc;
using NL.CCOMM;
using System;
using System.Collections.Generic;
using System.Text;

namespace WS_OneSoldger.Controllers
{
    public class WorldController: Controller
    {
        static NL.NLIni _INFO;
        static NL.NLTable _NODES;
        public static void INIT()
        {
            _INFO= CComm.LoadINIFromFile($"Data\\World\\.info");
            _NODES = CComm.LoadTableFromFile($"Data\\World\\nodes.info");

            _INFO["nodes"] = NL.Web.NWBase64.Base64Encrypt(_NODES.ToString());
        }

        public IActionResult Index()
        {

            return View();
        }
        public string Info()
        {
            if (_INFO == null)
                INIT();

            return _INFO.ToString();
        }
    }
}
