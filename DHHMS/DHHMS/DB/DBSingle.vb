Imports System.Data.SqlClient

Public Class DBSingle
    Private Shared Obj_Db_con As DBSingle
    Private Shared Obj_con As SqlConnection

    'Dim dbSingleData As DBSingleData
    Dim conStr As String
    Protected Sub New()
        conStr = "server=" & MasterFRM.dbDatasource & ";database=" & MasterFRM.dbName & ";user id=" & MasterFRM.dbUser & ";password=" & MasterFRM.dbPwd & ";"
        Obj_con = New SqlConnection
        Obj_con.ConnectionString = conStr
        Obj_con.Open()

    End Sub

    Public Shared Function GetInstance() As DBSingle
        If Obj_Db_con Is Nothing Then
            Obj_Db_con = New DBSingle
        End If

        Return Obj_Db_con

    End Function

    Public ReadOnly Property GetConnection() As SqlConnection
        Get
            Return Obj_con

        End Get
    End Property
End Class
