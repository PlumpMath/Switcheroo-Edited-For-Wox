using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Switcheroo.Core
{
    public interface IWindowText
    {
        string WindowTitle { get; }
        string ProcessTitle { get; }
    }
}