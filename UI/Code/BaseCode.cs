using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.UI;

namespace UI.Code
{
    public class BaseCode : Page
    {
        public string RutaApi
        {
            get { return ConfigurationManager.AppSettings["RutaApi"].ToString(); }
        }
    }
}