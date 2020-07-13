Imports System.Data.SqlClient
Public Class db_helper
    '--sql connection
    Dim Objcn As DBSingle
    Dim cn As SqlConnection

    Public Sub ExecProc(ByRef Stored_Name As String, ByVal ParamArray Parameter() As Object)
        Objcn = DBSingle.GetInstance
        cn = Objcn.GetConnection

        Dim cmd As SqlCommand = cn.CreateCommand
        cmd.CommandTimeout = 900
        cmd.CommandText = Stored_Name
        cmd.CommandType = CommandType.StoredProcedure

        Dim i As Integer
        For i = 0 To UBound(Parameter) Step 2
            cmd.Parameters.AddWithValue("@" & Parameter(i), Parameter(i + 1))
        Next
        cmd.ExecuteNonQuery()
    End Sub

    Public Sub ShowImageStorProc(ByVal procName As String, ByVal picbox As PictureBox, ByVal ParamArray Parameter() As Object)
        On Error Resume Next
        Objcn = DBSingle.GetInstance
        cn = Objcn.GetConnection

        Dim cmd As SqlCommand = cn.CreateCommand
        cmd.CommandText = procName
        cmd.CommandType = CommandType.StoredProcedure

        Dim i As Integer
        For i = 0 To UBound(Parameter) Step 2
            cmd.Parameters.AddWithValue("@" & Parameter(i), Parameter(i + 1))
        Next

        If IsDBNull(cmd.ExecuteScalar()) Then
            picbox.Image = Nothing 'Image.FromFile(Application.StartupPath & "\No_Image.gif")
        Else
            Dim byt() As Byte = cmd.ExecuteScalar
            Dim stm As New System.IO.MemoryStream(byt)
            picbox.Image = Image.FromStream(stm)
        End If
    End Sub

    Public Function ExecStored(ByRef Stored_Name As String, ByVal OutputDirection As String, ByVal ParamArray Parameter() As Object) As String
        Dim ParName() As String = Nothing
        ParName = OutputDirection.Split(";")

        Objcn = DBSingle.GetInstance
        cn = Objcn.GetConnection

        Dim cmd As SqlCommand = cn.CreateCommand
        cmd.CommandTimeout = 900
        cmd.CommandText = Stored_Name
        cmd.CommandType = CommandType.StoredProcedure

        Dim i As Integer
        For i = 0 To UBound(Parameter) Step 2
            cmd.Parameters.AddWithValue("@" & Parameter(i), Parameter(i + 1))
        Next

        cmd.Parameters.Add("@" & OutputDirection, SqlDbType.NVarChar, 100)
        cmd.Parameters("@" & OutputDirection).Direction = ParameterDirection.Output
        'For i = 0 To ParName.Length - 1
        'cmd.Parameters.Add("@" & ParName(i), SqlDbType.NVarChar)
        'cmd.Parameters("@" & ParName(i)).Direction = ParameterDirection.Output
        'Next

        cmd.ExecuteNonQuery()

        Return cmd.Parameters("@" & OutputDirection).Value

    End Function


    Public Function ExecStored(ByRef Stored_Name As String, ByVal OutputDirection As String, ByVal NumericIndex As String, ByVal DECIMAL_PLACE As Integer, ByVal DECIMAL_SEP As String, ByVal THOUSAND_SEP As String, ByVal CON As SqlClient.SqlConnection, ByVal ParamArray Parameter() As Object) As SqlClient.SqlCommand
        Dim Index() As String = Nothing
        Dim ParName() As String = Nothing
        ParName = OutputDirection.Split(";")
        Index = NumericIndex.Split(";")

        Objcn = DBSingle.GetInstance
        cn = Objcn.GetConnection

        Dim Cmd As New SqlClient.SqlCommand(Stored_Name, CON)
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandTimeout = 900
        Dim i As Integer
        For i = 0 To UBound(Parameter) Step 2
            Cmd.Parameters.AddWithValue("@" & Parameter(i), Parameter(i + 1))
        Next
        For i = 0 To ParName.Length - 1
            Cmd.Parameters("@" & ParName(i)).Direction = ParameterDirection.Output
        Next
        For i = 0 To Index.Length - 1
            Cmd.Parameters(CInt(Index(i))).Value = FormatBackEnd(CStr(Cmd.Parameters(CInt(Index(i))).Value), DECIMAL_PLACE, DECIMAL_SEP, THOUSAND_SEP)
        Next
        Cmd.ExecuteNonQuery()
        Return Cmd

    End Function

    Public Function Exists(ByVal TblName As String, ByVal ParamArray FieldsAndValue() As Object) As Boolean
        Dim Str As String = "select top 1 * from " & TblName
        Dim i As Integer

        Objcn = DBSingle.GetInstance
        cn = Objcn.GetConnection

        Dim cmd As New SqlClient.SqlCommand("", cn)
        Dim adp As New SqlClient.SqlDataAdapter(cmd)
        Dim tbl As New DataTable
        If FieldsAndValue.Length > 0 Then
            Str = Str & " Where "
        End If
        For i = 0 To UBound(FieldsAndValue) Step 2
            Str = Str & FieldsAndValue(i).ToString & "=@" & FieldsAndValue(i).ToString & " AND "
            cmd.Parameters.AddWithValue("@" & FieldsAndValue(i).ToString, FieldsAndValue(i + 1).ToString)
        Next
        Str = Str.Substring(0, Str.Length - 5)
        cmd.CommandText = Str
        adp.Fill(tbl)
        If tbl.Rows.Count <> 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function Exists(ByVal SQLStr As String) As Boolean
        Objcn = DBSingle.GetInstance
        cn = Objcn.GetConnection

        Dim adp As New SqlClient.SqlDataAdapter(SQLStr, cn)
        Dim tbl As New DataTable
        adp.Fill(tbl)
        If tbl.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Function FormatBackEnd(ByVal Str As String, Optional ByVal DecimalPlace As Integer = 2, Optional ByVal DecimalSeparator As String = ".", Optional ByVal ThousandSeparator As String = ",") As Double
        Dim strfor As String = "#0"
        If DecimalPlace > 0 Then
            strfor = strfor & "."
        End If
        For i As Integer = 1 To DecimalPlace
            strfor = strfor + "0"
        Next

        Str = Str.Replace(ThousandSeparator, "")
        If DecimalSeparator <> "." Then
            Str = Str.Replace(DecimalSeparator, ".")
        End If
        If IsNumeric(Str) = False Then
            Str = "0"
        End If
        Return Format(CDbl(Str), strfor)
    End Function

    Public Function SelectData(ByVal SQLStr As String, Optional ByVal tablename As String = "") As DataTable
        Objcn = DBSingle.GetInstance
        cn = Objcn.GetConnection

        Dim cmd As New SqlClient.SqlCommand(SQLStr, cn)
        cmd.CommandTimeout = 900
        Dim dtp As New SqlClient.SqlDataAdapter(cmd)
        Dim dt As New DataTable
        dtp.Fill(dt)
        dt.TableName = tablename
        Return dt
    End Function

    Public Function SelectData(ByVal tablename As String, ByVal Proc_Name As String, ByVal ParamArray SQLPar() As Object) As DataTable
        Objcn = DBSingle.GetInstance
        cn = Objcn.GetConnection

        Dim cmd As New SqlClient.SqlCommand(Proc_Name, cn)
        cmd.CommandType = CommandType.StoredProcedure
        CreatePar(cmd, SQLPar)
        cmd.CommandTimeout = 900
        Dim dtp As New SqlClient.SqlDataAdapter(cmd)
        Dim dt As New DataTable
        dtp.Fill(dt)
        dt.TableName = tablename
        Return dt
    End Function

    Public Sub CreatePar(ByRef cmd As SqlClient.SqlCommand, ByVal ParamArray par() As Object)
        cmd.CommandTimeout = 900
        Dim i As Integer
        For i = 0 To UBound(par) Step 2
            cmd.Parameters.AddWithValue("@" & par(i), par(i + 1))
        Next
    End Sub

    Public Sub CreateParCn(ByRef cmd As SqlClient.SqlCommand, ByVal ParamArray par() As Object)
        Objcn = DBSingle.GetInstance
        cn = Objcn.GetConnection

        cmd.CommandTimeout = 900
        Dim i As Integer
        For i = 0 To UBound(par) Step 2
            cmd.Parameters.AddWithValue("@" & par(i), par(i + 1))
        Next
    End Sub

    Public Sub DeleteData(ByVal tablename As String, ByVal ParamArray Field_condi() As Object)
        Objcn = DBSingle.GetInstance
        cn = Objcn.GetConnection

        Dim Str As String = "DELETE FROM " & tablename
        Dim I As Integer
        Dim CMD As New SqlClient.SqlCommand("", cn)
        If Field_condi.Length > 0 Then
            Str = Str & " WHERE "
        End If
        For I = 0 To UBound(Field_condi) Step 2
            Str = Str & Field_condi(I).ToString & "=@" & Field_condi(I).ToString & " AND "
            CMD.Parameters.AddWithValue("@" & Field_condi(I).ToString, Field_condi(I + 1).ToString)
        Next
        Str = Str.Substring(0, Str.Length - 5)
        CMD.CommandText = Str

        CMD.ExecuteNonQuery()

    End Sub

    Public Function GenerateID(ByVal SQLStr As String, Optional ByVal Length As Integer = 0, Optional ByVal HeadStr As String = "") As String
        Objcn = DBSingle.GetInstance
        cn = Objcn.GetConnection

        Dim cmd As New SqlClient.SqlCommand(SQLStr, cn)
        cmd.CommandTimeout = 0
        Dim FormatStr As String = ""
        Dim i As Integer
        For i = 1 To Length
            FormatStr += "0"
        Next
        If IsDBNull(cmd.ExecuteScalar) Then
            Return HeadStr + Format(1, FormatStr)
        Else

            Dim id As Double = 0
            If Length = 0 Then
                id = CDbl(cmd.ExecuteScalar) + 1
            Else
                id = CDbl(Right(cmd.ExecuteScalar, Length)) + 1
            End If
            Return HeadStr + Format(id, FormatStr)
        End If
    End Function

    Public Function GenerateID(ByVal SQLStr As String, ByVal Length As Integer, ByVal PreStr As String, ByVal SufStr As String, ByVal StartN As Integer, Optional ByVal Interval As Integer = 1) As String

        Objcn = DBSingle.GetInstance
        cn = Objcn.GetConnection

        Dim cmd As New SqlClient.SqlCommand(SQLStr, cn)
        cmd.CommandTimeout = 0
        Dim FormatStr As String = ""
        Dim i As Integer
        For i = 1 To Length
            FormatStr += "0"
        Next
        If IsDBNull(cmd.ExecuteScalar) Then
            Return PreStr + Format(StartN, FormatStr) + SufStr
        Else
            Dim id As Double = 0
            If Length = 0 Then
                id = CDbl(cmd.ExecuteScalar) + Interval
            Else
                id = CDbl(cmd.ExecuteScalar.ToString.Substring(PreStr.Length, Length)) + Interval
            End If
            Return PreStr + Format(id, FormatStr) + SufStr
        End If
    End Function

    Public Sub NumericInput(ByVal e As Object, ByVal DECIMAL_SEPARATOR As String, ByVal THOUSAND_SEPARATOR As String, Optional ByVal IsMinusSign As Boolean = False)
        Dim MinusSign As String = "-"
        If IsMinusSign = False Then
            MinusSign = ""
        End If
        If (e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = DECIMAL_SEPARATOR Or e.KeyChar = Chr(8) Or e.keychar = THOUSAND_SEPARATOR Then
        Else
            e.Handled = True
        End If
    End Sub

    Public Sub NumericInput(ByVal e As Object, ByVal DECIMALorTHOUSAND_SEPARATOR As String, Optional ByVal IsMinusSign As Boolean = False)
        Dim MinusSign As String = "-"
        If IsMinusSign = False Then
            MinusSign = ""
        End If
        If (e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = Chr(8) Or e.keychar = DECIMALorTHOUSAND_SEPARATOR Or e.keychar = MinusSign Then
        Else
            e.Handled = True
        End If
    End Sub

    Public Sub NumericInput(ByVal e As Object, Optional ByVal IsMinusSign As Boolean = False)
        Dim MinusSign As String = "-"
        If IsMinusSign = False Then
            MinusSign = ""
        End If
        If (e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = Chr(8) Then
        Else
            e.Handled = True
        End If
    End Sub

    Public Function SumGrid(ByVal dtg As DataGridView, ByVal sumcol As Integer, ByVal ParamArray CondiAndCol() As Object) As Double
        Dim s As Double, r As DataGridViewRow, cond As Boolean = False, i As Integer = 0
        s = 0
        For Each r In dtg.Rows
            For i = 0 To CondiAndCol.Length - 1 Step 2
                If CondiAndCol(i) = r.Cells(CondiAndCol(i + 1)).Value Then
                    cond = True
                Else
                    cond = False
                    Exit For
                End If
            Next
            If cond = True Then
                s += CDbl(IIf(r.Cells(sumcol).Value.ToString = "", 0, r.Cells(sumcol).Value))
            End If
        Next
        Return s
    End Function

    Public Function SumGrid(ByVal dtg As DataGridView, ByVal sumcol As Integer) As Double
        Dim s As Double, r As DataGridViewRow
        s = 0
        For Each r In dtg.Rows
            s += CDbl(IIf(r.Cells(sumcol).Value.ToString = "", 0, r.Cells(sumcol).Value))
        Next
        Return s
    End Function

End Class

