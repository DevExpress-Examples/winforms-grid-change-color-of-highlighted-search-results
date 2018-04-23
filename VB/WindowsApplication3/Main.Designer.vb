Imports Microsoft.VisualBasic
Imports System
Namespace DXSample
	Partial Public Class Main
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.defaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
			Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
			Me.customersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
			Me.nwindDataSet = New DXSample.nwindDataSet()
			Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.colCustomerID = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colCompanyName = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colContactName = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colContactTitle = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colCity = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colCountry = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.customersTableAdapter = New DXSample.nwindDataSetTableAdapters.CustomersTableAdapter()
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.customersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nwindDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' defaultLookAndFeel1
			' 
			Me.defaultLookAndFeel1.LookAndFeel.SkinName = "Money Twins"
			' 
			' gridControl1
			' 
			Me.gridControl1.DataSource = Me.customersBindingSource
			Me.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.gridControl1.Location = New System.Drawing.Point(0, 0)
			Me.gridControl1.MainView = Me.gridView1
			Me.gridControl1.Name = "gridControl1"
			Me.gridControl1.Size = New System.Drawing.Size(721, 490)
			Me.gridControl1.TabIndex = 0
			Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1})
			' 
			' customersBindingSource
			' 
			Me.customersBindingSource.DataMember = "Customers"
			Me.customersBindingSource.DataSource = Me.nwindDataSet
			' 
			' nwindDataSet
			' 
			Me.nwindDataSet.DataSetName = "nwindDataSet"
			Me.nwindDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
			' 
			' gridView1
			' 
			Me.gridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.colCustomerID, Me.colCompanyName, Me.colContactName, Me.colContactTitle, Me.colCity, Me.colCountry})
			Me.gridView1.GridControl = Me.gridControl1
			Me.gridView1.Name = "gridView1"
			Me.gridView1.OptionsFind.AlwaysVisible = True
'			Me.gridView1.CustomDrawCell += New DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(Me.OnCustomDrawCell);
			' 
			' colCustomerID
			' 
			Me.colCustomerID.FieldName = "CustomerID"
			Me.colCustomerID.Name = "colCustomerID"
			Me.colCustomerID.Visible = True
			Me.colCustomerID.VisibleIndex = 0
			' 
			' colCompanyName
			' 
			Me.colCompanyName.FieldName = "CompanyName"
			Me.colCompanyName.Name = "colCompanyName"
			Me.colCompanyName.Visible = True
			Me.colCompanyName.VisibleIndex = 1
			' 
			' colContactName
			' 
			Me.colContactName.FieldName = "ContactName"
			Me.colContactName.Name = "colContactName"
			Me.colContactName.Visible = True
			Me.colContactName.VisibleIndex = 2
			' 
			' colContactTitle
			' 
			Me.colContactTitle.FieldName = "ContactTitle"
			Me.colContactTitle.Name = "colContactTitle"
			Me.colContactTitle.Visible = True
			Me.colContactTitle.VisibleIndex = 3
			' 
			' colCity
			' 
			Me.colCity.FieldName = "City"
			Me.colCity.Name = "colCity"
			Me.colCity.Visible = True
			Me.colCity.VisibleIndex = 4
			' 
			' colCountry
			' 
			Me.colCountry.FieldName = "Country"
			Me.colCountry.Name = "colCountry"
			Me.colCountry.Visible = True
			Me.colCountry.VisibleIndex = 5
			' 
			' customersTableAdapter
			' 
			Me.customersTableAdapter.ClearBeforeFill = True
			' 
			' Main
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(721, 490)
			Me.Controls.Add(Me.gridControl1)
			Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
			Me.Name = "Main"
			Me.Text = "Form1"
'			Me.Load += New System.EventHandler(Me.OnFormLoad);
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.customersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nwindDataSet, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private defaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
		Private gridControl1 As DevExpress.XtraGrid.GridControl
		Private WithEvents gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
		Private nwindDataSet As nwindDataSet
		Private customersBindingSource As System.Windows.Forms.BindingSource
		Private customersTableAdapter As DXSample.nwindDataSetTableAdapters.CustomersTableAdapter
		Private colCustomerID As DevExpress.XtraGrid.Columns.GridColumn
		Private colCompanyName As DevExpress.XtraGrid.Columns.GridColumn
		Private colContactName As DevExpress.XtraGrid.Columns.GridColumn
		Private colContactTitle As DevExpress.XtraGrid.Columns.GridColumn
		Private colCity As DevExpress.XtraGrid.Columns.GridColumn
		Private colCountry As DevExpress.XtraGrid.Columns.GridColumn
	End Class
End Namespace

