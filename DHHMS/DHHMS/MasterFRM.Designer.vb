<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MasterFRM
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MasterFRM))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangePasswordMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupAndAccessRoleMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.DataMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DailySaleMISToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StockExpendToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BalancingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuppilierListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomerListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.UserListMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogOutMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.SchoolMI = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(18, 18)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.DataMenu, Me.ReportsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(7, 3, 0, 3)
        Me.MenuStrip1.Size = New System.Drawing.Size(798, 28)
        Me.MenuStrip1.TabIndex = 5
        Me.MenuStrip1.Text = "MenuStrip"
        '
        'FileMenu
        '
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangePasswordMenuItem, Me.UserListMenuItem, Me.GroupAndAccessRoleMI, Me.ToolStripSeparator3, Me.LogOutMI, Me.ToolStripSeparator5, Me.ExitMI})
        Me.FileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.FileMenu.Name = "FileMenu"
        Me.FileMenu.Size = New System.Drawing.Size(51, 22)
        Me.FileMenu.Text = "&Files"
        '
        'ChangePasswordMenuItem
        '
        Me.ChangePasswordMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChangePasswordMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.ChangePasswordMenuItem.Name = "ChangePasswordMenuItem"
        Me.ChangePasswordMenuItem.Size = New System.Drawing.Size(187, 24)
        Me.ChangePasswordMenuItem.Text = "Change password"
        '
        'GroupAndAccessRoleMI
        '
        Me.GroupAndAccessRoleMI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupAndAccessRoleMI.Name = "GroupAndAccessRoleMI"
        Me.GroupAndAccessRoleMI.Size = New System.Drawing.Size(187, 24)
        Me.GroupAndAccessRoleMI.Text = "Accessibilities"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(184, 6)
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(184, 6)
        '
        'DataMenu
        '
        Me.DataMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SuppilierListToolStripMenuItem, Me.CustomerListToolStripMenuItem, Me.ToolStripSeparator1, Me.SchoolMI, Me.ToolStripTextBox1})
        Me.DataMenu.Name = "DataMenu"
        Me.DataMenu.Size = New System.Drawing.Size(98, 22)
        Me.DataMenu.Text = "&Transaction"
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(100, 23)
        Me.ToolStripTextBox1.Text = "Print Invoice"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DailySaleMISToolStripMenuItem, Me.StockExpendToolStripMenuItem, Me.BalancingToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(73, 22)
        Me.ReportsToolStripMenuItem.Text = "&Reports"
        '
        'DailySaleMISToolStripMenuItem
        '
        Me.DailySaleMISToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DailySaleMISToolStripMenuItem.Name = "DailySaleMISToolStripMenuItem"
        Me.DailySaleMISToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.DailySaleMISToolStripMenuItem.Text = "Daily Sale MIS"
        '
        'StockExpendToolStripMenuItem
        '
        Me.StockExpendToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StockExpendToolStripMenuItem.Name = "StockExpendToolStripMenuItem"
        Me.StockExpendToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.StockExpendToolStripMenuItem.Text = "Stock Expend"
        '
        'BalancingToolStripMenuItem
        '
        Me.BalancingToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BalancingToolStripMenuItem.Name = "BalancingToolStripMenuItem"
        Me.BalancingToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.BalancingToolStripMenuItem.Text = "Balancing"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 499)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStrip.Size = New System.Drawing.Size(798, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(39, 17)
        Me.ToolStripStatusLabel.Text = "Status"
        '
        'SuppilierListToolStripMenuItem
        '
        Me.SuppilierListToolStripMenuItem.Name = "SuppilierListToolStripMenuItem"
        Me.SuppilierListToolStripMenuItem.Size = New System.Drawing.Size(171, 24)
        Me.SuppilierListToolStripMenuItem.Text = "Suppilier List"
        '
        'CustomerListToolStripMenuItem
        '
        Me.CustomerListToolStripMenuItem.Name = "CustomerListToolStripMenuItem"
        Me.CustomerListToolStripMenuItem.Size = New System.Drawing.Size(171, 24)
        Me.CustomerListToolStripMenuItem.Text = "Customer List"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(168, 6)
        '
        'UserListMenuItem
        '
        Me.UserListMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserListMenuItem.Image = CType(resources.GetObject("UserListMenuItem.Image"), System.Drawing.Image)
        Me.UserListMenuItem.Name = "UserListMenuItem"
        Me.UserListMenuItem.Size = New System.Drawing.Size(187, 24)
        Me.UserListMenuItem.Text = "User List"
        '
        'LogOutMI
        '
        Me.LogOutMI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LogOutMI.Image = CType(resources.GetObject("LogOutMI.Image"), System.Drawing.Image)
        Me.LogOutMI.Name = "LogOutMI"
        Me.LogOutMI.Size = New System.Drawing.Size(187, 24)
        Me.LogOutMI.Text = "LogOut"
        '
        'ExitMI
        '
        Me.ExitMI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExitMI.Image = CType(resources.GetObject("ExitMI.Image"), System.Drawing.Image)
        Me.ExitMI.Name = "ExitMI"
        Me.ExitMI.Size = New System.Drawing.Size(187, 24)
        Me.ExitMI.Text = "&Exit"
        '
        'SchoolMI
        '
        Me.SchoolMI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SchoolMI.Image = Global.DHHMS.My.Resources.Resources.home1
        Me.SchoolMI.Name = "SchoolMI"
        Me.SchoolMI.Size = New System.Drawing.Size(171, 24)
        Me.SchoolMI.Text = "Customer List"
        '
        'MasterFRM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(798, 521)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.StatusStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.Name = "MasterFRM"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Depo Hak Heng"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ExitMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LogOutMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UserListMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ChangePasswordMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents DataMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SchoolMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupAndAccessRoleMI As ToolStripMenuItem
    Friend WithEvents ToolStripTextBox1 As ToolStripTextBox
    Friend WithEvents ReportsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DailySaleMISToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StockExpendToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BalancingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SuppilierListToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CustomerListToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
End Class
