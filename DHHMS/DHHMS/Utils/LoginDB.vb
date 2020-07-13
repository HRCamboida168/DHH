Imports System.Data.SqlClient
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public Class LoginDB

    Dim dbHpr As New db_helper

    Dim Objcn As DBSingle
    Dim cn As SqlConnection

    Public Function GetFileContents(ByVal FullPath As String, Optional ByRef ErrInfo As String = "") As String
        Dim strContents As String = ""
        Dim objReader As StreamReader
        Try

            objReader = New StreamReader(FullPath)
            strContents = objReader.ReadToEnd()
            objReader.Close()

        Catch Ex As Exception
            ErrInfo = Ex.Message
        End Try
        Return strContents
    End Function
    Public Function SaveTextToFile(ByVal strData As String, ByVal FullPath As String, Optional ByVal ErrInfo As String = "") As Boolean
        Dim bAns As Boolean = False
        Dim objReader As StreamWriter
        Try
            objReader = New StreamWriter(FullPath)
            objReader.Write(strData)
            objReader.Close()
            bAns = True
        Catch Ex As Exception
            ErrInfo = Ex.Message
        End Try
        Return bAns
    End Function

    Public Function pwddecryption(ByVal text As String)
        Dim strtempchar As String = ""
        Dim str As String = ""
        Dim i As Integer
        For i = 1 To Len(text)
            If i Mod 2 <> 0 Then
                str = str & Mid$(text, i, 1)
            End If
        Next i

        For j As Integer = 1 To Len(str)
            If Asc(Mid$(str, j, 1)) < 128 Then
                strtempchar = CType(Asc(Mid$(str, j, 1)) + 128, String)
            ElseIf Asc(Mid$(str, j, 1)) > 128 Then
                strtempchar = CType(Asc(Mid$(str, j, 1)) - 128, String)
            End If

            Mid$(str, j, 1) = Chr(CType(strtempchar, Integer))
        Next

        Return str
    End Function

    Private Function encodePinMd5(p_pin As String, p_pin_dt As String) As String
        Using hasher As MD5 = MD5.Create()    ' create hash object

            Dim oriPin As String = p_pin & p_pin_dt

            ' Convert to byte array and get hash
            Dim dbytes As Byte() =
                 hasher.ComputeHash(Encoding.UTF8.GetBytes(oriPin))

            ' sb to create string from bytes
            Dim sBuilder As New StringBuilder()

            ' convert byte data to hex string
            For n As Integer = 0 To dbytes.Length - 1
                sBuilder.Append(dbytes(n).ToString("X2"))
            Next n

            Return sBuilder.ToString()
        End Using

    End Function

    Public Function encodePin(p_pin As String, p_pinDt As String) As String
        Dim Pin As String
        Pin = encodePinMd5(p_pin, p_pinDt)

        Return Pin
    End Function

    Public Sub validatePin(userId As String, userPin As String, ByRef errMsg As ErrMsg)

        Dim userData As New UserData

        If userId.Trim.ToString = "" Then
            errMsg.ErrCode = "12"
            errMsg.ErrMsg = "Please input User to login!!!"
            errMsg.Err_dt = Now
            Exit Sub

        End If

        If userPin.Trim.ToString = "" Then
            errMsg.ErrCode = "13"
            errMsg.ErrMsg = "Please input your Pin to login!!!"
            errMsg.Err_dt = Now
            Exit Sub

        End If

        Try

            'get User info
            Dim dt As DataTable = dbHpr.SelectData("select * from tswa_user_pin_master where USER_ID='" & userId & "'")
            If dt.Rows.Count = 0 Then
                errMsg.ErrCode = "01"
                errMsg.ErrMsg = "User Not Exist!!!"
                errMsg.Err_dt = Now
                Exit Sub

            Else
                userData.FAIL_ATTEMPTS = dt.Rows(0)("FAIL_ATTEMPTS").ToString
                userData.LAST_FAIL_TRY = dt.Rows(0)("LAST_FAIL_TRY")
                userData.PIN_ACTIVATED = dt.Rows(0)("PIN_ACTIVATED")
                userData.PIN_DATE = dt.Rows(0)("PIN_DATE")
                userData.IS_LOCKED = dt.Rows(0)("IS_LOCKED")
                userData.IS_LOGINED = dt.Rows(0)("IS_LOGINED")
                userData.PIN_STATUS = dt.Rows(0)("PIN_STATUS")
                userData.USR_ROLE = dt.Rows(0)("USR_ROLE")
                userData.USER_PIN = dt.Rows(0)("USER_PIN")

                If String.Compare(userData.IS_LOCKED, "Y") = 0 Then
                    errMsg.ErrCode = "02"
                    errMsg.ErrMsg = "Your account is locked! Please contact to system admin!!!"
                    errMsg.Err_dt = Now

                    Exit Sub
                End If

                If userData.FAIL_ATTEMPTS >= 5 Then
                    errMsg.ErrCode = "04"
                    errMsg.ErrMsg = "Fail attemp reach max allow, please contact system admin!!!"
                    errMsg.Err_dt = Now
                    Exit Sub
                End If

                '
                Dim cmd As SqlClient.SqlCommand
                Dim pinEncode As String = encodePin(userPin, userData.PIN_DATE)
                If String.Compare(pinEncode, userData.USER_PIN) <> 0 Then
                    errMsg.ErrCode = "05"
                    errMsg.ErrMsg = "User Attempt login is failed!!!"
                    errMsg.Err_dt = Now

                    dbHpr.ExecProc("INS_tswa_trxn_logs", "pi_user_id", userId, "pi_trxn_cd", errMsg.ErrCode, "pi_trxn_dt", errMsg.Err_dt)

                    Objcn = DBSingle.GetInstance
                    cn = Objcn.GetConnection

                    cmd = New SqlCommand("update  tswa_user_pin_master  set FAIL_ATTEMPTS=FAIL_ATTEMPTS+1 where USER_ID=@user_id", cn)
                    cmd.CommandType = CommandType.Text
                    dbHpr.CreatePar(cmd, "user_id", userId)
                    cmd.ExecuteNonQuery()

                    Exit Sub

                End If

                'successful
                errMsg.ErrCode = "00"
                errMsg.ErrMsg = "User Login Successfully!!!"
                errMsg.Err_dt = Now

                'save Log
                dbHpr.ExecProc("INS_tswa_trxn_logs", "pi_user_id", userId, "pi_trxn_cd", errMsg.ErrCode, "pi_trxn_dt", errMsg.Err_dt)

                Objcn = DBSingle.GetInstance
                cn = Objcn.GetConnection

                cmd = New SqlCommand("update  tswa_user_pin_master  set FAIL_ATTEMPTS=0 where USER_ID=@user_id", cn)
                cmd.CommandType = CommandType.Text
                dbHpr.CreatePar(cmd, "user_id", userId)
                cmd.ExecuteNonQuery()

            End If
        Catch ex As Exception
            errMsg.ErrCode = "999999"
            errMsg.ErrMsg = ex.Message.ToString
            errMsg.Err_dt = Now
        End Try
    End Sub

End Class
