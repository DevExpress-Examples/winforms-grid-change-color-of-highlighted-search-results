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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Data.Filtering;
using DevExpress.Data.Helpers;
using System.Collections;
using DevExpress.XtraGrid.Views.Base;
using System.Diagnostics;


namespace DXSample {
    public partial class Main: XtraForm {
        public Main() {
            InitializeComponent();
        }
       
        private void OnFormLoad(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'nwindDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.nwindDataSet.Customers);
        }

        private string GetStringWithoutQuotes(string findText)
        {
            string stringWithoutQuotes = findText.ToLower().Replace("\"", string.Empty);
            return stringWithoutQuotes;
        }
        private int FindSubStringStartPosition(string dispalyText, string findText)
        {
            string stringWithoutQuotes = GetStringWithoutQuotes(findText);
            int index = dispalyText.ToLower().IndexOf(stringWithoutQuotes);
            return index;
        }
        private  bool HiglightSubString(DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e, string findText)
        {
            int index = FindSubStringStartPosition(e.DisplayText, findText);
            if (index == -1)
            {
                return false;
            }

            e.Appearance.FillRectangle(e.Cache, e.Bounds);
            e.Cache.Paint.DrawMultiColorString(e.Cache, e.Bounds, e.DisplayText, GetStringWithoutQuotes(findText),
                e.Appearance, Color.Indigo, Color.LightSlateGray, true, index);
            return true;
        }
        private void OnCustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            GridView view = sender as GridView;
            if(view.OptionsFind.HighlightFindResults && !view.FindFilterText.Equals(string.Empty)){
             CriteriaOperator op =   ConvertFindPanelTextToCriteriaOperator(view.FindFilterText, view,false);
             if (op is GroupOperator)
             {
                 string findText = view.FindFilterText;
                 if (HiglightSubString(e,  findText))
                 e.Handled = true;
             }
             else if (op is FunctionOperator)
             {
                 FunctionOperator func = op as FunctionOperator;
                 CriteriaOperator colNameOperator = func.Operands[0];
                 string colName = colNameOperator.LegacyToString().Replace("[", string.Empty).Replace("]",string.Empty);
                 if (!e.Column.FieldName.StartsWith(colName)) return;

                 CriteriaOperator valueOperator = func.Operands[1];
                 string findText = valueOperator.LegacyToString().ToLower().Replace("'","");
                 if (HiglightSubString(e, findText))
                    e.Handled = true;
             }
              
            }
        }

        public static CriteriaOperator ConvertFindPanelTextToCriteriaOperator(string findPanelText, GridView view, bool applyPrefixes)
        {
            if (!string.IsNullOrEmpty(findPanelText))
            {
                FindSearchParserResults parseResult = new FindSearchParser().Parse(findPanelText, GetFindToColumnsCollection(view));
                if (applyPrefixes)
                    parseResult.AppendColumnFieldPrefixes();

                return DxFtsContainsHelperAlt.Create(parseResult, FilterCondition.Contains, false);
            }
            return null;
        }



        private static ICollection GetFindToColumnsCollection(GridView view)
        {
            System.Reflection.MethodInfo mi = typeof(ColumnView).GetMethod("GetFindToColumnsCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            return mi.Invoke(view, null) as ICollection;
        }

      
    }
}
