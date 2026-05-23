namespace MiniCompiler
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCompile = new System.Windows.Forms.Button();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.splitContainerLeft = new System.Windows.Forms.SplitContainer();
            this.lblEditor = new System.Windows.Forms.Label();
            this.txtEditor = new System.Windows.Forms.RichTextBox();
            this.lblConsole = new System.Windows.Forms.Label();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.tabControlPhases = new System.Windows.Forms.TabControl();
            this.tabLexical = new System.Windows.Forms.TabPage();
            this.dgvTokens = new System.Windows.Forms.DataGridView();
            this.ColToken = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabParser = new System.Windows.Forms.TabPage();
            this.tvParseTree = new System.Windows.Forms.TreeView();
            this.tabSemantic = new System.Windows.Forms.TabPage();
            this.txtSemanticTree = new System.Windows.Forms.TextBox();
            this.tabIR = new System.Windows.Forms.TabPage();
            this.txtIRCode = new System.Windows.Forms.TextBox();
            this.tabTarget = new System.Windows.Forms.TabPage();
            this.txtTargetCode = new System.Windows.Forms.TextBox();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeft)).BeginInit();
            this.splitContainerLeft.Panel1.SuspendLayout();
            this.splitContainerLeft.Panel2.SuspendLayout();
            this.splitContainerLeft.SuspendLayout();
            this.tabControlPhases.SuspendLayout();
            this.tabLexical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTokens)).BeginInit();
            this.tabParser.SuspendLayout();
            this.tabSemantic.SuspendLayout();
            this.tabIR.SuspendLayout();
            this.tabTarget.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.btnCompile);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1260, 70);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Cyan;
            this.lblTitle.Location = new System.Drawing.Point(20, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(222, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "MINI COMPILER";
            // 
            // btnCompile
            // 
            this.btnCompile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCompile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompile.FlatAppearance.BorderSize = 0;
            this.btnCompile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompile.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCompile.ForeColor = System.Drawing.Color.Black;
            this.btnCompile.Location = new System.Drawing.Point(1110, 15);
            this.btnCompile.Name = "btnCompile";
            this.btnCompile.Size = new System.Drawing.Size(130, 40);
            this.btnCompile.TabIndex = 1;
            this.btnCompile.Text = "▶ RUN";
            this.btnCompile.UseVisualStyleBackColor = false;
            this.btnCompile.Click += new System.EventHandler(this.btnCompile_Click);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 70);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.splitContainerLeft);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.tabControlPhases);
            this.splitContainerMain.Size = new System.Drawing.Size(1260, 680);
            this.splitContainerMain.SplitterDistance = 520;
            this.splitContainerMain.TabIndex = 1;
            // 
            // splitContainerLeft
            // 
            this.splitContainerLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerLeft.Location = new System.Drawing.Point(0, 0);
            this.splitContainerLeft.Name = "splitContainerLeft";
            this.splitContainerLeft.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerLeft.Panel1
            // 
            this.splitContainerLeft.Panel1.Controls.Add(this.lblEditor);
            this.splitContainerLeft.Panel1.Controls.Add(this.txtEditor);
            // 
            // splitContainerLeft.Panel2
            // 
            this.splitContainerLeft.Panel2.Controls.Add(this.lblConsole);
            this.splitContainerLeft.Panel2.Controls.Add(this.txtConsole);
            this.splitContainerLeft.Size = new System.Drawing.Size(520, 680);
            this.splitContainerLeft.SplitterDistance = 330;
            this.splitContainerLeft.TabIndex = 0;
            // 
            // lblEditor
            // 
            this.lblEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.lblEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEditor.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblEditor.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.lblEditor.Location = new System.Drawing.Point(0, 0);
            this.lblEditor.Name = "lblEditor";
            this.lblEditor.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblEditor.Size = new System.Drawing.Size(520, 30);
            this.lblEditor.TabIndex = 1;
            this.lblEditor.Text = "SOURCE CODE EDITOR (TYPE MANUALLY HERE)";
            this.lblEditor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEditor
            // 
            this.txtEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.txtEditor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEditor.Font = new System.Drawing.Font("Consolas", 12.5F);
            this.txtEditor.ForeColor = System.Drawing.Color.Lime;
            this.txtEditor.Location = new System.Drawing.Point(0, 33);
            this.txtEditor.Name = "txtEditor";
            this.txtEditor.Size = new System.Drawing.Size(520, 294);
            this.txtEditor.TabIndex = 0;
            this.txtEditor.Text = "";
            // 
            // lblConsole
            // 
            this.lblConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.lblConsole.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblConsole.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblConsole.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblConsole.Location = new System.Drawing.Point(0, 0);
            this.lblConsole.Name = "lblConsole";
            this.lblConsole.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblConsole.Size = new System.Drawing.Size(520, 30);
            this.lblConsole.TabIndex = 1;
            this.lblConsole.Text = "DIAGNOSTIC WORKSPACE LOG";
            this.lblConsole.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtConsole
            // 
            this.txtConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.txtConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConsole.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Bold);
            this.txtConsole.ForeColor = System.Drawing.Color.White;
            this.txtConsole.Location = new System.Drawing.Point(0, 33);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConsole.Size = new System.Drawing.Size(520, 310);
            this.txtConsole.TabIndex = 0;
            // 
            // tabControlPhases
            // 
            this.tabControlPhases.Controls.Add(this.tabLexical);
            this.tabControlPhases.Controls.Add(this.tabParser);
            this.tabControlPhases.Controls.Add(this.tabSemantic);
            this.tabControlPhases.Controls.Add(this.tabIR);
            this.tabControlPhases.Controls.Add(this.tabTarget);
            this.tabControlPhases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPhases.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.tabControlPhases.ItemSize = new System.Drawing.Size(130, 35);
            this.tabControlPhases.Location = new System.Drawing.Point(0, 0);
            this.tabControlPhases.Name = "tabControlPhases";
            this.tabControlPhases.SelectedIndex = 0;
            this.tabControlPhases.Size = new System.Drawing.Size(736, 680);
            this.tabControlPhases.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlPhases.TabIndex = 0;
            // 
            // tabLexical
            // 
            this.tabLexical.Controls.Add(this.dgvTokens);
            this.tabLexical.Location = new System.Drawing.Point(4, 39);
            this.tabLexical.Name = "tabLexical";
            this.tabLexical.Padding = new System.Windows.Forms.Padding(3);
            this.tabLexical.Size = new System.Drawing.Size(728, 637);
            this.tabLexical.TabIndex = 0;
            this.tabLexical.Text = "Lexical Phase";
            this.tabLexical.UseVisualStyleBackColor = true;
            // 
            // dgvTokens
            // 
            this.dgvTokens.AllowUserToAddRows = false;
            this.dgvTokens.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTokens.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.dgvTokens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTokens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColToken,
            this.ColType});
            this.dgvTokens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTokens.EnableHeadersVisualStyles = false;
            this.dgvTokens.Location = new System.Drawing.Point(3, 3);
            this.dgvTokens.Name = "dgvTokens";
            this.dgvTokens.RowHeadersWidth = 51;
            this.dgvTokens.Size = new System.Drawing.Size(722, 631);
            this.dgvTokens.TabIndex = 0;
            // 
            // ColToken
            // 
            this.ColToken.HeaderText = "Lexeme Value";
            this.ColToken.MinimumWidth = 6;
            this.ColToken.Name = "ColToken";
            // 
            // ColType
            // 
            this.ColType.HeaderText = "Assigned Token Type";
            this.ColType.MinimumWidth = 6;
            this.ColType.Name = "ColType";
            // 
            // tabParser
            // 
            this.tabParser.Controls.Add(this.tvParseTree);
            this.tabParser.Location = new System.Drawing.Point(4, 39);
            this.tabParser.Name = "tabParser";
            this.tabParser.Size = new System.Drawing.Size(728, 637);
            this.tabParser.TabIndex = 1;
            this.tabParser.Text = "Syntax Phase";
            this.tabParser.UseVisualStyleBackColor = true;
            // 
            // tvParseTree
            // 
            this.tvParseTree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(15)))), ((int)(((byte)(25)))));
            this.tvParseTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvParseTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvParseTree.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.tvParseTree.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.tvParseTree.Location = new System.Drawing.Point(0, 0);
            this.tvParseTree.Name = "tvParseTree";
            this.tvParseTree.Size = new System.Drawing.Size(728, 637);
            this.tvParseTree.TabIndex = 0;
            // 
            // tabSemantic
            // 
            this.tabSemantic.Controls.Add(this.txtSemanticTree);
            this.tabSemantic.Location = new System.Drawing.Point(4, 39);
            this.tabSemantic.Name = "tabSemantic";
            this.tabSemantic.Size = new System.Drawing.Size(728, 637);
            this.tabSemantic.TabIndex = 2;
            this.tabSemantic.Text = "Semantic Phase";
            this.tabSemantic.UseVisualStyleBackColor = true;
            // 
            // txtSemanticTree
            // 
            this.txtSemanticTree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.txtSemanticTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSemanticTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSemanticTree.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.txtSemanticTree.ForeColor = System.Drawing.Color.HotPink;
            this.txtSemanticTree.Location = new System.Drawing.Point(0, 0);
            this.txtSemanticTree.Multiline = true;
            this.txtSemanticTree.Name = "txtSemanticTree";
            this.txtSemanticTree.ReadOnly = true;
            this.txtSemanticTree.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSemanticTree.Size = new System.Drawing.Size(728, 637);
            this.txtSemanticTree.TabIndex = 0;
            // 
            // tabIR
            // 
            this.tabIR.Controls.Add(this.txtIRCode);
            this.tabIR.Location = new System.Drawing.Point(4, 39);
            this.tabIR.Name = "tabIR";
            this.tabIR.Size = new System.Drawing.Size(728, 637);
            this.tabIR.TabIndex = 3;
            this.tabIR.Text = "IR Optimization";
            this.tabIR.UseVisualStyleBackColor = true;
            // 
            // txtIRCode
            // 
            this.txtIRCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(21)))), ((int)(((byte)(10)))));
            this.txtIRCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIRCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtIRCode.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.txtIRCode.ForeColor = System.Drawing.Color.Gold;
            this.txtIRCode.Location = new System.Drawing.Point(0, 0);
            this.txtIRCode.Multiline = true;
            this.txtIRCode.Name = "txtIRCode";
            this.txtIRCode.ReadOnly = true;
            this.txtIRCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtIRCode.Size = new System.Drawing.Size(728, 637);
            this.txtIRCode.TabIndex = 0;
            // 
            // tabTarget
            // 
            this.tabTarget.Controls.Add(this.txtTargetCode);
            this.tabTarget.Location = new System.Drawing.Point(4, 39);
            this.tabTarget.Name = "tabTarget";
            this.tabTarget.Size = new System.Drawing.Size(728, 637);
            this.tabTarget.TabIndex = 4;
            this.tabTarget.Text = "Code Synthesis";
            this.tabTarget.UseVisualStyleBackColor = true;
            // 
            // txtTargetCode
            // 
            this.txtTargetCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(10)))), ((int)(((byte)(25)))));
            this.txtTargetCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTargetCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTargetCode.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.txtTargetCode.ForeColor = System.Drawing.Color.MediumOrchid;
            this.txtTargetCode.Location = new System.Drawing.Point(0, 0);
            this.txtTargetCode.Multiline = true;
            this.txtTargetCode.Name = "txtTargetCode";
            this.txtTargetCode.ReadOnly = true;
            this.txtTargetCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTargetCode.Size = new System.Drawing.Size(728, 637);
            this.txtTargetCode.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1260, 750);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.panelHeader);
            this.MinimumSize = new System.Drawing.Size(1100, 650);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mini Compiler Architectural IDE Pro v5.0";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.splitContainerLeft.Panel1.ResumeLayout(false);
            this.splitContainerLeft.Panel2.ResumeLayout(false);
            this.splitContainerLeft.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeft)).EndInit();
            this.splitContainerLeft.ResumeLayout(false);
            this.tabControlPhases.ResumeLayout(false);
            this.tabLexical.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTokens)).EndInit();
            this.tabParser.ResumeLayout(false);
            this.tabSemantic.ResumeLayout(false);
            this.tabSemantic.PerformLayout();
            this.tabIR.ResumeLayout(false);
            this.tabIR.PerformLayout();
            this.tabTarget.ResumeLayout(false);
            this.tabTarget.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnCompile;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.SplitContainer splitContainerLeft;
        private System.Windows.Forms.RichTextBox txtEditor;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.TabControl tabControlPhases;
        private System.Windows.Forms.TabPage tabLexical;
        private System.Windows.Forms.TabPage tabParser;
        private System.Windows.Forms.TabPage tabSemantic;
        private System.Windows.Forms.TabPage tabIR;
        private System.Windows.Forms.TabPage tabTarget;
        private System.Windows.Forms.DataGridView dgvTokens;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColToken;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColType;
        private System.Windows.Forms.TreeView tvParseTree;
        private System.Windows.Forms.TextBox txtSemanticTree;
        private System.Windows.Forms.TextBox txtIRCode;
        private System.Windows.Forms.TextBox txtTargetCode;
        private System.Windows.Forms.Label lblEditor;
        private System.Windows.Forms.Label lblConsole;
    }
}