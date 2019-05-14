' Developer Express Code Central Example:
' How to change foreground and background colors of a highlighted text corresponding to a search string of Find Panel
' 
' This example illustrates how to customize foreground and background colors of a
' search string highlighted within located records in a grid.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E3260


Imports System
Imports System.Drawing
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
            If view.OptionsFind.HighlightFindResults AndAlso Not view.FindFilterText.Equals(String.Empty) Then
                Dim cellInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo = (CType(e.Cell, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo))
                If cellInfo IsNot Nothing AndAlso cellInfo.ViewInfo IsNot Nothing AndAlso cellInfo.ViewInfo.HasMatchedString Then
                    e.Appearance.FillRectangle(e.Cache, e.Bounds)
                    e.Cache.Paint.DrawMultiColorString(e.Cache, e.Bounds, e.DisplayText, cellInfo.ViewInfo.MatchedRanges, e.Appearance, e.Appearance.GetStringFormat(), Color.Indigo, Color.LightSlateGray, True)
                    e.Handled = True
                End If
            End If
        End Sub
    End Class
End Namespace
