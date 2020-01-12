namespace ReportLibrary
{
    partial class DriverFares_OO
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Telerik.Reporting.InstanceReportSource instanceReportSource1 = new Telerik.Reporting.InstanceReportSource();
            Telerik.Reporting.Group group1 = new Telerik.Reporting.Group();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.GroupFooterArea1 = new Telerik.Reporting.GroupFooterSection();
            this.GroupHeaderArea1 = new Telerik.Reporting.GroupHeaderSection();
            this.sqlDataSource1 = new Telerik.Reporting.SqlDataSource();
            this.ReportHeaderArea1 = new Telerik.Reporting.ReportHeaderSection();
            this.PageHeaderArea1 = new Telerik.Reporting.PageHeaderSection();
            this.PageHeaderSection1 = new Telerik.Reporting.Panel();
            this.PrintDate1 = new Telerik.Reporting.TextBox();
            this.Text13 = new Telerik.Reporting.TextBox();
            this.Text15 = new Telerik.Reporting.TextBox();
            this.PageNofM1 = new Telerik.Reporting.TextBox();
            this.PageHeaderSection2 = new Telerik.Reporting.Panel();
            this.Text12 = new Telerik.Reporting.TextBox();
            this.Text11 = new Telerik.Reporting.TextBox();
            this.Text10 = new Telerik.Reporting.TextBox();
            this.Text9 = new Telerik.Reporting.TextBox();
            this.Text8 = new Telerik.Reporting.TextBox();
            this.Text7 = new Telerik.Reporting.TextBox();
            this.Text6 = new Telerik.Reporting.TextBox();
            this.Text4 = new Telerik.Reporting.TextBox();
            this.Text3 = new Telerik.Reporting.TextBox();
            this.Text2 = new Telerik.Reporting.TextBox();
            this.Text1 = new Telerik.Reporting.TextBox();
            this.Text17 = new Telerik.Reporting.TextBox();
            this.Text14 = new Telerik.Reporting.TextBox();
            this.Text5 = new Telerik.Reporting.TextBox();
            this.Text18 = new Telerik.Reporting.TextBox();
            this.Text19 = new Telerik.Reporting.TextBox();
            this.DetailArea1 = new Telerik.Reporting.DetailSection();
            this.FareNumber1 = new Telerik.Reporting.TextBox();
            this.TripDate1 = new Telerik.Reporting.TextBox();
            this.FareType1 = new Telerik.Reporting.TextBox();
            this.TripStatus1 = new Telerik.Reporting.TextBox();
            this.CCGrossAmount1 = new Telerik.Reporting.TextBox();
            this.CCNetAmount1 = new Telerik.Reporting.TextBox();
            this.VCHFareAmount1 = new Telerik.Reporting.TextBox();
            this.TotalAmount1 = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.panel3 = new Telerik.Reporting.Panel();
            this.panel2 = new Telerik.Reporting.Panel();
            this.GroupNameDriverNumber1 = new Telerik.Reporting.TextBox();
            this.Line13 = new Telerik.Reporting.Shape();
            this.Line10 = new Telerik.Reporting.Shape();
            this.Line11 = new Telerik.Reporting.Shape();
            this.Line12 = new Telerik.Reporting.Shape();
            this.Expr10251 = new Telerik.Reporting.TextBox();
            this.ServiceCharge1 = new Telerik.Reporting.TextBox();
            this.CCAuthCode1 = new Telerik.Reporting.TextBox();
            this.ReportFooterArea1 = new Telerik.Reporting.ReportFooterSection();
            this.ReportFooterSection1 = new Telerik.Reporting.Panel();
            this.SumofTotalAmount1 = new Telerik.Reporting.TextBox();
            this.Text16 = new Telerik.Reporting.TextBox();
            this.Line6 = new Telerik.Reporting.Shape();
            this.SumofVCHFareAmount1 = new Telerik.Reporting.TextBox();
            this.SumofCCGrossAmount1 = new Telerik.Reporting.TextBox();
            this.SumofServiceCharge1 = new Telerik.Reporting.TextBox();
            this.SumofCCNetAmount1 = new Telerik.Reporting.TextBox();
            this.ReportFooterSection2 = new Telerik.Reporting.Panel();
            this.Subreport1 = new Telerik.Reporting.SubReport();
            this.PageFooterArea1 = new Telerik.Reporting.PageFooterSection();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // GroupFooterArea1
            // 
            this.GroupFooterArea1.Height = Telerik.Reporting.Drawing.Unit.Inch(0D);
            this.GroupFooterArea1.KeepTogether = false;
            this.GroupFooterArea1.Name = "GroupFooterArea1";
            this.GroupFooterArea1.PageBreak = Telerik.Reporting.PageBreak.None;
            this.GroupFooterArea1.Style.BackgroundColor = System.Drawing.Color.White;
            this.GroupFooterArea1.Style.Visible = true;
            // 
            // GroupHeaderArea1
            // 
            this.GroupHeaderArea1.Height = Telerik.Reporting.Drawing.Unit.Inch(0D);
            this.GroupHeaderArea1.KeepTogether = false;
            this.GroupHeaderArea1.Name = "GroupHeaderArea1";
            this.GroupHeaderArea1.PageBreak = Telerik.Reporting.PageBreak.None;
            this.GroupHeaderArea1.Style.BackgroundColor = System.Drawing.Color.White;
            this.GroupHeaderArea1.Style.Visible = true;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionString = "ReportLibrary.Properties.Settings.CARSConnectionString";
            this.sqlDataSource1.Name = "sqlDataSource1";
            this.sqlDataSource1.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@DriverNumber", System.Data.DbType.Int32, "30908")});
            this.sqlDataSource1.SelectCommand = "dbo.GetDriverFaresForDriverNumber";
            this.sqlDataSource1.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure;
            // 
            // ReportHeaderArea1
            // 
            this.ReportHeaderArea1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.1527777761220932D);
            this.ReportHeaderArea1.KeepTogether = false;
            this.ReportHeaderArea1.Name = "ReportHeaderArea1";
            this.ReportHeaderArea1.PageBreak = Telerik.Reporting.PageBreak.Before;
            this.ReportHeaderArea1.Style.BackgroundColor = System.Drawing.Color.White;
            this.ReportHeaderArea1.Style.Visible = true;
            // 
            // PageHeaderArea1
            // 
            this.PageHeaderArea1.Height = Telerik.Reporting.Drawing.Unit.Inch(1.0763888359069824D);
            this.PageHeaderArea1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.PageHeaderSection1,
            this.PageHeaderSection2});
            this.PageHeaderArea1.Name = "PageHeaderArea1";
            this.PageHeaderArea1.PrintOnFirstPage = true;
            this.PageHeaderArea1.PrintOnLastPage = true;
            this.PageHeaderArea1.Style.Visible = true;
            // 
            // PageHeaderSection1
            // 
            this.PageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.PrintDate1,
            this.Text13,
            this.Text15,
            this.PageNofM1});
            this.PageHeaderSection1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.PageHeaderSection1.Name = "PageHeaderSection1";
            this.PageHeaderSection1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(8.3000001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.3541666567325592D));
            this.PageHeaderSection1.Style.BackgroundColor = System.Drawing.Color.White;
            this.PageHeaderSection1.Style.Visible = true;
            // 
            // PrintDate1
            // 
            this.PrintDate1.CanGrow = false;
            this.PrintDate1.CanShrink = false;
            this.PrintDate1.Format = "{0:d}";
            this.PrintDate1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.25D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.PrintDate1.Name = "PrintDate1";
            this.PrintDate1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.80833333730697632D), Telerik.Reporting.Drawing.Unit.Inch(0.16527777910232544D));
            this.PrintDate1.Style.BackgroundColor = System.Drawing.Color.White;
            this.PrintDate1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.PrintDate1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.PrintDate1.Style.Color = System.Drawing.Color.Black;
            this.PrintDate1.Style.Font.Bold = true;
            this.PrintDate1.Style.Font.Italic = false;
            this.PrintDate1.Style.Font.Name = "Arial";
            this.PrintDate1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.PrintDate1.Style.Font.Strikeout = false;
            this.PrintDate1.Style.Font.Underline = false;
            this.PrintDate1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.PrintDate1.Style.Visible = true;
            this.PrintDate1.Value = "=Now()";
            // 
            // Text13
            // 
            this.Text13.CanGrow = false;
            this.Text13.CanShrink = false;
            this.Text13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.6666665077209473D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.Text13.Name = "Text13";
            this.Text13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.45763888955116272D), Telerik.Reporting.Drawing.Unit.Inch(0.15347221493721008D));
            this.Text13.Style.BackgroundColor = System.Drawing.Color.White;
            this.Text13.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text13.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Text13.Style.Color = System.Drawing.Color.Black;
            this.Text13.Style.Font.Bold = true;
            this.Text13.Style.Font.Italic = false;
            this.Text13.Style.Font.Name = "Arial";
            this.Text13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text13.Style.Font.Strikeout = false;
            this.Text13.Style.Font.Underline = false;
            this.Text13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.Text13.Style.Visible = true;
            this.Text13.Value = "Date:";
            // 
            // Text15
            // 
            this.Text15.CanGrow = false;
            this.Text15.CanShrink = false;
            this.Text15.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.0486111640930176D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.Text15.Name = "Text15";
            this.Text15.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.9513888359069824D), Telerik.Reporting.Drawing.Unit.Inch(0.34999999403953552D));
            this.Text15.Style.BackgroundColor = System.Drawing.Color.White;
            this.Text15.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text15.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Text15.Style.Color = System.Drawing.Color.Black;
            this.Text15.Style.Font.Bold = true;
            this.Text15.Style.Font.Italic = false;
            this.Text15.Style.Font.Name = "Arial";
            this.Text15.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(20D);
            this.Text15.Style.Font.Strikeout = false;
            this.Text15.Style.Font.Underline = false;
            this.Text15.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.Text15.Style.Visible = true;
            this.Text15.Value = "Fare Summary Report";
            // 
            // PageNofM1
            // 
            this.PageNofM1.CanGrow = false;
            this.PageNofM1.CanShrink = false;
            this.PageNofM1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.8333334922790527D), Telerik.Reporting.Drawing.Unit.Inch(0.1736111044883728D));
            this.PageNofM1.Name = "PageNofM1";
            this.PageNofM1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0833333730697632D), Telerik.Reporting.Drawing.Unit.Inch(0.15347221493721008D));
            this.PageNofM1.Style.BackgroundColor = System.Drawing.Color.White;
            this.PageNofM1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.PageNofM1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.PageNofM1.Style.Color = System.Drawing.Color.Black;
            this.PageNofM1.Style.Font.Bold = true;
            this.PageNofM1.Style.Font.Italic = false;
            this.PageNofM1.Style.Font.Name = "Arial";
            this.PageNofM1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.PageNofM1.Style.Font.Strikeout = false;
            this.PageNofM1.Style.Font.Underline = false;
            this.PageNofM1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.PageNofM1.Style.Visible = true;
            this.PageNofM1.Value = "=\"Page \" + PageNumber + \" of \" + PageCount";
            // 
            // PageHeaderSection2
            // 
            this.PageHeaderSection2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.Text12,
            this.Text11,
            this.Text10,
            this.Text9,
            this.Text8,
            this.Text7,
            this.Text6,
            this.Text4,
            this.Text3,
            this.Text2,
            this.Text1,
            this.Text17,
            this.Text14,
            this.Text5,
            this.Text18,
            this.Text19});
            this.PageHeaderSection2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.3541666567325592D));
            this.PageHeaderSection2.Name = "PageHeaderSection2";
            this.PageHeaderSection2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(8.3000001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.72222220897674561D));
            this.PageHeaderSection2.Style.BackgroundColor = System.Drawing.Color.White;
            this.PageHeaderSection2.Style.Visible = true;
            // 
            // Text12
            // 
            this.Text12.CanGrow = false;
            this.Text12.CanShrink = false;
            this.Text12.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.0833333358168602D));
            this.Text12.Name = "Text12";
            this.Text12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.66666668653488159D), Telerik.Reporting.Drawing.Unit.Inch(0.25D));
            this.Text12.Style.BackgroundColor = System.Drawing.Color.White;
            this.Text12.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text12.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Text12.Style.Color = System.Drawing.Color.Black;
            this.Text12.Style.Font.Bold = true;
            this.Text12.Style.Font.Italic = false;
            this.Text12.Style.Font.Name = "Arial";
            this.Text12.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.Text12.Style.Font.Strikeout = false;
            this.Text12.Style.Font.Underline = false;
            this.Text12.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Text12.Style.Visible = true;
            this.Text12.Value = "Fares:";
            // 
            // Text11
            // 
            this.Text11.CanGrow = false;
            this.Text11.CanShrink = false;
            this.Text11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.25D), Telerik.Reporting.Drawing.Unit.Inch(0.3333333432674408D));
            this.Text11.Name = "Text11";
            this.Text11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.4166666567325592D), Telerik.Reporting.Drawing.Unit.Inch(0.3333333432674408D));
            this.Text11.Style.BackgroundColor = System.Drawing.Color.White;
            this.Text11.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text11.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.Text11.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.Text11.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.Text11.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.Text11.Style.Color = System.Drawing.Color.Black;
            this.Text11.Style.Font.Bold = true;
            this.Text11.Style.Font.Italic = false;
            this.Text11.Style.Font.Name = "Arial";
            this.Text11.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text11.Style.Font.Strikeout = false;
            this.Text11.Style.Font.Underline = false;
            this.Text11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.Text11.Style.Visible = true;
            this.Text11.Value = "Enter Code";
            // 
            // Text10
            // 
            this.Text10.CanGrow = false;
            this.Text10.CanShrink = false;
            this.Text10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.3333333432674408D));
            this.Text10.Name = "Text10";
            this.Text10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.58333331346511841D), Telerik.Reporting.Drawing.Unit.Inch(0.3333333432674408D));
            this.Text10.Style.BackgroundColor = System.Drawing.Color.White;
            this.Text10.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text10.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.Text10.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.Text10.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.Text10.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.Text10.Style.Color = System.Drawing.Color.Black;
            this.Text10.Style.Font.Bold = true;
            this.Text10.Style.Font.Italic = false;
            this.Text10.Style.Font.Name = "Arial";
            this.Text10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text10.Style.Font.Strikeout = false;
            this.Text10.Style.Font.Underline = false;
            this.Text10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.Text10.Style.Visible = true;
            this.Text10.Value = "\nDriver #";
            // 
            // Text9
            // 
            this.Text9.CanGrow = false;
            this.Text9.CanShrink = false;
            this.Text9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.5833334922790527D), Telerik.Reporting.Drawing.Unit.Inch(0.3333333432674408D));
            this.Text9.Name = "Text9";
            this.Text9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.58333331346511841D), Telerik.Reporting.Drawing.Unit.Inch(0.3333333432674408D));
            this.Text9.Style.BackgroundColor = System.Drawing.Color.White;
            this.Text9.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text9.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.Text9.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.Text9.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.Text9.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.Text9.Style.Color = System.Drawing.Color.Black;
            this.Text9.Style.Font.Bold = true;
            this.Text9.Style.Font.Italic = false;
            this.Text9.Style.Font.Name = "Arial";
            this.Text9.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text9.Style.Font.Strikeout = false;
            this.Text9.Style.Font.Underline = false;
            this.Text9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.Text9.Style.Visible = true;
            this.Text9.Value = "Total Amount";
            // 
            // Text8
            // 
            this.Text8.CanGrow = false;
            this.Text8.CanShrink = false;
            this.Text8.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6D), Telerik.Reporting.Drawing.Unit.Inch(0.3333333432674408D));
            this.Text8.Name = "Text8";
            this.Text8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.5D), Telerik.Reporting.Drawing.Unit.Inch(0.3333333432674408D));
            this.Text8.Style.BackgroundColor = System.Drawing.Color.White;
            this.Text8.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text8.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.Text8.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.Text8.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.Text8.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.Text8.Style.Color = System.Drawing.Color.Black;
            this.Text8.Style.Font.Bold = true;
            this.Text8.Style.Font.Italic = false;
            this.Text8.Style.Font.Name = "Arial";
            this.Text8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text8.Style.Font.Strikeout = false;
            this.Text8.Style.Font.Underline = false;
            this.Text8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.Text8.Style.Visible = true;
            this.Text8.Value = "Vch Fare";
            // 
            // Text7
            // 
            this.Text7.CanGrow = false;
            this.Text7.CanShrink = false;
            this.Text7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.3333334922790527D), Telerik.Reporting.Drawing.Unit.Inch(0.3333333432674408D));
            this.Text7.Name = "Text7";
            this.Text7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.58333331346511841D), Telerik.Reporting.Drawing.Unit.Inch(0.3333333432674408D));
            this.Text7.Style.BackgroundColor = System.Drawing.Color.White;
            this.Text7.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text7.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.Text7.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.Text7.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.Text7.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.Text7.Style.Color = System.Drawing.Color.Black;
            this.Text7.Style.Font.Bold = true;
            this.Text7.Style.Font.Italic = false;
            this.Text7.Style.Font.Name = "Arial";
            this.Text7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text7.Style.Font.Strikeout = false;
            this.Text7.Style.Font.Underline = false;
            this.Text7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.Text7.Style.Visible = true;
            this.Text7.Value = "95% CC  Fare";
            // 
            // Text6
            // 
            this.Text6.CanGrow = false;
            this.Text6.CanShrink = false;
            this.Text6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.8333334922790527D), Telerik.Reporting.Drawing.Unit.Inch(0.3333333432674408D));
            this.Text6.Name = "Text6";
            this.Text6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.5D), Telerik.Reporting.Drawing.Unit.Inch(0.3333333432674408D));
            this.Text6.Style.BackgroundColor = System.Drawing.Color.White;
            this.Text6.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text6.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.Text6.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.Text6.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.Text6.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.Text6.Style.Color = System.Drawing.Color.Black;
            this.Text6.Style.Font.Bold = true;
            this.Text6.Style.Font.Italic = false;
            this.Text6.Style.Font.Name = "Arial";
            this.Text6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text6.Style.Font.Strikeout = false;
            this.Text6.Style.Font.Underline = false;
            this.Text6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.Text6.Style.Visible = true;
            this.Text6.Value = "CC Fare";
            // 
            // Text4
            // 
            this.Text4.CanGrow = false;
            this.Text4.CanShrink = false;
            this.Text4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.5D), Telerik.Reporting.Drawing.Unit.Inch(0.3333333432674408D));
            this.Text4.Name = "Text4";
            this.Text4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.66666668653488159D), Telerik.Reporting.Drawing.Unit.Inch(0.3333333432674408D));
            this.Text4.Style.BackgroundColor = System.Drawing.Color.White;
            this.Text4.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text4.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.Text4.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.Text4.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.Text4.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.Text4.Style.Color = System.Drawing.Color.Black;
            this.Text4.Style.Font.Bold = true;
            this.Text4.Style.Font.Italic = false;
            this.Text4.Style.Font.Name = "Arial";
            this.Text4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text4.Style.Font.Strikeout = false;
            this.Text4.Style.Font.Underline = false;
            this.Text4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.Text4.Style.Visible = true;
            this.Text4.Value = "Trip Status";
            // 
            // Text3
            // 
            this.Text3.CanGrow = false;
            this.Text3.CanShrink = false;
            this.Text3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.9166666269302368D), Telerik.Reporting.Drawing.Unit.Inch(0.3333333432674408D));
            this.Text3.Name = "Text3";
            this.Text3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.5D), Telerik.Reporting.Drawing.Unit.Inch(0.3333333432674408D));
            this.Text3.Style.BackgroundColor = System.Drawing.Color.White;
            this.Text3.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text3.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.Text3.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.Text3.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.Text3.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.Text3.Style.Color = System.Drawing.Color.Black;
            this.Text3.Style.Font.Bold = true;
            this.Text3.Style.Font.Italic = false;
            this.Text3.Style.Font.Name = "Arial";
            this.Text3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text3.Style.Font.Strikeout = false;
            this.Text3.Style.Font.Underline = false;
            this.Text3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.Text3.Style.Visible = true;
            this.Text3.Value = "Fare Type";
            // 
            // Text2
            // 
            this.Text2.CanGrow = false;
            this.Text2.CanShrink = false;
            this.Text2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.25D), Telerik.Reporting.Drawing.Unit.Inch(0.3333333432674408D));
            this.Text2.Name = "Text2";
            this.Text2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.58333331346511841D), Telerik.Reporting.Drawing.Unit.Inch(0.3333333432674408D));
            this.Text2.Style.BackgroundColor = System.Drawing.Color.White;
            this.Text2.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text2.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.Text2.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.Text2.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.Text2.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.Text2.Style.Color = System.Drawing.Color.Black;
            this.Text2.Style.Font.Bold = true;
            this.Text2.Style.Font.Italic = false;
            this.Text2.Style.Font.Name = "Arial";
            this.Text2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text2.Style.Font.Strikeout = false;
            this.Text2.Style.Font.Underline = false;
            this.Text2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.Text2.Style.Visible = true;
            this.Text2.Value = "Trip Date";
            // 
            // Text1
            // 
            this.Text1.CanGrow = false;
            this.Text1.CanShrink = false;
            this.Text1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.66666668653488159D), Telerik.Reporting.Drawing.Unit.Inch(0.3333333432674408D));
            this.Text1.Name = "Text1";
            this.Text1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.5D), Telerik.Reporting.Drawing.Unit.Inch(0.3333333432674408D));
            this.Text1.Style.BackgroundColor = System.Drawing.Color.White;
            this.Text1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text1.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.Text1.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.Text1.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.Text1.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.Text1.Style.Color = System.Drawing.Color.Black;
            this.Text1.Style.Font.Bold = true;
            this.Text1.Style.Font.Italic = false;
            this.Text1.Style.Font.Name = "Arial";
            this.Text1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text1.Style.Font.Strikeout = false;
            this.Text1.Style.Font.Underline = false;
            this.Text1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.Text1.Style.Visible = true;
            this.Text1.Value = "\nFare #";
            // 
            // Text17
            // 
            this.Text17.CanGrow = false;
            this.Text17.CanShrink = false;
            this.Text17.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.6666665077209473D), Telerik.Reporting.Drawing.Unit.Inch(0.3333333432674408D));
            this.Text17.Name = "Text17";
            this.Text17.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.4166666567325592D), Telerik.Reporting.Drawing.Unit.Inch(0.3333333432674408D));
            this.Text17.Style.BackgroundColor = System.Drawing.Color.White;
            this.Text17.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text17.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.Text17.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.Text17.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.Text17.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.Text17.Style.Color = System.Drawing.Color.Black;
            this.Text17.Style.Font.Bold = true;
            this.Text17.Style.Font.Italic = false;
            this.Text17.Style.Font.Name = "Arial";
            this.Text17.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text17.Style.Font.Strikeout = false;
            this.Text17.Style.Font.Underline = false;
            this.Text17.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.Text17.Style.Visible = true;
            this.Text17.Value = "Enter Miles";
            // 
            // Text14
            // 
            this.Text14.CanGrow = false;
            this.Text14.CanShrink = false;
            this.Text14.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.25D), Telerik.Reporting.Drawing.Unit.Inch(0.3333333432674408D));
            this.Text14.Name = "Text14";
            this.Text14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.4166666567325592D), Telerik.Reporting.Drawing.Unit.Inch(0.3333333432674408D));
            this.Text14.Style.BackgroundColor = System.Drawing.Color.White;
            this.Text14.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text14.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.Text14.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.Text14.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.Text14.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.Text14.Style.Color = System.Drawing.Color.Black;
            this.Text14.Style.Font.Bold = true;
            this.Text14.Style.Font.Italic = false;
            this.Text14.Style.Font.Name = "Arial";
            this.Text14.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text14.Style.Font.Strikeout = false;
            this.Text14.Style.Font.Underline = false;
            this.Text14.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Text14.Style.Visible = true;
            this.Text14.Value = "\nCC #";
            // 
            // Text5
            // 
            this.Text5.CanGrow = false;
            this.Text5.CanShrink = false;
            this.Text5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.8333334922790527D), Telerik.Reporting.Drawing.Unit.Inch(0.0833333358168602D));
            this.Text5.Name = "Text5";
            this.Text5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.3333332538604736D), Telerik.Reporting.Drawing.Unit.Inch(0.1666666716337204D));
            this.Text5.Style.BackgroundColor = System.Drawing.Color.White;
            this.Text5.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text5.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.Text5.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.Text5.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.Text5.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.Text5.Style.Color = System.Drawing.Color.Black;
            this.Text5.Style.Font.Bold = true;
            this.Text5.Style.Font.Italic = false;
            this.Text5.Style.Font.Name = "Arial";
            this.Text5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text5.Style.Font.Strikeout = false;
            this.Text5.Style.Font.Underline = false;
            this.Text5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.Text5.Style.Visible = true;
            this.Text5.Value = "Payment Amount";
            // 
            // Text18
            // 
            this.Text18.CanGrow = false;
            this.Text18.CanShrink = false;
            this.Text18.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.25D), Telerik.Reporting.Drawing.Unit.Inch(0.3333333432674408D));
            this.Text18.Name = "Text18";
            this.Text18.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.58325451612472534D), Telerik.Reporting.Drawing.Unit.Inch(0.3333333432674408D));
            this.Text18.Style.BackgroundColor = System.Drawing.Color.White;
            this.Text18.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text18.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.Text18.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.Text18.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.Text18.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.Text18.Style.Color = System.Drawing.Color.Black;
            this.Text18.Style.Font.Bold = true;
            this.Text18.Style.Font.Italic = false;
            this.Text18.Style.Font.Name = "Arial";
            this.Text18.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text18.Style.Font.Strikeout = false;
            this.Text18.Style.Font.Underline = false;
            this.Text18.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.Text18.Style.Visible = true;
            this.Text18.Value = "ServiceCharge";
            // 
            // Text19
            // 
            this.Text19.CanGrow = false;
            this.Text19.CanShrink = false;
            this.Text19.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.6666667461395264D), Telerik.Reporting.Drawing.Unit.Inch(0.3333333432674408D));
            this.Text19.Name = "Text19";
            this.Text19.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.5D), Telerik.Reporting.Drawing.Unit.Inch(0.3333333432674408D));
            this.Text19.Style.BackgroundColor = System.Drawing.Color.White;
            this.Text19.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text19.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.Text19.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.Text19.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.Text19.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.Text19.Style.Color = System.Drawing.Color.Black;
            this.Text19.Style.Font.Bold = true;
            this.Text19.Style.Font.Italic = false;
            this.Text19.Style.Font.Name = "Arial";
            this.Text19.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text19.Style.Font.Strikeout = false;
            this.Text19.Style.Font.Underline = false;
            this.Text19.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.Text19.Style.Visible = true;
            this.Text19.Value = "Auth Code";
            // 
            // DetailArea1
            // 
            this.DetailArea1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.24644897878170013D);
            this.DetailArea1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.FareNumber1,
            this.TripDate1,
            this.FareType1,
            this.TripStatus1,
            this.CCGrossAmount1,
            this.CCNetAmount1,
            this.VCHFareAmount1,
            this.TotalAmount1,
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.textBox4,
            this.panel3,
            this.panel2});
            this.DetailArea1.KeepTogether = false;
            this.DetailArea1.Name = "DetailArea1";
            this.DetailArea1.PageBreak = Telerik.Reporting.PageBreak.None;
            this.DetailArea1.Style.BackgroundColor = System.Drawing.Color.White;
            this.DetailArea1.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.DetailArea1.Style.Visible = true;
            // 
            // FareNumber1
            // 
            this.FareNumber1.CanGrow = false;
            this.FareNumber1.CanShrink = false;
            this.FareNumber1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.66666668653488159D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.FareNumber1.Name = "FareNumber1";
            this.FareNumber1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.5D), Telerik.Reporting.Drawing.Unit.Inch(0.15347221493721008D));
            this.FareNumber1.Style.BackgroundColor = System.Drawing.Color.White;
            this.FareNumber1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.FareNumber1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.FareNumber1.Style.Color = System.Drawing.Color.Black;
            this.FareNumber1.Style.Font.Bold = false;
            this.FareNumber1.Style.Font.Italic = false;
            this.FareNumber1.Style.Font.Name = "Arial";
            this.FareNumber1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.FareNumber1.Style.Font.Strikeout = false;
            this.FareNumber1.Style.Font.Underline = false;
            this.FareNumber1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.FareNumber1.Style.Visible = true;
            this.FareNumber1.Value = "= Fields.FareNumber";
            // 
            // TripDate1
            // 
            this.TripDate1.CanGrow = false;
            this.TripDate1.CanShrink = false;
            this.TripDate1.Format = "{0:MM/dd/yy}";
            this.TripDate1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.25D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.TripDate1.Name = "TripDate1";
            this.TripDate1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.66658782958984375D), Telerik.Reporting.Drawing.Unit.Inch(0.15347221493721008D));
            this.TripDate1.Style.BackgroundColor = System.Drawing.Color.White;
            this.TripDate1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.TripDate1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.TripDate1.Style.Color = System.Drawing.Color.Black;
            this.TripDate1.Style.Font.Bold = false;
            this.TripDate1.Style.Font.Italic = false;
            this.TripDate1.Style.Font.Name = "Arial";
            this.TripDate1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.TripDate1.Style.Font.Strikeout = false;
            this.TripDate1.Style.Font.Underline = false;
            this.TripDate1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.TripDate1.Style.Visible = true;
            this.TripDate1.Value = "= Fields.TripDate";
            // 
            // FareType1
            // 
            this.FareType1.CanGrow = false;
            this.FareType1.CanShrink = false;
            this.FareType1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.9166666269302368D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.FareType1.Name = "FareType1";
            this.FareType1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.5D), Telerik.Reporting.Drawing.Unit.Inch(0.15347221493721008D));
            this.FareType1.Style.BackgroundColor = System.Drawing.Color.White;
            this.FareType1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.FareType1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.FareType1.Style.Color = System.Drawing.Color.Black;
            this.FareType1.Style.Font.Bold = false;
            this.FareType1.Style.Font.Italic = false;
            this.FareType1.Style.Font.Name = "Arial";
            this.FareType1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.FareType1.Style.Font.Strikeout = false;
            this.FareType1.Style.Font.Underline = false;
            this.FareType1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.FareType1.Style.Visible = true;
            this.FareType1.Value = "=Fields.[FareType]";
            // 
            // TripStatus1
            // 
            this.TripStatus1.CanGrow = false;
            this.TripStatus1.CanShrink = false;
            this.TripStatus1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.5D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.TripStatus1.Name = "TripStatus1";
            this.TripStatus1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.79992139339447021D), Telerik.Reporting.Drawing.Unit.Inch(0.15347221493721008D));
            this.TripStatus1.Style.BackgroundColor = System.Drawing.Color.White;
            this.TripStatus1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.TripStatus1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.TripStatus1.Style.Color = System.Drawing.Color.Black;
            this.TripStatus1.Style.Font.Bold = false;
            this.TripStatus1.Style.Font.Italic = false;
            this.TripStatus1.Style.Font.Name = "Arial";
            this.TripStatus1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.TripStatus1.Style.Font.Strikeout = false;
            this.TripStatus1.Style.Font.Underline = false;
            this.TripStatus1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.TripStatus1.Style.Visible = true;
            this.TripStatus1.Value = "= Fields.TripStatus";
            // 
            // CCGrossAmount1
            // 
            this.CCGrossAmount1.CanGrow = false;
            this.CCGrossAmount1.CanShrink = false;
            this.CCGrossAmount1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.8333334922790527D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.CCGrossAmount1.Name = "CCGrossAmount1";
            this.CCGrossAmount1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.5D), Telerik.Reporting.Drawing.Unit.Inch(0.15347221493721008D));
            this.CCGrossAmount1.Style.BackgroundColor = System.Drawing.Color.White;
            this.CCGrossAmount1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.CCGrossAmount1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.CCGrossAmount1.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.CCGrossAmount1.Style.Font.Bold = false;
            this.CCGrossAmount1.Style.Font.Italic = false;
            this.CCGrossAmount1.Style.Font.Name = "Arial";
            this.CCGrossAmount1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.CCGrossAmount1.Style.Font.Strikeout = false;
            this.CCGrossAmount1.Style.Font.Underline = false;
            this.CCGrossAmount1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.CCGrossAmount1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.CCGrossAmount1.Style.Visible = true;
            this.CCGrossAmount1.Value = "= Fields.CCGrossAmount";
            // 
            // CCNetAmount1
            // 
            this.CCNetAmount1.CanGrow = false;
            this.CCNetAmount1.CanShrink = false;
            this.CCNetAmount1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.4166665077209473D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.CCNetAmount1.Name = "CCNetAmount1";
            this.CCNetAmount1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.5D), Telerik.Reporting.Drawing.Unit.Inch(0.15347221493721008D));
            this.CCNetAmount1.Style.BackgroundColor = System.Drawing.Color.White;
            this.CCNetAmount1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.CCNetAmount1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.CCNetAmount1.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.CCNetAmount1.Style.Font.Bold = false;
            this.CCNetAmount1.Style.Font.Italic = false;
            this.CCNetAmount1.Style.Font.Name = "Arial";
            this.CCNetAmount1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.CCNetAmount1.Style.Font.Strikeout = false;
            this.CCNetAmount1.Style.Font.Underline = false;
            this.CCNetAmount1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.CCNetAmount1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.CCNetAmount1.Style.Visible = true;
            this.CCNetAmount1.Value = "= Fields.CCNetAmount";
            // 
            // VCHFareAmount1
            // 
            this.VCHFareAmount1.CanGrow = false;
            this.VCHFareAmount1.CanShrink = false;
            this.VCHFareAmount1.Format = "{0:C2}";
            this.VCHFareAmount1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.VCHFareAmount1.Name = "VCHFareAmount1";
            this.VCHFareAmount1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.5D), Telerik.Reporting.Drawing.Unit.Inch(0.15347221493721008D));
            this.VCHFareAmount1.Style.BackgroundColor = System.Drawing.Color.White;
            this.VCHFareAmount1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.VCHFareAmount1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.VCHFareAmount1.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.VCHFareAmount1.Style.Font.Bold = false;
            this.VCHFareAmount1.Style.Font.Italic = false;
            this.VCHFareAmount1.Style.Font.Name = "Arial";
            this.VCHFareAmount1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.VCHFareAmount1.Style.Font.Strikeout = false;
            this.VCHFareAmount1.Style.Font.Underline = false;
            this.VCHFareAmount1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.VCHFareAmount1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.VCHFareAmount1.Style.Visible = true;
            this.VCHFareAmount1.Value = "= Fields.VCHFareAmount";
            // 
            // TotalAmount1
            // 
            this.TotalAmount1.CanGrow = false;
            this.TotalAmount1.CanShrink = false;
            this.TotalAmount1.Format = "{0:C2}";
            this.TotalAmount1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.5833334922790527D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.TotalAmount1.Name = "TotalAmount1";
            this.TotalAmount1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.58333331346511841D), Telerik.Reporting.Drawing.Unit.Inch(0.15347221493721008D));
            this.TotalAmount1.Style.BackgroundColor = System.Drawing.Color.White;
            this.TotalAmount1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.TotalAmount1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.TotalAmount1.Style.Color = System.Drawing.Color.Black;
            this.TotalAmount1.Style.Font.Bold = false;
            this.TotalAmount1.Style.Font.Italic = false;
            this.TotalAmount1.Style.Font.Name = "Arial";
            this.TotalAmount1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.TotalAmount1.Style.Font.Strikeout = false;
            this.TotalAmount1.Style.Font.Underline = false;
            this.TotalAmount1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.TotalAmount1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.TotalAmount1.Style.Visible = true;
            this.TotalAmount1.Value = "= Fields.TotalAmount";
            // 
            // textBox1
            // 
            this.textBox1.CanGrow = false;
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9378803194267675E-05D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.58329397439956665D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox1.Value = "= Fields.DriverNumber";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.3000001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.3999999463558197D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox2.Value = "= Fields.CCNumberLastFour";
            // 
            // textBox3
            // 
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.7000789642333984D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.52999997138977051D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox3.Value = "= Fields.CCAuthCode";
            // 
            // textBox4
            // 
            this.textBox4.Format = "{0:C2}";
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.25D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.5D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox4.Value = "= Fields.ServiceCharge";
            // 
            // panel3
            // 
            this.panel3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.6666665077209473D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.panel3.Name = "panel3";
            this.panel3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.299999862909317D), Telerik.Reporting.Drawing.Unit.Inch(0.15343284606933594D));
            this.panel3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.panel3.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1D);
            // 
            // panel2
            // 
            this.panel2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.2999610900878906D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.panel2.Name = "panel2";
            this.panel2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.299999862909317D), Telerik.Reporting.Drawing.Unit.Inch(0.15343284606933594D));
            this.panel2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.panel2.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1D);
            // 
            // GroupNameDriverNumber1
            // 
            this.GroupNameDriverNumber1.CanGrow = false;
            this.GroupNameDriverNumber1.CanShrink = false;
            this.GroupNameDriverNumber1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.GroupNameDriverNumber1.Name = "GroupNameDriverNumber1";
            this.GroupNameDriverNumber1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.58333331346511841D), Telerik.Reporting.Drawing.Unit.Inch(0.15347221493721008D));
            this.GroupNameDriverNumber1.Style.BackgroundColor = System.Drawing.Color.White;
            this.GroupNameDriverNumber1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.GroupNameDriverNumber1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.GroupNameDriverNumber1.Style.Color = System.Drawing.Color.Black;
            this.GroupNameDriverNumber1.Style.Font.Bold = true;
            this.GroupNameDriverNumber1.Style.Font.Italic = false;
            this.GroupNameDriverNumber1.Style.Font.Name = "Arial";
            this.GroupNameDriverNumber1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.GroupNameDriverNumber1.Style.Font.Strikeout = false;
            this.GroupNameDriverNumber1.Style.Font.Underline = false;
            this.GroupNameDriverNumber1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.GroupNameDriverNumber1.Style.Visible = true;
            this.GroupNameDriverNumber1.Value = "= Fields.DriverNumber";
            // 
            // Line13
            // 
            this.Line13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.9722223281860352D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.Line13.Name = "Line13";
            this.Line13.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.Line13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Point(4D), Telerik.Reporting.Drawing.Unit.Inch(0.25D));
            this.Line13.Style.Color = System.Drawing.Color.Black;
            this.Line13.Style.LineStyle = Telerik.Reporting.Drawing.LineStyle.Solid;
            this.Line13.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.Line13.Style.Visible = true;
            // 
            // Line10
            // 
            this.Line10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.6666665077209473D), Telerik.Reporting.Drawing.Unit.Inch(-0.02777777798473835D));
            this.Line10.Name = "Line10";
            this.Line10.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW);
            this.Line10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.3333333432674408D), Telerik.Reporting.Drawing.Unit.Point(4D));
            this.Line10.Style.Color = System.Drawing.Color.Black;
            this.Line10.Style.LineStyle = Telerik.Reporting.Drawing.LineStyle.Solid;
            this.Line10.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.Line10.Style.Visible = true;
            // 
            // Line11
            // 
            this.Line11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.6666665077209473D), Telerik.Reporting.Drawing.Unit.Inch(0.2222222238779068D));
            this.Line11.Name = "Line11";
            this.Line11.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW);
            this.Line11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.3333333432674408D), Telerik.Reporting.Drawing.Unit.Point(4D));
            this.Line11.Style.Color = System.Drawing.Color.Black;
            this.Line11.Style.LineStyle = Telerik.Reporting.Drawing.LineStyle.Solid;
            this.Line11.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.Line11.Style.Visible = true;
            // 
            // Line12
            // 
            this.Line12.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.6388888359069824D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.Line12.Name = "Line12";
            this.Line12.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.NS);
            this.Line12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Point(4D), Telerik.Reporting.Drawing.Unit.Inch(0.25D));
            this.Line12.Style.Color = System.Drawing.Color.Black;
            this.Line12.Style.LineStyle = Telerik.Reporting.Drawing.LineStyle.Solid;
            this.Line12.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.Line12.Style.Visible = true;
            // 
            // Expr10251
            // 
            this.Expr10251.CanGrow = false;
            this.Expr10251.CanShrink = false;
            this.Expr10251.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.25D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.Expr10251.Name = "Expr10251";
            this.Expr10251.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.4166666567325592D), Telerik.Reporting.Drawing.Unit.Inch(0.15347221493721008D));
            this.Expr10251.Style.BackgroundColor = System.Drawing.Color.White;
            this.Expr10251.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Expr10251.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Expr10251.Style.Color = System.Drawing.Color.Black;
            this.Expr10251.Style.Font.Bold = false;
            this.Expr10251.Style.Font.Italic = false;
            this.Expr10251.Style.Font.Name = "Arial";
            this.Expr10251.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Expr10251.Style.Font.Strikeout = false;
            this.Expr10251.Style.Font.Underline = false;
            this.Expr10251.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Expr10251.Style.Visible = true;
            this.Expr10251.Value = "= Fields.CCNumberLastFour";
            // 
            // ServiceCharge1
            // 
            this.ServiceCharge1.CanGrow = false;
            this.ServiceCharge1.CanShrink = false;
            this.ServiceCharge1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.25D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.ServiceCharge1.Name = "ServiceCharge1";
            this.ServiceCharge1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.5D), Telerik.Reporting.Drawing.Unit.Inch(0.15347221493721008D));
            this.ServiceCharge1.Style.BackgroundColor = System.Drawing.Color.White;
            this.ServiceCharge1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.ServiceCharge1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.ServiceCharge1.Style.Color = System.Drawing.Color.Black;
            this.ServiceCharge1.Style.Font.Bold = false;
            this.ServiceCharge1.Style.Font.Italic = false;
            this.ServiceCharge1.Style.Font.Name = "Arial";
            this.ServiceCharge1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.ServiceCharge1.Style.Font.Strikeout = false;
            this.ServiceCharge1.Style.Font.Underline = false;
            this.ServiceCharge1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.ServiceCharge1.Style.Visible = true;
            this.ServiceCharge1.Value = "= Fields.ServiceCharge";
            // 
            // CCAuthCode1
            // 
            this.CCAuthCode1.CanGrow = false;
            this.CCAuthCode1.CanShrink = false;
            this.CCAuthCode1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.6666667461395264D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.CCAuthCode1.Name = "CCAuthCode1";
            this.CCAuthCode1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.5D), Telerik.Reporting.Drawing.Unit.Inch(0.15347221493721008D));
            this.CCAuthCode1.Style.BackgroundColor = System.Drawing.Color.White;
            this.CCAuthCode1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.CCAuthCode1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.CCAuthCode1.Style.Color = System.Drawing.Color.Black;
            this.CCAuthCode1.Style.Font.Bold = false;
            this.CCAuthCode1.Style.Font.Italic = false;
            this.CCAuthCode1.Style.Font.Name = "Arial";
            this.CCAuthCode1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.CCAuthCode1.Style.Font.Strikeout = false;
            this.CCAuthCode1.Style.Font.Underline = false;
            this.CCAuthCode1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.CCAuthCode1.Style.Visible = true;
            this.CCAuthCode1.Value = "= Fields.CCAuthCode";
            // 
            // ReportFooterArea1
            // 
            this.ReportFooterArea1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.99305558204650879D);
            this.ReportFooterArea1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.ReportFooterSection1,
            this.ReportFooterSection2});
            this.ReportFooterArea1.KeepTogether = false;
            this.ReportFooterArea1.Name = "ReportFooterArea1";
            this.ReportFooterArea1.PageBreak = Telerik.Reporting.PageBreak.After;
            this.ReportFooterArea1.Style.Visible = true;
            // 
            // ReportFooterSection1
            // 
            this.ReportFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.SumofTotalAmount1,
            this.Text16,
            this.Line6,
            this.SumofVCHFareAmount1,
            this.SumofServiceCharge1,
            this.SumofCCNetAmount1,
            this.SumofCCGrossAmount1});
            this.ReportFooterSection1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.ReportFooterSection1.Name = "ReportFooterSection1";
            this.ReportFooterSection1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(8.3000001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.30902779102325439D));
            this.ReportFooterSection1.Style.BackgroundColor = System.Drawing.Color.White;
            this.ReportFooterSection1.Style.Visible = true;
            // 
            // SumofTotalAmount1
            // 
            this.SumofTotalAmount1.CanGrow = false;
            this.SumofTotalAmount1.CanShrink = false;
            this.SumofTotalAmount1.Format = "{0:C2}";
            this.SumofTotalAmount1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.6000003814697266D), Telerik.Reporting.Drawing.Unit.Inch(0.0833333358168602D));
            this.SumofTotalAmount1.Name = "SumofTotalAmount1";
            this.SumofTotalAmount1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.75D), Telerik.Reporting.Drawing.Unit.Inch(0.1597222238779068D));
            this.SumofTotalAmount1.Style.BackgroundColor = System.Drawing.Color.White;
            this.SumofTotalAmount1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.SumofTotalAmount1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.SumofTotalAmount1.Style.Color = System.Drawing.Color.Black;
            this.SumofTotalAmount1.Style.Font.Bold = true;
            this.SumofTotalAmount1.Style.Font.Italic = false;
            this.SumofTotalAmount1.Style.Font.Name = "Arial";
            this.SumofTotalAmount1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.SumofTotalAmount1.Style.Font.Strikeout = false;
            this.SumofTotalAmount1.Style.Font.Underline = false;
            this.SumofTotalAmount1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.SumofTotalAmount1.Style.Visible = true;
            this.SumofTotalAmount1.Value = "= Sum(Fields.TotalAmount)";
            // 
            // Text16
            // 
            this.Text16.CanGrow = false;
            this.Text16.CanShrink = false;
            this.Text16.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.0833333358168602D));
            this.Text16.Name = "Text16";
            this.Text16.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.875D), Telerik.Reporting.Drawing.Unit.Inch(0.15347221493721008D));
            this.Text16.Style.BackgroundColor = System.Drawing.Color.White;
            this.Text16.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Text16.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Text16.Style.Color = System.Drawing.Color.Black;
            this.Text16.Style.Font.Bold = true;
            this.Text16.Style.Font.Italic = false;
            this.Text16.Style.Font.Name = "Arial";
            this.Text16.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.Text16.Style.Font.Strikeout = false;
            this.Text16.Style.Font.Underline = false;
            this.Text16.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Text16.Style.Visible = true;
            this.Text16.Value = "Total:";
            // 
            // Line6
            // 
            this.Line6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(-0.024305554106831551D));
            this.Line6.Name = "Line6";
            this.Line6.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW);
            this.Line6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(8.1659717559814453D), Telerik.Reporting.Drawing.Unit.Point(3.75D));
            this.Line6.Style.Color = System.Drawing.Color.Black;
            this.Line6.Style.LineStyle = Telerik.Reporting.Drawing.LineStyle.Solid;
            this.Line6.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.Line6.Style.Visible = true;
            // 
            // SumofVCHFareAmount1
            // 
            this.SumofVCHFareAmount1.CanGrow = false;
            this.SumofVCHFareAmount1.CanShrink = false;
            this.SumofVCHFareAmount1.Format = "{0:C2}";
            this.SumofVCHFareAmount1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.9000000953674316D), Telerik.Reporting.Drawing.Unit.Inch(0.0833333358168602D));
            this.SumofVCHFareAmount1.Name = "SumofVCHFareAmount1";
            this.SumofVCHFareAmount1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.69992125034332275D), Telerik.Reporting.Drawing.Unit.Inch(0.1597222238779068D));
            this.SumofVCHFareAmount1.Style.BackgroundColor = System.Drawing.Color.White;
            this.SumofVCHFareAmount1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.SumofVCHFareAmount1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.SumofVCHFareAmount1.Style.Color = System.Drawing.Color.Black;
            this.SumofVCHFareAmount1.Style.Font.Bold = true;
            this.SumofVCHFareAmount1.Style.Font.Italic = false;
            this.SumofVCHFareAmount1.Style.Font.Name = "Arial";
            this.SumofVCHFareAmount1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.SumofVCHFareAmount1.Style.Font.Strikeout = false;
            this.SumofVCHFareAmount1.Style.Font.Underline = false;
            this.SumofVCHFareAmount1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.SumofVCHFareAmount1.Style.Visible = true;
            this.SumofVCHFareAmount1.Value = "= Sum(Fields.VCHFareAmount)";
            // 
            // SumofCCGrossAmount1
            // 
            this.SumofCCGrossAmount1.CanGrow = false;
            this.SumofCCGrossAmount1.CanShrink = false;
            this.SumofCCGrossAmount1.Format = "{0:C2}";
            this.SumofCCGrossAmount1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.7000002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0.0833333358168602D));
            this.SumofCCGrossAmount1.Name = "SumofCCGrossAmount1";
            this.SumofCCGrossAmount1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.63333320617675781D), Telerik.Reporting.Drawing.Unit.Inch(0.1597222238779068D));
            this.SumofCCGrossAmount1.Style.BackgroundColor = System.Drawing.Color.White;
            this.SumofCCGrossAmount1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.SumofCCGrossAmount1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.SumofCCGrossAmount1.Style.Color = System.Drawing.Color.Black;
            this.SumofCCGrossAmount1.Style.Font.Bold = true;
            this.SumofCCGrossAmount1.Style.Font.Italic = false;
            this.SumofCCGrossAmount1.Style.Font.Name = "Arial";
            this.SumofCCGrossAmount1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.SumofCCGrossAmount1.Style.Font.Strikeout = false;
            this.SumofCCGrossAmount1.Style.Font.Underline = false;
            this.SumofCCGrossAmount1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.SumofCCGrossAmount1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.SumofCCGrossAmount1.Style.Visible = true;
            this.SumofCCGrossAmount1.Value = "= Sum(Fields.CCGrossAmount)";
            // 
            // SumofServiceCharge1
            // 
            this.SumofServiceCharge1.CanGrow = false;
            this.SumofServiceCharge1.CanShrink = false;
            this.SumofServiceCharge1.Format = "{0:C2}";
            this.SumofServiceCharge1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4D), Telerik.Reporting.Drawing.Unit.Inch(0.0833333358168602D));
            this.SumofServiceCharge1.Name = "SumofServiceCharge1";
            this.SumofServiceCharge1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.66666668653488159D), Telerik.Reporting.Drawing.Unit.Inch(0.1597222238779068D));
            this.SumofServiceCharge1.Style.BackgroundColor = System.Drawing.Color.White;
            this.SumofServiceCharge1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.SumofServiceCharge1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.SumofServiceCharge1.Style.Color = System.Drawing.Color.Black;
            this.SumofServiceCharge1.Style.Font.Bold = true;
            this.SumofServiceCharge1.Style.Font.Italic = false;
            this.SumofServiceCharge1.Style.Font.Name = "Arial";
            this.SumofServiceCharge1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.SumofServiceCharge1.Style.Font.Strikeout = false;
            this.SumofServiceCharge1.Style.Font.Underline = false;
            this.SumofServiceCharge1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.SumofServiceCharge1.Style.Visible = true;
            this.SumofServiceCharge1.Value = "= Sum(Fields.ServiceCharge)";
            // 
            // SumofCCNetAmount1
            // 
            this.SumofCCNetAmount1.CanGrow = false;
            this.SumofCCNetAmount1.CanShrink = false;
            this.SumofCCNetAmount1.Format = "{0:C2}";
            this.SumofCCNetAmount1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.2000002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0.0833333358168602D));
            this.SumofCCNetAmount1.Name = "SumofCCNetAmount1";
            this.SumofCCNetAmount1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.716666579246521D), Telerik.Reporting.Drawing.Unit.Inch(0.1597222238779068D));
            this.SumofCCNetAmount1.Style.BackgroundColor = System.Drawing.Color.White;
            this.SumofCCNetAmount1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.SumofCCNetAmount1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.SumofCCNetAmount1.Style.Color = System.Drawing.Color.Black;
            this.SumofCCNetAmount1.Style.Font.Bold = true;
            this.SumofCCNetAmount1.Style.Font.Italic = false;
            this.SumofCCNetAmount1.Style.Font.Name = "Arial";
            this.SumofCCNetAmount1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.SumofCCNetAmount1.Style.Font.Strikeout = false;
            this.SumofCCNetAmount1.Style.Font.Underline = false;
            this.SumofCCNetAmount1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.SumofCCNetAmount1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.SumofCCNetAmount1.Style.Visible = true;
            this.SumofCCNetAmount1.Value = "= Sum(Fields.CCNetAmount)";
            // 
            // ReportFooterSection2
            // 
            this.ReportFooterSection2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.Subreport1});
            this.ReportFooterSection2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.30902779102325439D));
            this.ReportFooterSection2.Name = "ReportFooterSection2";
            this.ReportFooterSection2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(8.3000001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.68402779102325439D));
            this.ReportFooterSection2.Style.BackgroundColor = System.Drawing.Color.White;
            this.ReportFooterSection2.Style.Visible = false;
            // 
            // Subreport1
            // 
            this.Subreport1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.03125D));
            this.Subreport1.Name = "Subreport1";
            instanceReportSource1.ReportDocument = null;
            this.Subreport1.ReportSource = instanceReportSource1;
            this.Subreport1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(8.1666669845581055D), Telerik.Reporting.Drawing.Unit.Inch(0.65277779102325439D));
            this.Subreport1.Style.BackgroundColor = System.Drawing.Color.White;
            this.Subreport1.Style.BorderColor.Default = System.Drawing.Color.Black;
            this.Subreport1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.Subreport1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.Subreport1.Style.Visible = true;
            // 
            // PageFooterArea1
            // 
            this.PageFooterArea1.Height = Telerik.Reporting.Drawing.Unit.Inch(0D);
            this.PageFooterArea1.Name = "PageFooterArea1";
            this.PageFooterArea1.PrintOnFirstPage = true;
            this.PageFooterArea1.PrintOnLastPage = true;
            this.PageFooterArea1.Style.BackgroundColor = System.Drawing.Color.White;
            this.PageFooterArea1.Style.Visible = true;
            // 
            // DriverFares_OO
            // 
            this.DataSource = this.sqlDataSource1;
            group1.GroupFooter = this.GroupFooterArea1;
            group1.GroupHeader = this.GroupHeaderArea1;
            group1.Groupings.Add(new Telerik.Reporting.Grouping("= Fields.DriverNumber"));
            group1.GroupKeepTogether = Telerik.Reporting.GroupKeepTogether.All;
            group1.Name = "DriverNumberGroup";
            group1.Sortings.Add(new Telerik.Reporting.Sorting("= Fields.DriverNumber", Telerik.Reporting.SortDirection.Asc));
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            group1});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.GroupHeaderArea1,
            this.GroupFooterArea1,
            this.ReportHeaderArea1,
            this.PageHeaderArea1,
            this.DetailArea1,
            this.ReportFooterArea1,
            this.PageFooterArea1});
            this.Name = "DriverFares-New";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612D), Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612D), Telerik.Reporting.Drawing.Unit.Inch(0.16527777910232544D), Telerik.Reporting.Drawing.Unit.Inch(0.16805554926395416D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.AllowNull = true;
            reportParameter1.AutoRefresh = true;
            reportParameter1.AvailableValues.DataSource = this.sqlDataSource1;
            reportParameter1.AvailableValues.DisplayMember = "30908";
            reportParameter1.AvailableValues.ValueMember = "= Fields.DriverNumber";
            reportParameter1.Name = "DrNumber";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter1.Value = "= Parameters.DrNumber.Value";
            this.ReportParameters.Add(reportParameter1);
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(8.3000001907348633D);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.ReportHeaderSection ReportHeaderArea1;
        private Telerik.Reporting.PageHeaderSection PageHeaderArea1;
        private Telerik.Reporting.Panel PageHeaderSection1;
        private Telerik.Reporting.TextBox PrintDate1;
        private Telerik.Reporting.TextBox Text13;
        private Telerik.Reporting.TextBox Text15;
        private Telerik.Reporting.TextBox PageNofM1;
        private Telerik.Reporting.Panel PageHeaderSection2;
        private Telerik.Reporting.TextBox Text12;
        private Telerik.Reporting.TextBox Text11;
        private Telerik.Reporting.TextBox Text10;
        private Telerik.Reporting.TextBox Text9;
        private Telerik.Reporting.TextBox Text8;
        private Telerik.Reporting.TextBox Text7;
        private Telerik.Reporting.TextBox Text6;
        private Telerik.Reporting.TextBox Text4;
        private Telerik.Reporting.TextBox Text3;
        private Telerik.Reporting.TextBox Text2;
        private Telerik.Reporting.TextBox Text1;
        private Telerik.Reporting.TextBox Text17;
        private Telerik.Reporting.TextBox Text14;
        private Telerik.Reporting.TextBox Text5;
        private Telerik.Reporting.TextBox Text18;
        private Telerik.Reporting.TextBox Text19;
        private Telerik.Reporting.DetailSection DetailArea1;
        private Telerik.Reporting.TextBox FareNumber1;
        private Telerik.Reporting.TextBox TripDate1;
        private Telerik.Reporting.TextBox FareType1;
        private Telerik.Reporting.TextBox TripStatus1;
        private Telerik.Reporting.TextBox CCGrossAmount1;
        private Telerik.Reporting.TextBox CCNetAmount1;
        private Telerik.Reporting.TextBox VCHFareAmount1;
        private Telerik.Reporting.TextBox TotalAmount1;
        private Telerik.Reporting.Shape Line13;
        private Telerik.Reporting.Shape Line10;
        private Telerik.Reporting.Shape Line11;
        private Telerik.Reporting.Shape Line12;
        private Telerik.Reporting.TextBox Expr10251;
        private Telerik.Reporting.TextBox ServiceCharge1;
        private Telerik.Reporting.TextBox CCAuthCode1;
        private Telerik.Reporting.ReportFooterSection ReportFooterArea1;
        private Telerik.Reporting.Panel ReportFooterSection1;
        private Telerik.Reporting.TextBox SumofTotalAmount1;
        private Telerik.Reporting.TextBox Text16;
        private Telerik.Reporting.Shape Line6;
        private Telerik.Reporting.TextBox SumofVCHFareAmount1;
        private Telerik.Reporting.TextBox SumofCCNetAmount1;
        private Telerik.Reporting.TextBox SumofCCGrossAmount1;
        private Telerik.Reporting.TextBox SumofServiceCharge1;
        private Telerik.Reporting.Panel ReportFooterSection2;
        private Telerik.Reporting.SubReport Subreport1;
        private Telerik.Reporting.PageFooterSection PageFooterArea1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.ComponentModel.IContainer components;
        
        private System.Windows.Forms.BindingSource bindingSource2;
        private Telerik.Reporting.SqlDataSource sqlDataSource1;
       
        private Telerik.Reporting.GroupFooterSection GroupFooterArea1;
        private Telerik.Reporting.GroupHeaderSection GroupHeaderArea1;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox GroupNameDriverNumber1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.Panel panel2;
        private Telerik.Reporting.Panel panel3;
    }
}