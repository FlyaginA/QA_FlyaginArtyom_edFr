﻿using ATframework3demo.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace atFrameWork2.PageObjects
{
    public class PortalHomePage
    {
        public PortalLeftMenu LeftMenu => new PortalLeftMenu();
        public NewsPage NewsPage => new NewsPage();

    }



}
