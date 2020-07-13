Imports System.Windows.Forms

Public Class MasterFRM
    Public dbUser As String
    Public dbPwd As String
    Public dbPath As String
    Public dbDatasource As String
    Public dbName As String
    Public dbConnSuf As String
    Public loginName As String

    Dim dbhpr As New db_helper
    Dim logdb As New LoginDB
    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        With User_MainForm
            .MdiParent = Me
            .Show()
            .WindowState = FormWindowState.Maximized
        End With
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles UserListMenuItem.Click
        With User_MainForm
            .Show()
            .MdiParent = Me
            .WindowState = FormWindowState.Maximized
        End With
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitMI.Click
        Application.Exit()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Dim LogOff As Boolean = True
    Private Sub MasterFRM_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'close child form
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
        'check from closing
        If LogOff = True Then
            If MsgBox("តើអ្នកពិតជាចង់បិទប្រព័ន្ធមែនឬទេ?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "បិទប្រព័ន្ធ..!") = MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub PrintSetupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogOutMI.Click
        If LogOff = True Then
            If MsgBox("តើអ្នកចង់ប្តូរអ្នកប្រើប្រាស់មែនឬទេ?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "ប្តូរអ្នកប្រើប្រាស់..!") = MsgBoxResult.Yes Then
                LogIn.Show()
                For Each ChildForm As Form In Me.MdiChildren
                    ChildForm.Close()
                Next
                LogOff = False
                Me.Close()
            End If
        End If
    End Sub

    Public userPinDt As String
    Public userOldPin As String
    Private Sub tsmChangePwd_Click(sender As Object, e As EventArgs) Handles ChangePasswordMenuItem.Click
        With User_ChangePWD

            Dim sqlStr As String = "select * from tswa_user_pin_master where user_id='" & loginName & "'"

            Dim tbl As DataTable = dbhpr.SelectData(sqlStr)
            If tbl.Rows.Count > 0 Then
                userOldPin = tbl.Rows(0)("USER_PIN")
                userPinDt = tbl.Rows(0)("PIN_DATE")
                .txtFullname.Text = tbl.Rows(0)("USER_NAME")
                .txtname.Text = loginName
            Else
                MsgBox("មិនមានអ្នកប្រើប្រាស់ដើម្បីប្តូរទេ!")
                Exit Sub
            End If
            .ShowDialog()
            If .DialogResult = System.Windows.Forms.DialogResult.OK Then
                Dim userNewPin As String = logdb.encodePin(.txtNewPWD.Text, Format(Now.Date, "dd/MM/yyyy"))

                dbhpr.ExecProc("upd_TWSA_USER_PIN_MASTER", "PI_USER_ID", loginName, "PI_USER_PIN", userNewPin, "PI_PIN_DATE", Format(Now.Date, "dd/MM/yyyy"))

                MsgBox("ការប្តូរលេខសម្ងាត់បានជោកជ័យ!")
            End If
            .Close()
        End With
    End Sub

    Private Sub TsmSchMgt_Click(sender As Object, e As EventArgs) Handles SchoolMI.Click
        With frm_sale_inv
            .MdiParent = Me
            .WindowState = FormWindowState.Maximized
            .Show()
        End With
    End Sub

    Private Sub TsmSchBuilding_Click(sender As Object, e As EventArgs)
        'With FrmSchoolBuilding
        '    .MdiParent = Me
        '    .WindowState = FormWindowState.Maximized
        '    .Show()
        'End With
    End Sub

    Private Sub TsmSchClass_Click(sender As Object, e As EventArgs)
        'With FrmSchoolClasses
        '    .MdiParent = Me
        '    .WindowState = FormWindowState.Maximized
        '    .Show()
        'End With
    End Sub

    Private Sub tsmSubject_Click(sender As Object, e As EventArgs)
        'With FrmSubjects
        '    .MdiParent = Me
        '    .WindowState = FormWindowState.Maximized
        '    .Show()
        'End With
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        'With FrmSubToClass
        '    .MdiParent = Me
        '    .WindowState = FormWindowState.Maximized
        '    .Show()
        'End With
    End Sub

    Private Sub tsmStudentList_Click(sender As Object, e As EventArgs)
        'With FrmStudents
        '    .MdiParent = Me
        '    .WindowState = FormWindowState.Maximized
        '    .Show()
        'End With
    End Sub

    Private Sub tsmStuToCls_Click(sender As Object, e As EventArgs)
        'With FrmStudentToClass
        '    .MdiParent = Me
        '    .WindowState = FormWindowState.Maximized
        '    .Show()
        'End With
    End Sub

    Private Sub msPrintExamList_Click(sender As Object, e As EventArgs)
        'With FrmExamList
        '    .MdiParent = Me
        '    .WindowState = FormWindowState.Maximized
        '    .Show()
        'End With
    End Sub

    Private Sub msExamList_Click(sender As Object, e As EventArgs)
        'With FrmStudentExamScore
        '    .MdiParent = Me
        '    .WindowState = FormWindowState.Maximized
        '    .Show()
        'End With
    End Sub

    Private Sub tbtnGenStudentList_Click(sender As Object, e As EventArgs)
        'With FrmGenRptStudentByClass
        '    Dim sqlStr As String = "select sch_num,sch_nm_kh from tswa_schools where stat_code='A' order by sch_num"
        '    Dim tbls As DataTable = dbhpr.SelectData(sqlStr, "Schools")
        '    .cboSchoolNum.DataSource = tbls
        '    .cboSchoolNum.ValueMember = "sch_num"
        '    .cboSchoolNum.DisplayMember = "sch_nm_kh"

        '    sqlStr = "select fld_valu,f.fld_valu_desc_kh from tswa_field_values f where f.fld_nm='CADE_CODE' and f.status='A' order by f.seq_num"
        '    Dim tblYr As DataTable = dbhpr.SelectData(sqlStr, "Classes")
        '    .cboYear.DataSource = tblYr
        '    .cboYear.ValueMember = "fld_valu"
        '    .cboYear.DisplayMember = "fld_valu_desc_kh"

        '    sqlStr = "select fld_valu,f.fld_valu_desc_kh from tswa_field_values f where f.fld_nm='CLS_CODE' and f.status='A' order by f.seq_num"
        '    Dim tblc As DataTable = dbhpr.SelectData(sqlStr, "Classes")
        '    .cboClassNum.DataSource = tblc
        '    .cboClassNum.ValueMember = "fld_valu"
        '    .cboClassNum.DisplayMember = "fld_valu_desc_kh"

        '    .ShowDialog()
        '    .Close()
        'End With
    End Sub

    Private Sub tbtnPrintStudetByCls_Click(sender As Object, e As EventArgs)
        'With FrmGenRptStudentByClass1
        '    Dim sqlStr As String = "select sch_num,sch_nm_kh from tswa_schools where stat_code='A' order by sch_num"
        '    Dim tbls As DataTable = dbhpr.SelectData(sqlStr, "Schools")
        '    .cboSchoolNum.DataSource = tbls
        '    .cboSchoolNum.ValueMember = "sch_num"
        '    .cboSchoolNum.DisplayMember = "sch_nm_kh"

        '    sqlStr = "select fld_valu,f.fld_valu_desc_kh from tswa_field_values f where f.fld_nm='CADE_CODE' and f.status='A' order by f.seq_num"
        '    Dim tblYr As DataTable = dbhpr.SelectData(sqlStr, "Classes")
        '    .cboYear.DataSource = tblYr
        '    .cboYear.ValueMember = "fld_valu"
        '    .cboYear.DisplayMember = "fld_valu_desc_kh"

        '    sqlStr = "select fld_valu,f.fld_valu_desc_kh from tswa_field_values f where f.fld_nm='CLS_CODE' and f.status='A' order by f.seq_num"
        '    Dim tblc As DataTable = dbhpr.SelectData(sqlStr, "Classes")
        '    .cboClassNum.DataSource = tblc
        '    .cboClassNum.ValueMember = "fld_valu"
        '    .cboClassNum.DisplayMember = "fld_valu_desc_kh"

        '    .ShowDialog()
        '    .Close()
        'End With
    End Sub

    Private Sub tbtnExamResult_Click(sender As Object, e As EventArgs)
        'With FrmExamResult
        '    .MdiParent = Me
        '    .WindowState = FormWindowState.Maximized
        '    .Show()
        'End With
    End Sub

    Private Sub tmsAcademicYr_Click(sender As Object, e As EventArgs)
        'With FrmAcademicYr
        '    .MdiParent = Me
        '    .WindowState = FormWindowState.Maximized
        '    .Show()
        'End With
    End Sub

    Private Sub tbtnSemtrResult_Click(sender As Object, e As EventArgs)
        'With FrmSemtrRsltList
        '    .MdiParent = Me
        '    .WindowState = FormWindowState.Maximized
        '    .Show()
        'End With
    End Sub

    Private Sub tsmAtt_Click(sender As Object, e As EventArgs)
        'With FrmStudentAtt
        '    .MdiParent = Me
        '    .WindowState = FormWindowState.Maximized
        '    .Show()
        'End With
    End Sub

    Private Sub GroupAndAccessRole_Click(sender As Object, e As EventArgs) Handles GroupAndAccessRoleMI.Click
        'With User_GroupMgr
        '    .MdiParent = Me
        '    .WindowState = FormWindowState.Maximized
        '    .Show()
        'End With
    End Sub

    Private Sub MasterFRM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If loginName.ToUpper = "ADMIN" Then
            Exit Sub
        End If

        'check control
        Dim ctrName As String = "FileMenu" ''tmsRoomList"
        Dim c As ToolStripMenuItem
        Dim sqlUserFcn As String = ""
        Dim tblUserFcn As DataTable = Nothing
        Dim tbl As DataTable = Nothing
        For Each c In MenuStrip1.Items
            For i As Int16 = 0 To c.DropDownItems.Count - 1
                '==>> Visible if user not allow access
                If c.DropDownItems(i).GetType().FullName <> "System.Windows.Forms.ToolStripSeparator" Then
                    sqlUserFcn = "select ctl_nm  from vw_user_access_list uf where lower(uf.user_id)='" & loginName & "' and lower(uf.ctl_parent_nm)='" & c.Name.ToUpper & "'  and uf.ctl_nm='" & c.DropDownItems(i).Name.ToUpper & "' "
                    tblUserFcn = dbhpr.SelectData(sqlUserFcn, "User Allow access function")
                    If tblUserFcn.Rows.Count = 0 Then
                        c.DropDownItems(i).Visible = False
                    End If
                End If
            Next
            '<<==Visible if user not allow access
        Next
    End Sub

    Private Sub បពមភសវភសកខរគរកToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'With FrmYearlyRslt
        '    .MdiParent = Me
        '    .WindowState = FormWindowState.Maximized
        '    .Show()
        'End With
    End Sub
End Class
