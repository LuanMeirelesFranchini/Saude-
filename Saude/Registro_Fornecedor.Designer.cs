namespace Saude
{
    partial class Registro_Fornecedor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registro_Fornecedor));
            this.tblfornecedorBindingSource = new System.Windows.Forms.BindingSource(this.components);
         
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
           
            ((System.ComponentModel.ISupportInitialize)(this.tblfornecedorBindingSource)).BeginInit();
            
            this.SuspendLayout();
            // 
            // tblfornecedorBindingSource
            // 
            this.tblfornecedorBindingSource.DataMember = "tblfornecedor";
          
            // 
            // saudeDataSet
            // 
           
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tblfornecedorBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Saude.Relatorios.Relatorio_Fornecedor.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(400, 373);
            this.reportViewer1.TabIndex = 0;
            // 
            // tblfornecedorTableAdapter
            // 
          
            // 
            // Registro_Fornecedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 373);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Registro_Fornecedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro_Fornecedor";
            this.Load += new System.EventHandler(this.Registro_Fornecedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblfornecedorBindingSource)).EndInit();
           
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tblfornecedorBindingSource;
       
    }
}