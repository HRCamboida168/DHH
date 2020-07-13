Public Class ErrMsg
    Private _userId As String
    Private _errCode As String
    Private _errMsg As String
    Private _fcnName As String
    Private _err_dt As DateTime

    Public Sub New()
        Me._userId = Nothing
        Me._errCode = Nothing
        Me._errMsg = Nothing
        Me._fcnName = Nothing
        Me._err_dt = Nothing
    End Sub
    Public Sub New(_userId As String, _errCode As String, _errMsg As String, _fcnName As String, _err_dt As Date)
        Me._userId = _userId
        Me._errCode = _errCode
        Me._errMsg = _errMsg
        Me._fcnName = _fcnName
        Me._err_dt = _err_dt
    End Sub
    Public Property UserId As String
        Get
            Return _userId
        End Get
        Set(value As String)
            _userId = value
        End Set
    End Property
    Public Property ErrCode As String
        Get
            Return _errCode
        End Get
        Set(value As String)
            _errCode = value
        End Set
    End Property

    Public Property ErrMsg As String
        Get
            Return _errMsg
        End Get
        Set(value As String)
            _errMsg = value
        End Set
    End Property

    Public Property FcnName As String
        Get
            Return _fcnName
        End Get
        Set(value As String)
            _fcnName = value
        End Set
    End Property

    Public Property Err_dt As Date
        Get
            Return _err_dt
        End Get
        Set(value As Date)
            _err_dt = value
        End Set
    End Property
End Class
