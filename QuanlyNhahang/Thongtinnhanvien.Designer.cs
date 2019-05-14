namespace QuanlyNhahang
{
    partial class Thongtinnhanvien
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.cardView1 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.accountBBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLNHDataSet7 = new QuanlyNhahang.QLNHDataSet7();
            this.accountBTableAdapter = new QuanlyNhahang.QLNHDataSet7TableAdapters.AccountBTableAdapter();
            this.searchControl1 = new DevExpress.XtraEditors.SearchControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountBBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLNHDataSet7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1136, 36);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(442, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Thông tin Nhân Viên";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(11, 493);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 529);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1120, 16);
            this.panel4.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(1120, 36);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(16, 509);
            this.panel5.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = global::QuanlyNhahang.Properties.Resources.iconfinder_delete_user_3912;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(472, 461);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(177, 62);
            this.button2.TabIndex = 1;
            this.button2.Text = "Xóa NV";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(23, 47);
            this.gridControl1.MainView = this.cardView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1078, 408);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.cardView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // cardView1
            // 
            this.cardView1.Appearance.Card.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardView1.Appearance.Card.Options.UseFont = true;
            this.cardView1.Appearance.FieldCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardView1.Appearance.FieldCaption.FontStyleDelta = System.Drawing.FontStyle.Underline;
            this.cardView1.Appearance.FieldCaption.Options.UseFont = true;
            this.cardView1.Appearance.FieldCaption.Options.UseTextOptions = true;
            this.cardView1.Appearance.FieldCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cardView1.Appearance.FieldCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.cardView1.Appearance.FieldCaption.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.cardView1.Appearance.FieldValue.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardView1.Appearance.FieldValue.ForeColor = System.Drawing.Color.Red;
            this.cardView1.Appearance.FieldValue.Options.UseFont = true;
            this.cardView1.Appearance.FieldValue.Options.UseForeColor = true;
            this.cardView1.Appearance.FieldValue.Options.UseTextOptions = true;
            this.cardView1.Appearance.FieldValue.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cardView1.Appearance.FieldValue.TextOptions.HotkeyPrefix = DevExpress.Utils.HKeyPrefix.Show;
            this.cardView1.Appearance.FieldValue.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisPath;
            this.cardView1.Appearance.FieldValue.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.cardView1.Appearance.FieldValue.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.cardView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.cardView1.CardWidth = 400;
            this.cardView1.DetailHeight = 1000;
            this.cardView1.GridControl = this.gridControl1;
            this.cardView1.Name = "cardView1";
            this.cardView1.PaintStyleName = "WindowsXP";
            this.cardView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            // 
            // accountBBindingSource
            // 
            this.accountBBindingSource.DataMember = "AccountB";
            this.accountBBindingSource.DataSource = this.qLNHDataSet7;
            // 
            // qLNHDataSet7
            // 
            this.qLNHDataSet7.DataSetName = "QLNHDataSet7";
            this.qLNHDataSet7.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // accountBTableAdapter
            // 
            this.accountBTableAdapter.ClearBeforeFill = true;
            // 
            // searchControl1
            // 
            this.searchControl1.Client = this.gridControl1;
            this.searchControl1.Location = new System.Drawing.Point(187, 480);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchControl1.Properties.Appearance.Options.UseFont = true;
            this.searchControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl1.Properties.Client = this.gridControl1;
            this.searchControl1.Size = new System.Drawing.Size(236, 26);
            this.searchControl1.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(73, 483);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(108, 19);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Tìm nhân viên:";
            // 
            // Thongtinnhanvien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.searchControl1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Name = "Thongtinnhanvien";
            this.Size = new System.Drawing.Size(1136, 545);
            this.Load += new System.EventHandler(this.Thongtinnhanvien_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountBBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLNHDataSet7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource accountBBindingSource;
        private QLNHDataSet7 qLNHDataSet7;
        private DevExpress.XtraGrid.Views.Card.CardView cardView1;
        private QLNHDataSet7TableAdapters.AccountBTableAdapter accountBTableAdapter;
        private DevExpress.XtraEditors.SearchControl searchControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
