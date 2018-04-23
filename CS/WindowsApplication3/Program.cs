// Developer Express Code Central Example:
// How to change foreground and background colors of a highlighted text corresponding to a search string of Find Panel
// 
// This example illustrates how to customize foreground and background colors of a
// search string highlighted within located records in a grid.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E3260

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Skins;

namespace DXSample {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            SkinManager.EnableFormSkins();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}