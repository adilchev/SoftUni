﻿using System;
using System.Collections.Generic;
using System.Text;
using SIS.MvcFramework;
using SIS.MvcFramework.Services;

namespace ExamWebApp
{
    public class StartUp:IMvcApplication
    {
        public MvcFrameworkSettings Configure()
        {
            return new MvcFrameworkSettings();
        }

        public void ConfigureServices(IServiceCollection collection)
        {
            
        }
    }
}
