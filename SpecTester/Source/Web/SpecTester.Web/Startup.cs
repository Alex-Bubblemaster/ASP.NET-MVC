﻿using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(SpecTester.Web.Startup))]

namespace SpecTester.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
