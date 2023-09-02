' Developer Express Code Central Example:
' How to change foreground and background colors of a highlighted text corresponding to a search string of Find Panel
' 
' This example illustrates how to customize foreground and background colors of a
' search string highlighted within located records in a grid.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E3260
Imports System
Imports System.Windows.Forms
Imports DevExpress.Skins

Namespace DXSample

    Friend Module Program

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread>
        Sub Main()
            Call SkinManager.EnableFormSkins()
            Call Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Call Application.Run(New Main())
        End Sub
    End Module
End Namespace
