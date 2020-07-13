Imports System.Data.SqlClient

Public Class User_GroupMgr

    Dim dbHpr As New db_helper
    Dim logDb As New LoginDB
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Me.Close()
    End Sub
    Public chd As Boolean = False
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnCreate.Click
        With userGroupProfile
            .ShowDialog()
            If .DialogResult = System.Windows.Forms.DialogResult.OK Then
                dbHpr.ExecProc("tuser_group_profiles_ins", "grp_num", .txtgrpNum.Text, "grp_nm", .txtGrpNm.Text, "grp_desc", .txtDesc.Text)
                dgGrpProf.Rows.Add(.txtgrpNum.Text, .txtGrpNm.Text, .txtDesc.Text, "A")
            End If
            .Close()
            .Dispose()
        End With
    End Sub

    Private Sub User_MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If MasterFRM.loginName.ToUpper <> "ADMIN" Then
            tstbtnGenMenu.Visible = False
        End If
        Dim str As String = "select * from tuser_group_profiles "
        Dim tbl As DataTable = dbHpr.SelectData(str, "USER")
        dgGrpProf.Rows.Clear()
        For Each R As DataRow In tbl.Rows
            dgGrpProf.Rows.Add(R(0), R(1), R(2), R(3))
        Next

    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnEdit.Click

        If dgGrpProf.SelectedRows.Count = 0 Then
            MsgBox("There is no group profile to disable!", MsgBoxStyle.Information, "group profile")
            Exit Sub
        End If
        If MsgBox("Are you sure you want to disable group profile?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            dbHpr.ExecProc("tuser_group_profiles_del", "grp_num", dgGrpProf.SelectedRows(0).Cells(0).Value)
            dgGrpProf.Rows.RemoveAt(dgGrpProf.SelectedRows(0).Index)

            MsgBox("Group profile is removed success!", MsgBoxStyle.Information, "Group profile")
        End If

    End Sub

    Private Sub tbtnChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbtnChange.Click
        If dgGrpMap.SelectedRows.Count > 0 Then
            If MsgBox("Are you sure you want To remove group grant access?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Remove Access") = MsgBoxResult.Yes Then
                dbHpr.ExecProc("tuser_group_profile_mappings_del_ctl", "grp_num", dgGrpProf.SelectedCells(0).Value, "ctl_nm", dgGrpMap.SelectedCells(0).Value)
                dgGrpMap.Rows.RemoveAt(dgGrpMap.SelectedRows(0).Index)
                MsgBox("Seccessfull!!!", MsgBoxStyle.Information, "Access role")
            End If
        End If
    End Sub

    Private Sub tbtnreset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnUser2Group.Click
        With userUser2Group
            'not grant access menus
            Dim sqlStr As String = "Select u.USER_ID, u.USER_NAME from tswa_user_pin_master u where u.user_id Not in(select user_id from tuser_group_mappings um where um.grp_num= '" & dgGrpProf.SelectedCells(0).Value & "') and lower(user_id)<>'admin';"
            Dim tbl As DataTable = dbHpr.SelectData(sqlStr, "GetMenu")
            .gvLeft.Rows.Clear()
            For Each r As DataRow In tbl.Rows
                .gvLeft.Rows.Add(r(0), r(1))
            Next
            'granted access menus
            sqlStr = "select u.USER_ID,u.USER_NAME from tuser_group_mappings um ,tswa_user_pin_master u where u.USER_ID=um.user_id and um.grp_num='" & dgGrpProf.SelectedCells(0).Value & "';"
            tbl = dbHpr.SelectData(sqlStr, "GetMenu")
            .gvRight.Rows.Clear()
            For Each r As DataRow In tbl.Rows
                .gvRight.Rows.Add(r(0), r(1))
            Next
            .ShowDialog()
            If .DialogResult = System.Windows.Forms.DialogResult.OK Then
                'connection
                Dim Objcn As DBSingle
                Dim cn As SqlConnection
                Objcn = DBSingle.GetInstance
                cn = Objcn.GetConnection
                Dim Trans As SqlClient.SqlTransaction = cn.BeginTransaction
                Dim cmd As New SqlClient.SqlCommand("", cn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Transaction = Trans
                Try
                    Cursor = Cursors.WaitCursor
                    cmd.CommandText = "tuser_group_mappings_del"
                    CreatePar(cmd, "grp_num", dgGrpProf.SelectedCells(0).Value)
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()

                    'del old record
                    For i As Int16 = 0 To .gvRight.RowCount - 1
                        cmd.CommandText = "tuser_group_mappings_ins"
                        CreatePar(cmd, "user_id", .gvRight.Rows(i).Cells(0).Value, "grp_num", dgGrpProf.SelectedCells(0).Value)
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                    Next
                    Trans.Commit()
                    Cursor = Cursors.Default
                Catch ex As Exception
                    Cursor = Cursors.Default
                    Trans.Rollback()
                    MsgBox(ex.Message)
                    Exit Sub
                End Try
                MsgBox("successful granted!!!", MsgBoxStyle.Information, "Grant access menus")
            End If
            .Close()
            .Dispose()
        End With
    End Sub

    Private Sub dg1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub tsbEnableUser_Click(sender As Object, e As EventArgs) Handles tsbGrpProfMapping.Click
        With userGroupMapping
            'not grant access menus
            Dim sqlStr As String = "select ctl_nm,ctl_text,stat_cd from tgh_fcn_controls where stat_cd='A' and ctl_nm not in(select pm.ctl_nm from tuser_group_profile_mappings pm where pm.grp_num='" & dgGrpProf.SelectedCells(0).Value & "');"
            Dim tbl As DataTable = dbHpr.SelectData(sqlStr, "GetMenu")
            .gvLeft.Rows.Clear()
            For Each r As DataRow In tbl.Rows
                .gvLeft.Rows.Add(r(0), r(1), r(2))
            Next
            'granted access menus
            sqlStr = "select ctl_nm,ctl_text,stat_cd from tgh_fcn_controls where stat_cd='A' and ctl_nm in(select pm.ctl_nm from tuser_group_profile_mappings pm where pm.grp_num='" & dgGrpProf.SelectedCells(0).Value & "');"
            tbl = dbHpr.SelectData(sqlStr, "GetMenu")
            .gvRight.Rows.Clear()
            For Each r As DataRow In tbl.Rows
                .gvRight.Rows.Add(r(0), r(1), r(2))
            Next
            .ShowDialog()
            If .DialogResult = System.Windows.Forms.DialogResult.OK Then
                'connection
                Dim Objcn As DBSingle
                Dim cn As SqlConnection
                Objcn = DBSingle.GetInstance
                cn = Objcn.GetConnection
                Dim Trans As SqlClient.SqlTransaction = cn.BeginTransaction
                Dim cmd As New SqlClient.SqlCommand("", cn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Transaction = Trans
                Try
                    Cursor = Cursors.WaitCursor
                    cmd.CommandText = "tuser_group_profile_mappings_del"
                    CreatePar(cmd, "grp_num", dgGrpProf.SelectedCells(0).Value)
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()

                    'del old record
                    For i As Int16 = 0 To .gvRight.RowCount - 1
                        cmd.CommandText = "tuser_group_profile_mappings_ins"
                        CreatePar(cmd, "grp_num", dgGrpProf.SelectedCells(0).Value, "ctl_nm", .gvRight.Rows(i).Cells(0).Value)
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                    Next
                    Trans.Commit()
                    Cursor = Cursors.Default
                Catch ex As Exception
                    Cursor = Cursors.Default
                    Trans.Rollback()
                    MsgBox(ex.Message)
                    Exit Sub
                End Try
                MsgBox("Menus is successful granted!!!", MsgBoxStyle.Information, "Grant access menus")
            End If
            .Close()
            .Dispose()
        End With
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles tstbtnGenMenu.Click
        'check control
        Dim ctrName As String = "FileMenu" ''tmsRoomList"
        Dim c As ToolStripMenuItem
        Dim sqlStr As String = "select max(ctl_num) from tgh_fcn_controls"
        Dim sqlUserFcn As String = ""
        Dim tblUserFcn As DataTable = Nothing
        Dim ctl_num As String = ""
        Dim tbl As DataTable = Nothing
        Dim l_existM As Boolean
        Dim l_existMI As Boolean
        With MasterFRM
            For Each c In .MenuStrip1.Items
                'check if exis menu
                l_existM = dbHpr.Exists("select ctl_nm from tgh_fcn_controls where ctl_num='" & c.Name.ToUpper & "' and stat_cd='A'")
                If l_existM = False Then
                    'add Menu to control table
                    ctl_num = dbHpr.GenerateID(sqlStr, 4, "M")
                    dbHpr.ExecProc("tgh_fcn_controls_ins", "ctl_num", ctl_num, "ctl_nm", c.Name.ToUpper, "ctl_text", c.Text, "ctl_parent_nm", "", "ctl_typ", "P")
                End If
                For i As Int16 = 0 To c.DropDownItems.Count - 1
                    'add Sub() Menu to control table  
                    'check exis menuItem
                    l_existMI = dbHpr.Exists("select ctl_nm from tgh_fcn_controls where ctl_num='" & c.DropDownItems(i).Name.ToUpper & "' and stat_cd='A'")
                    If l_existMI = False Then
                        ctl_num = dbHpr.GenerateID(sqlStr, 4, "M")
                        If c.DropDownItems(i).GetType().FullName <> "System.Windows.Forms.ToolStripSeparator" Then
                            dbHpr.ExecProc("tgh_fcn_controls_ins", "ctl_num", ctl_num, "ctl_nm", c.DropDownItems(i).Name.ToUpper, "ctl_text", c.DropDownItems(i).Text, "ctl_parent_nm", c.Name.ToUpper, "ctl_typ", "C")
                        End If
                    End If
                Next
            Next
        End With

        MsgBox("Generate access list completed!!!", MsgBoxStyle.Information, "MenuAccess")
    End Sub

    Private Sub dgGrpProf_SelectionChanged(sender As Object, e As EventArgs) Handles dgGrpProf.SelectionChanged
        'group profile mapping
        Dim tblGrpProfMap As DataTable = dbHpr.SelectData("select ctl_nm,ctl_text from tgh_fcn_controls where stat_cd='A' and ctl_nm in(select pm.ctl_nm from tuser_group_profile_mappings pm where pm.grp_num='" & dgGrpProf.SelectedCells(0).Value & "');")
        dgGrpMap.Rows.Clear()
        For Each r As DataRow In tblGrpProfMap.Rows
            dgGrpMap.Rows.Add(r(0), r(1))
        Next

        'user group mapping
        Dim tblUserMap As DataTable = dbHpr.SelectData("select u.USER_ID,u.USER_NAME from tuser_group_mappings ug,tswa_user_pin_master u where ug.user_id=u.USER_ID and ug.grp_num='" & dgGrpProf.SelectedCells(0).Value & "'")
        dgGrpUserMap.Rows.Clear()
        For Each r As DataRow In tblUserMap.Rows
            dgGrpUserMap.Rows.Add(r(0), r(1))
        Next
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If dgGrpUserMap.SelectedRows.Count > 0 Then
            If MsgBox("Are you sure you want to remove user from group?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Remove User Access") = MsgBoxResult.Yes Then
                dbHpr.ExecProc("tuser_group_mappings_del_user", "grp_num", dgGrpProf.SelectedCells(0).Value, "user_id", dgGrpUserMap.SelectedCells(0).Value)
                dgGrpUserMap.Rows.RemoveAt(dgGrpUserMap.SelectedRows(0).Index)
                MsgBox("User romove Seccessfull!!!", MsgBoxStyle.Information, "Access role")
            End If
        End If
    End Sub

    Private Sub dgGrpProf_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgGrpProf.RowStateChanged

    End Sub
End Class
