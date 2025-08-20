namespace Saude
{
    partial class Formulario_Relatorio_Clientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formulario_Relatorio_Clientes));
            this.tblclientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
          
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
           
            ((System.ComponentModel.ISupportInitialize)(this.tblclientesBindingSource)).BeginInit();
          
            this.SuspendLayout();
            // 
            // tblclientesBindingSource
            // 
            this.tblclientesBindingSource.DataMember = "tblclientes";
           
            // 
            // saudeDataSet
            // 
           
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tblclientesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Saude.Relatorios.Relatorio_Cliente.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(456, 415);
            this.reportViewer1.TabIndex = 0;
            // 
            // tblclientesTableAdapter
            // 
           
            // 
            // Formulario_Relatorio_Clientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 415);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Formulario_Relatorio_Clientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario_Relatorio_Clientes";
            this.Load += new System.EventHandler(this.Formulario_Relatorio_Clientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblclientesBindingSource)).EndInit();
          
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tblclientesBindingSource;
      
    }
}