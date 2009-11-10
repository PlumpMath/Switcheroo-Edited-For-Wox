﻿/*
 * Switcheroo - The incremental-search task switcher for Windows.
 * http://bitbucket.org/jasulak/switcheroo/
 * Copyright 2009 James Sulak
 * 
 * Switcheroo is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * Switcheroo is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with Switcheroo.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Switcheroo
{

    /// <summary>
    /// This class is a wrapper around the Win32 api window handles
    /// </summary>
    public class AppWindow : ManagedWinapi.Windows.SystemWindow
    {
        private const UInt32 WM_CLOSE = 0x0010;
        
        public AppWindow(IntPtr HWnd) : base(HWnd) { }


        /// <summary>
        /// Post a message to this window that it should close. This is equivalent
        /// to clicking the "X" in the upper right corner or pressing Alt+F4.
        /// It sometimes works in instances where SendClose() does not 
        /// (for example, in Windows Explorer windows.)
        /// </summary>
        public void PostClose() 
        {
            PostMessage(this.HWnd, WM_CLOSE, 0, 0);        
        }


        /// <summary>
        /// Sets the focus to this window and brings it to the foreground.
        /// </summary>
        public void SwitchTo()
        {
            // This function is deprecated, so should probably be replaced.
            SwitchToThisWindow(this.HWnd);
            //ShowWindow(this.HWnd, 1);
            //SetForegroundWindow(this.HWnd);            
        }

        [DllImport("user32.Dll")]
        private static extern int PostMessage(IntPtr hWnd, UInt32 msg, int wParam, int lParam);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SwitchToThisWindow(IntPtr hWnd);

        //[DllImport("user32.dll")]
        //private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        //[DllImport("user32.dll")]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //private static extern bool SetForegroundWindow(IntPtr hWnd);

    }
}
