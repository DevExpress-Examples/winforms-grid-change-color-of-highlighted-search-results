// Developer Express Code Central Example:
// How to change foreground and background colors of a highlighted text corresponding to a search string of Find Panel
// 
// This example illustrates how to customize foreground and background colors of a
// search string highlighted within located records in a grid.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E3260

using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Drawing;


namespace DXSample {
    public partial class Main : XtraForm {
        public Main() {
            InitializeComponent();
        }
        private void OnFormLoad(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'nwindDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.nwindDataSet.Customers);
        }
        private void OnCustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e) {
            GridView view = sender as GridView;
            if (view.OptionsFind.HighlightFindResults && !view.FindFilterText.Equals(string.Empty)) {
                DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo cellInfo = ((DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo)e.Cell);
                if (cellInfo != null && cellInfo.ViewInfo != null && cellInfo.ViewInfo.HasMatchedString) {
                    e.Appearance.FillRectangle(e.Cache, e.Bounds);                     
                    e.Cache.Paint.DrawMultiColorString(e.Cache, e.Bounds, e.DisplayText, cellInfo.ViewInfo.MatchedRanges,
                    e.Appearance, e.Appearance.GetStringFormat(), Color.Indigo, Color.LightSlateGray, true);
                    e.Handled = true;
                }
            }
        }
    }
}
