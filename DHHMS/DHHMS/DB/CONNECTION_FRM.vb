Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports System.Windows.Forms

Public Class frmCon
    Dim Con As String
    Dim F As String

    Dim dbSingData As DBSingleData
    Dim Objcn As DBSingle
    Dim cn As SqlConnection
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            'If chbCon.Checked = False Then
            '    Con = "server=" & txtS.Text & ";database=" & txtD.Text & ";user id=" & txtU.Text & ";password=" & txtP.Text
            '    cn.ConnectionString = "server=" & txtS.Text & ";database=" & txtD.Text & ";user id=" & txtU.Text & ";password=" & txtP.Text
            'Else
            '    cn.ConnectionString = txtCon.Text
            '    Con = txtCon.Text
            'End If
            Con = "server=" & txtServerName.Text & ";database=" & txtDbName.Text & ";user id=" & txtDbUserId.Text & ";password=" & txtDbPwd.Text

            MasterFRM.dbDatasource = txtServerName.Text
            MasterFRM.dbName = txtDbName.Text
            MasterFRM.dbUser = txtDbUserId.Text
            MasterFRM.dbPwd = txtDbPwd.Text

            F = Path.Combine(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData, "support.dll")
            Dim FS As New FileStream(F, FileMode.Create)
            Dim FW As New BinaryWriter(FS, Encoding.Unicode)
            Dim B As Byte() = Encoding.Unicode.GetBytes(Con)
            Dim I As Int16
            For I = 0 To B.Length - 1
                FW.Write(Convert.ToInt32((B(I))) + 10)
            Next
            FW.Close()
            FS.Close()

            Dim dbHper As New db_helper

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'SamplesEncoding.Main()
    End Sub

    'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        F = Path.Combine(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData, "test.txt")
    '        Dim FS As New FileStream(F, FileMode.Open)
    '        Dim FR As New BinaryReader(FS, Encoding.Unicode)
    '        Dim S As String = ""
    '        Dim I, J As Integer
    '        Dim B As Byte()
    '        J = FR.ReadBytes(10000).Length
    '        FR.Close()
    '        FS.Close()
    '        Dim FS1 As New FileStream(F, FileMode.Open)
    '        Dim FR1 As New BinaryReader(FS1, Encoding.Unicode)
    '        B = FR1.ReadBytes(J)
    '        For I = 0 To J - 1 Step 8
    '            S = S + Chr(Convert.ToInt32(B(I)) - 10)
    '        Next
    '        txtS.Text = S
    '        FR1.Close()
    '        FS1.Close()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Application.Exit()
    End Sub


    Private Sub chbCon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCon.CheckedChanged
        GroupBox2.Enabled = chbCon.Checked
        If chbCon.Checked = True Then
            GroupBox1.Enabled = False
            txtCon.Focus()
        Else
            GroupBox1.Enabled = True
            txtServerName.Focus()
        End If
    End Sub

    Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click
        Try
            'If chbCon.Checked = False Then
            '    Con = "server=" & txtServerName.Text & ";database=" & txtDbName.Text & ";user id=" & txtDbUserId.Text & ";password=" & txtDbPwd.Text
            'Else
            '    Con = txtCon.Text
            'End If
            'Dim cn As New SqlClient.SqlConnection(Con)
            'cn.Open()
            MasterFRM.dbDatasource = txtServerName.Text
            MasterFRM.dbName = txtDbName.Text
            MasterFRM.dbUser = txtDbUserId.Text
            MasterFRM.dbPwd = txtDbPwd.Text


            Objcn = DBSingle.GetInstance
            cn = Objcn.GetConnection

            MsgBox("Test connection succeeded.", MsgBoxStyle.Information, "Connection..")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Connection..")
        End Try
    End Sub

    Private Sub txtS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtServerName.KeyPress, txtDbName.KeyPress, txtDbUserId.KeyPress, txtDbPwd.KeyPress, chbCon.KeyPress, txtCon.KeyPress
        If e.KeyChar = Chr(13) Then SelectNextControl(sender, True, True, True, True)
    End Sub

End Class
