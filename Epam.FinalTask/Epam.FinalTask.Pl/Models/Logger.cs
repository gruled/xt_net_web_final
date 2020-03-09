﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using log4net.Config;

namespace Epam.FinalTask.Pl.Models
{
    public static class Logger
    {
        private static ILog log = LogManager.GetLogger("Logger");

        public static ILog Log => log;

        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }
    }
}