﻿using System;

namespace DeftPack.TestAutomation.Selenium.PageObjects
{
    public class PageNotLoadedException : Exception
    {
        public PageNotLoadedException(Type t) : base(string.Format("Failed to load page: {0}", t.Name))
        { }
    }
}
