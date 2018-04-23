' Developer Express Code Central Example:
' How to change foreground and background colors of a highlighted text corresponding to a search string of Find Panel
' 
' This example illustrates how to customize foreground and background colors of a
' search string highlighted within located records in a grid.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E3260


Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports DevExpress.Skins

Namespace DXSample
	Friend NotInheritable Class Program
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		Private Sub New()
		End Sub
		<STAThread> _
		Shared Sub Main()
			SkinManager.EnableFormSkins()
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			Application.Run(New Main())
		End Sub
	End Class
End Namespace