Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid


Namespace DXSample
	Partial Public Class Main
		Inherits XtraForm
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub OnFormLoad(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' TODO: This line of code loads data into the 'nwindDataSet.Customers' table. You can move, or remove it, as needed.
			Me.customersTableAdapter.Fill(Me.nwindDataSet.Customers)
		End Sub

		Private Sub OnCustomDrawCell(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles gridView1.CustomDrawCell
			Dim view As GridView = TryCast(sender, GridView)
			If view.OptionsFind.HighlightFindResults AndAlso (Not view.FindFilterText.Equals(String.Empty)) Then
				Dim index As Integer = e.DisplayText.ToLower().IndexOf(view.FindFilterText)
				If index = -1 Then
					Return
				End If
				e.Appearance.FillRectangle(e.Cache, e.Bounds)
				e.Cache.Paint.DrawMultiColorString(e.Cache, e.Bounds, e.DisplayText, view.FindFilterText, e.Appearance, Color.Indigo, Color.LightSlateGray, True, index)
				e.Handled = True
			End If
		End Sub
	End Class
End Namespace
