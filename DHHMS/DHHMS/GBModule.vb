Imports System.Reflection
Imports Microsoft.Reporting.WinForms

Module GBModule
    Public Function ReturnImage(ByVal picbox As PictureBox) As Byte()
        If picbox.Image Is Nothing Then
            Return Nothing
        End If
        Dim ms As New System.IO.MemoryStream
        picbox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
        Dim bytBLOBData(ms.Length - 1) As Byte
        ms.Position = 0
        ms.Read(bytBLOBData, 0, ms.Length)
        Return bytBLOBData
    End Function

    Public Sub ShowImage(ByVal id As String, ByVal picbox As PictureBox)
        On Error Resume Next
        'Dim cmd As New SqlClient.SqlCommand("select_picture", cn)
        'cmd.CommandTimeout = 0
        'cmd.CommandType = CommandType.StoredProcedure
        'CreatePar(cmd, "id", id)
        'If IsDBNull(cmd.ExecuteScalar()) Then
        '    picbox.Image = Nothing
        'Else
        '    Dim byt() As Byte = cmd.ExecuteScalar
        '    Dim stm As New System.IO.MemoryStream(byt)
        '    picbox.Image = Image.FromStream(stm)
        'End If
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

    Public Function isDate(valDt As String)
        Try
            Dim dt As Date
            dt = valDt

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function nvl(val As Object)
        Try
            If val = DBNull.Value Then
                Return ""
            Else
                Return val
            End If
        Catch ex As Exception
            Return ""
        End Try

    End Function
    Public Sub CreatePar(ByRef cmd As SqlClient.SqlCommand, ByVal ParamArray par() As Object)
        cmd.CommandTimeout = 900
        Dim i As Integer
        For i = 0 To UBound(par) Step 2
            cmd.Parameters.AddWithValue("@" & par(i), par(i + 1))
        Next
    End Sub

    Public Function ObjectToDataTable(ByRef UniqueObject) As DataTable
        Dim dt As New DataTable
        Try
            Dim type As Type = UniqueObject.GetType()

            For Each p In type.GetProperties
                If p.MemberType.Equals(MemberTypes.Property) Then
                    Dim dc As New DataColumn
                    dc.ColumnName = p.Name

                    If (p.PropertyType.Name.Contains("Nullable")) Then
                        dc.DataType = Nullable.GetUnderlyingType(p.PropertyType)
                    Else
                        dc.DataType = p.PropertyType
                    End If

                    dt.Columns.Add(dc)
                End If
            Next

            Dim l As New List(Of Object)
            For Each c As DataColumn In dt.Columns
                Dim v = type.GetProperty(c.ColumnName).GetValue(UniqueObject, Nothing)
                l.Add(v)
            Next
            dt.Rows.Add(l.ToArray())

        Catch ex As Exception
            Throw ex
        End Try
        Return dt

    End Function

    Public Function ListToDataTable(ByRef dataList As IList) As DataTable
        Dim dt As New DataTable
        Try
            Dim firstObject = dataList(0)
            'Dim ab As Assembly = Assembly.Load(firstObject.GetType().Namespace)
            'Dim type As Type = ab.GetType(firstObject.GetType().Name)
            Dim type As Type = firstObject.GetType()

            'For Each p In type.GetProperties
            '    If p.MemberType.Equals(MemberTypes.Property) And Not p.PropertyType.IsGenericType Then
            '        dt.Columns.Add(p.Name, p.PropertyType)
            '    End If
            'Next
            dt = ObjectToDataTable(firstObject)

            dt.Rows.Clear()

            For Each d In dataList
                Dim l As New List(Of Object)
                For Each c As DataColumn In dt.Columns
                    Dim v = type.GetProperty(c.ColumnName).GetValue(d, Nothing)
                    l.Add(v)
                Next
                dt.Rows.Add(l.ToArray())
            Next
        Catch ex As Exception
            Throw ex
        End Try
        Return dt

    End Function

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
    Public Function CountGridBy(ByVal dtg As DataGridView, ByVal sumcol As Integer, ByVal ParamArray CondiAndCol() As Object) As Integer
        Dim s As Integer, r As DataGridViewRow, cond As Boolean = False, i As Integer = 0
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
                s += 1
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
    Public Function CountGridBy(ByVal dtg As DataGridView, ByVal ParamArray CondiAndCol() As Object) As Integer
        Dim s As Integer, r As DataGridViewRow, cond As Boolean = False, i As Integer = 0
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
                s += 1
            End If
        Next
        Return s
    End Function
    Public Sub UpdateToGrid(ByRef DGV As DataGridView, ByVal ParamArray Value() As String)
        Dim dg As DataGridViewRow = DGV.SelectedRows(0)
        dg.Cells(0).Value = Trim(Value(0))
        Dim i As Integer = 1
        For i = 1 To UBound(Value)
            dg.Cells(i).Value = Value(i)
        Next
        DGV.Focus()
    End Sub
    Public Sub cleartexbox(ByVal f As Form)
        Dim c As Control
        For Each c In f.Controls
            If TypeOf c Is TextBox Then
                c.Text = ""
            End If

        Next
    End Sub
    Public Sub clearTextBoxInGroup(ByVal f As GroupBox)
        Dim c As Control
        For Each c In f.Controls
            If TypeOf c Is TextBox Then
                c.Text = ""
            End If
        Next
    End Sub

    Public Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

End Module
