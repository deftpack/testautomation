﻿using System.Collections.Generic;

namespace DeftPack.TestAutomation.Selenium.PageElements
{
    public interface IElement
    {
        string Id { get; }
        IEnumerable<string> Classes { get; }
        bool IsVisible { get; }
        void Press(char character);
        void Focus();
        void Hover();
    }
}