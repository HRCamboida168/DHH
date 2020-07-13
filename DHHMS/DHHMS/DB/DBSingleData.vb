Public Class DBSingleData
    Private _dbUser As String
    Private _dbPwd As String
    Private _dbPath As String
    Private _dbDatasource As String
    Private _dbName As String
    Private _dbConnSuf As String
    Private _loginName As String

    Public Property DbUser As String
        Get
            Return _dbUser
        End Get
        Set(value As String)
            _dbUser = value
        End Set
    End Property

    Public Property DbPwd As String
        Get
            Return _dbPwd
        End Get
        Set(value As String)
            _dbPwd = value
        End Set
    End Property

    Public Property DbPath As String
        Get
            Return _dbPath
        End Get
        Set(value As String)
            _dbPath = value
        End Set
    End Property

    Public Property DbDatasource As String
        Get
            Return _dbDatasource
        End Get
        Set(value As String)
            _dbDatasource = value
        End Set
    End Property

    Public Property DbName As String
        Get
            Return _dbName
        End Get
        Set(value As String)
            _dbName = value
        End Set
    End Property

    Public Property DbConnSuf As String
        Get
            Return _dbConnSuf
        End Get
        Set(value As String)
            _dbConnSuf = value
        End Set
    End Property

    Public Property LoginName As String
        Get
            Return _loginName
        End Get
        Set(value As String)
            _loginName = value
        End Set
    End Property


End Class
