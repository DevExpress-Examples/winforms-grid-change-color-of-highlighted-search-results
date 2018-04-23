using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;


namespace DXSample {
    public partial class Main: XtraForm {
        public Main() {
            InitializeComponent();
        }
       
        private void OnFormLoad(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'nwindDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.nwindDataSet.Customers);
        }

        private void OnCustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            GridView view = sender as GridView;
            if(view.OptionsFind.HighlightFindResults && !view.FindFilterText.Equals(string.Empty)){
                int index = e.DisplayText.ToLower().IndexOf(view.FindFilterText);
                if (index == -1) return;
                e.Appearance.FillRectangle(e.Cache, e.Bounds);
                e.Cache.Paint.DrawMultiColorString(e.Cache, e.Bounds, e.DisplayText, view.FindFilterText,
                    e.Appearance, Color.Indigo, Color.LightSlateGray, true, index);
                e.Handled = true;
            }
        }
    }
}
