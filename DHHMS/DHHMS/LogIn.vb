Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports System.Windows.Forms

Public Class LogIn

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Dim FUSERINFO As String = ""
    Dim FCON, BUSER As String
    Dim O_DBID As String = ""
    Dim uname As String = "Admin"
    Dim upwd As String = "Baglder@13992"
    Dim R_user As String

    'Dim dbSingData As New DBSingleData
    Dim dbHper As New db_helper
    Dim logDb As New LoginDB

    Dim Objcn As DBSingle
    Dim cn As SqlConnection

    Dim DbConStr As String = ""

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

        Dim errMsg As New ErrMsg
            logDb.validatePin(txtuser.Text, txtpassword.Text, errMsg)
        If String.Compare(errMsg.ErrCode, "00") = 0 Then
            MasterFRM.loginName = txtuser.Text
            MasterFRM.Show()
            Me.Close()
        Else
            MessageBox.Show(errMsg.ErrMsg)
        End If

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub ComboBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpassword.GotFocus
        AcceptButton = OK
    End Sub

    Private Sub ComboBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtpassword.LostFocus
        AcceptButton = Nothing
    End Sub
    Private Sub UsernameTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtuser.KeyPress
        If e.KeyChar = Chr(13) Then SelectNextControl(sender, True, True, True, True)
    End Sub

    Private Sub LogIn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor
            FUSERINFO = Path.Combine(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData, "userinfo.inf")
            'Connection string
            FCON = Path.Combine(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData, "support.dll")
            If File.Exists(FCON) Then
                Dim FS As New FileStream(FCON, FileMode.Open)
                Dim FR As New BinaryReader(FS, Encoding.Unicode)
                Dim I, J As Integer
                Dim B As Byte()
                J = FR.ReadBytes(10000).Length
                FR.Close()
                FS.Close()
                Dim FS1 As New FileStream(FCON, FileMode.Open)
                Dim FR1 As New BinaryReader(FS1, Encoding.Unicode)
                B = FR1.ReadBytes(J)
                For I = 0 To J - 1 Step 8
                    DbConStr = DbConStr + Chr(Convert.ToInt32(B(I)) - 10)
                Next
                Dim X As Object = DbConStr.Split(";")
                MasterFRM.dbDatasource = X(0).split("=")(1)
                MasterFRM.dbName = X(1).split("=")(1)
                MasterFRM.dbUser = X(2).split("=")(1)
                MasterFRM.dbPwd = X(3).split("=")(1)



                FR1.Close()
                FS1.Close()
            Else
                DbConStr = "server=(LOCAL);database=SGMSDB;user id=sa;password=Forte123"
            End If
            'cn.ConnectionString = DbConStr
AA:
            Try
                'cn.Open()

                Objcn = DBSingle.GetInstance
                cn = Objcn.GetConnection

            Catch ex As Exception
                If MsgBox("Connection failed:" & vbCrLf & " Do you want to retry connect again?", MsgBoxStyle.Question + MsgBoxStyle.RetryCancel + MsgBoxStyle.DefaultButton1, "Connection Problem") = MsgBoxResult.Retry Then
                    GoTo AA
                Else
                    If frmCon.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                    Else
                        End
                    End If
                End If
            End Try
            'get user 
            Dim fr_user As String = Path.Combine(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData, "r_user.txt")
            If File.Exists(fr_user) Then
                Dim strR As String = logDb.GetFileContents(fr_user)

                Dim X As Object = strR.Split(";")
                txtuser.Text = X(0).split("=")(1)
                txtpassword.Text = IIf(X(1).split("=")(1).ToString.Trim <> "", logDb.pwddecryption(X(1).split("=")(1)), "")

            End If

            Dim pin As String = logDb.encodePin(upwd, Format(Now.Date, "dd/MM/yyyy"))
            'save build -in user
            Dim err_msg As String
            err_msg = dbHper.ExecStored("INS_TWSA_USER_PIN_MASTER", "err_msg",
                                        "PI_USER_ID", uname,
                                        "PI_USER_PIN", pin,
                                        "PI_FAIL_ATTEMPTS", 0,
                                        "PI_LAST_FAIL_TRY", Now.Date,
                                        "PI_PIN_REMINDER", "Admin",
                                        "PI_LAST_LOGIN_DT", Now,
                                        "PI_LAST_LOGIN_STATUS", "N",
                                        "PI_PIN_ACTIVATED", "Y",
                                        "PI_PIN_DATE", Format(Now.Date, "dd/MM/yyyy"),
                                        "PI_IS_LOCKED", "N",
                                        "PI_IS_LOGINED", "N",
                                        "PI_USER_NAME", "Administrator",
                                        "PI_PIN_STATUS", "Y",
                                        "PI_PIN_STATUS_LUD", DBNull.Value,
                                        "PI_USER_STATUS", "A",
                                        "PI_LUCKY_NUM", "99",
                                        "PI_BIRTH_DT", Now.Date,
                                        "PI_USR_ROLE", "Admin")


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Cursor = Cursors.Default
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

End Class
