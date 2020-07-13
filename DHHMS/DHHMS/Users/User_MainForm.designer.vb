<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class User_MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(User_MainForm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tbtnCreate = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbtnEdit = New System.Windows.Forms.ToolStripButton()
        Me.tbtnChange = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbtnreset = New System.Windows.Forms.ToolStripButton()
        Me.tbtnSearch = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.txtCrow = New System.Windows.Forms.TextBox()
        Me.btnL = New System.Windows.Forms.Button()
        Me.btnN = New System.Windows.Forms.Button()
        Me.btnP = New System.Windows.Forms.Button()
        Me.btnF = New System.Windows.Forms.Button()
        Me.btnsearch = New System.Windows.Forms.Button()
        Me.txtFname = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLname = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dg1 = New System.Windows.Forms.DataGridView()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tsbEnableUser = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbtnCreate, Me.ToolStripSeparator2, Me.tbtnEdit, Me.tsbEnableUser, Me.tbtnChange, Me.ToolStripSeparator3, Me.tbtnreset, Me.tbtnSearch, Me.ToolStripSeparator1, Me.ToolStripButton2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(982, 42)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tbtnCreate
        '
        Me.tbtnCreate.Image = CType(resources.GetObject("tbtnCreate.Image"), System.Drawing.Image)
        Me.tbtnCreate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnCreate.Name = "tbtnCreate"
        Me.tbtnCreate.Size = New System.Drawing.Size(125, 39)
        Me.tbtnCreate.Text = "New User Account"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 42)
        '
        'tbtnEdit
        '
        Me.tbtnEdit.Image = Global.DHHMS.My.Resources.Resources.notification_remove
        Me.tbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnEdit.Name = "tbtnEdit"
        Me.tbtnEdit.Size = New System.Drawing.Size(86, 39)
        Me.tbtnEdit.Text = "Diable User"
        '
        'tbtnChange
        '
        Me.tbtnChange.Image = CType(resources.GetObject("tbtnChange.Image"), System.Drawing.Image)
        Me.tbtnChange.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnChange.Name = "tbtnChange"
        Me.tbtnChange.Size = New System.Drawing.Size(121, 39)
        Me.tbtnChange.Text = "Change Password"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 42)
        '
        'tbtnreset
        '
        Me.tbtnreset.Image = CType(resources.GetObject("tbtnreset.Image"), System.Drawing.Image)
        Me.tbtnreset.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnreset.Name = "tbtnreset"
        Me.tbtnreset.Size = New System.Drawing.Size(108, 39)
        Me.tbtnreset.Text = "Reset Password"
        '
        'tbtnSearch
        '
        Me.tbtnSearch.Image = CType(resources.GetObject("tbtnSearch.Image"), System.Drawing.Image)
        Me.tbtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbtnSearch.Name = "tbtnSearch"
        Me.tbtnSearch.Size = New System.Drawing.Size(62, 39)
        Me.tbtnSearch.Text = "Search"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 42)
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.AutoSize = False
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(45, 33)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 42)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtCrow)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnL)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnN)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnP)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnF)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnsearch)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtFname)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtLname)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1Collapsed = True
        Me.SplitContainer1.Panel1MinSize = 260
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dg1)
        Me.SplitContainer1.Size = New System.Drawing.Size(982, 552)
        Me.SplitContainer1.SplitterDistance = 260
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 1
        '
        'txtCrow
        '
        Me.txtCrow.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCrow.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCrow.Location = New System.Drawing.Point(80, 511)
        Me.txtCrow.Name = "txtCrow"
        Me.txtCrow.ReadOnly = True
        Me.txtCrow.Size = New System.Drawing.Size(92, 22)
        Me.txtCrow.TabIndex = 7
        Me.txtCrow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnL
        '
        Me.btnL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnL.Location = New System.Drawing.Point(213, 509)
        Me.btnL.Name = "btnL"
        Me.btnL.Size = New System.Drawing.Size(30, 26)
        Me.btnL.TabIndex = 9
        Me.btnL.Text = ">|"
        Me.btnL.UseVisualStyleBackColor = True
        '
        'btnN
        '
        Me.btnN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnN.Location = New System.Drawing.Point(178, 509)
        Me.btnN.Name = "btnN"
        Me.btnN.Size = New System.Drawing.Size(30, 26)
        Me.btnN.TabIndex = 8
        Me.btnN.Text = ">"
        Me.btnN.UseVisualStyleBackColor = True
        '
        'btnP
        '
        Me.btnP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnP.Location = New System.Drawing.Point(44, 509)
        Me.btnP.Name = "btnP"
        Me.btnP.Size = New System.Drawing.Size(30, 26)
        Me.btnP.TabIndex = 6
        Me.btnP.Text = "<"
        Me.btnP.UseVisualStyleBackColor = True
        '
        'btnF
        '
        Me.btnF.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnF.Location = New System.Drawing.Point(8, 509)
        Me.btnF.Name = "btnF"
        Me.btnF.Size = New System.Drawing.Size(30, 26)
        Me.btnF.TabIndex = 5
        Me.btnF.Text = "|<"
        Me.btnF.UseVisualStyleBackColor = True
        '
        'btnsearch
        '
        Me.btnsearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnsearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsearch.Location = New System.Drawing.Point(149, 117)
        Me.btnsearch.Name = "btnsearch"
        Me.btnsearch.Size = New System.Drawing.Size(94, 30)
        Me.btnsearch.TabIndex = 4
        Me.btnsearch.Text = "Search"
        Me.btnsearch.UseVisualStyleBackColor = True
        '
        'txtFname
        '
        Me.txtFname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFname.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFname.Location = New System.Drawing.Point(13, 33)
        Me.txtFname.Name = "txtFname"
        Me.txtFname.Size = New System.Drawing.Size(230, 22)
        Me.txtFname.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Full Name"
        '
        'txtLname
        '
        Me.txtLname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLname.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLname.Location = New System.Drawing.Point(13, 84)
        Me.txtLname.Name = "txtLname"
        Me.txtLname.Size = New System.Drawing.Size(230, 22)
        Me.txtLname.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Username"
        '
        'dg1
        '
        Me.dg1.AllowUserToAddRows = False
        Me.dg1.AllowUserToDeleteRows = False
        Me.dg1.AllowUserToOrderColumns = True
        Me.dg1.BackgroundColor = System.Drawing.Color.LightGray
        Me.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.Column3, Me.Column4, Me.Column1})
        Me.dg1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dg1.GridColor = System.Drawing.Color.LightBlue
        Me.dg1.Location = New System.Drawing.Point(0, 0)
        Me.dg1.MultiSelect = False
        Me.dg1.Name = "dg1"
        Me.dg1.RowHeadersWidth = 25
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSeaGreen
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Firebrick
        Me.dg1.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dg1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg1.Size = New System.Drawing.Size(980, 550)
        Me.dg1.TabIndex = 0
        '
        'Column2
        '
        Me.Column2.HeaderText = "User Fullname"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 160
        '
        'Column3
        '
        Me.Column3.HeaderText = "UserID"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 150
        '
        'Column4
        '
        Me.Column4.HeaderText = "Locked"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 60
        '
        'Column1
        '
        Me.Column1.HeaderText = "Role"
        Me.Column1.Name = "Column1"
        '
        'tsbEnableUser
        '
        Me.tsbEnableUser.Image = Global.DHHMS.My.Resources.Resources.stock_lock_open
        Me.tsbEnableUser.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEnableUser.Name = "tsbEnableUser"
        Me.tsbEnableUser.Size = New System.Drawing.Size(88, 39)
        Me.tsbEnableUser.Text = "Enable User"
        '
        'User_MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(982, 594)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "User_MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "User Account"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tbtnCreate As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbtnEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbtnChange As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbtnreset As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dg1 As System.Windows.Forms.DataGridView
    Friend WithEvents tbtnSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCrow As System.Windows.Forms.TextBox
    Friend WithEvents btnP As System.Windows.Forms.Button
    Friend WithEvents btnF As System.Windows.Forms.Button
    Friend WithEvents btnsearch As System.Windows.Forms.Button
    Friend WithEvents txtFname As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtLname As System.Windows.Forms.TextBox
    Friend WithEvents btnL As System.Windows.Forms.Button
    Friend WithEvents btnN As System.Windows.Forms.Button
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents tsbEnableUser As ToolStripButton
End Class
