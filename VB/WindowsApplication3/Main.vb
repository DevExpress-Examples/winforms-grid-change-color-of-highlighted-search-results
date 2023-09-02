' Developer Express Code Central Example:
' How to change foreground and background colors of a highlighted text corresponding to a search string of Find Panel
' 
' This example illustrates how to customize foreground and background colors of a
' search string highlighted within located records in a grid.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E3260
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Data.Filtering
Imports DevExpress.Data.Helpers
Imports System.Collections
Imports DevExpress.XtraGrid.Views.Base
Imports System.Diagnostics

Namespace DXSample

    Public Partial Class Main
        Inherits XtraForm

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub OnFormLoad(ByVal sender As Object, ByVal e As EventArgs)
            ' TODO: This line of code loads data into the 'nwindDataSet.Customers' table. You can move, or remove it, as needed.
            customersTableAdapter.Fill(nwindDataSet.Customers)
        End Sub

        Private Function GetStringWithoutQuotes(ByVal findText As String) As String
            Dim stringWithoutQuotes As String = findText.ToLower().Replace("""", String.Empty)
            Return stringWithoutQuotes
        End Function

        Private Function FindSubStringStartPosition(ByVal dispalyText As String, ByVal findText As String) As Integer
            Dim stringWithoutQuotes As String = GetStringWithoutQuotes(findText)
            Dim index As Integer = dispalyText.ToLower().IndexOf(stringWithoutQuotes)
            Return index
        End Function

        Private Function HiglightSubString(ByVal e As RowCellCustomDrawEventArgs, ByVal findText As String) As Boolean
            Dim index As Integer = FindSubStringStartPosition(e.DisplayText, findText)
            If index = -1 Then
                Return False
            End If

            e.Appearance.FillRectangle(e.Cache, e.Bounds)
            e.Cache.Paint.DrawMultiColorString(e.Cache, e.Bounds, e.DisplayText, GetStringWithoutQuotes(findText), e.Appearance, Color.Indigo, Color.LightSlateGray, True, index)
            Return True
        End Function

        Private Sub OnCustomDrawCell(ByVal sender As Object, ByVal e As RowCellCustomDrawEventArgs)
            Dim view As GridView = TryCast(sender, GridView)
            If view.OptionsFind.HighlightFindResults AndAlso Not view.FindFilterText.Equals(String.Empty) Then
                Dim op As CriteriaOperator = ConvertFindPanelTextToCriteriaOperator(view.FindFilterText, view, False)
                If TypeOf op Is GroupOperator Then
                    Dim findText As String = view.FindFilterText
                    If HiglightSubString(e, findText) Then e.Handled = True
                ElseIf TypeOf op Is FunctionOperator Then
                    Dim func As FunctionOperator = TryCast(op, FunctionOperator)
                    Dim colNameOperator As CriteriaOperator = func.Operands(0)
                    Dim colName As String = colNameOperator.LegacyToString().Replace("[", String.Empty).Replace("]", String.Empty)
                    If Not e.Column.FieldName.StartsWith(colName) Then Return
                    Dim valueOperator As CriteriaOperator = func.Operands(1)
                    Dim findText As String = valueOperator.LegacyToString().ToLower().Replace("'", "")
                    If HiglightSubString(e, findText) Then e.Handled = True
                End If
            End If
        End Sub

        Public Shared Function ConvertFindPanelTextToCriteriaOperator(ByVal findPanelText As String, ByVal view As GridView, ByVal applyPrefixes As Boolean) As CriteriaOperator
            If Not String.IsNullOrEmpty(findPanelText) Then
                Dim parseResult As FindSearchParserResults = New FindSearchParser().Parse(findPanelText, GetFindToColumnsCollection(view))
                If applyPrefixes Then parseResult.AppendColumnFieldPrefixes()
                Return DxFtsContainsHelperAlt.Create(parseResult, FilterCondition.Contains, False)
            End If

            Return Nothing
        End Function

        Private Shared Function GetFindToColumnsCollection(ByVal view As GridView) As ICollection
            Dim mi As Reflection.MethodInfo = GetType(ColumnView).GetMethod("GetFindToColumnsCollection", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
            Return TryCast(mi.Invoke(view, Nothing), ICollection)
        End Function
    End Class
End Namespace
