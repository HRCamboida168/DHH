Public Class UserData
    Private _USER_ID As String
    Private _USER_PIN As String
    Private _FAIL_ATTEMPTS As Int16
    Private _LAST_FAIL_TRY As DateTime
    Private _PIN_REMINDER As String
    Private _LAST_LOGIN_DT As DateTime
    Private _LAST_LOGIN_STATUS As String
    Private _PIN_ACTIVATED As String
    Private _PIN_DATE As String
    Private _IS_LOCKED As String
    Private _IS_LOGINED As String
    Private _USER_NAME As String
    Private _PIN_STATUS As String
    Private _PIN_STATUS_LUD As DateTime
    Private _USER_STATUS As String
    Private _LUCKY_NUM As String
    Private _BIRTH_DT As DateTime
    Private _USR_ROLE As String

    Public Sub New()
        Me._USER_ID = Nothing
        Me._USER_PIN = Nothing
        Me._FAIL_ATTEMPTS = Nothing
        Me._LAST_FAIL_TRY = Nothing
        Me._PIN_REMINDER = Nothing
        Me._LAST_LOGIN_DT = Nothing
        Me._LAST_LOGIN_STATUS = Nothing
        Me._PIN_ACTIVATED = Nothing
        Me._PIN_DATE = Nothing
        Me._IS_LOCKED = Nothing
        Me._IS_LOGINED = Nothing
        Me._USER_NAME = Nothing
        Me._PIN_STATUS = Nothing
        Me._PIN_STATUS_LUD = Nothing
        Me._USER_STATUS = Nothing
        Me._LUCKY_NUM = Nothing
        Me._BIRTH_DT = Nothing
        Me._USR_ROLE = Nothing
    End Sub

    Public Sub New(_USER_ID As String, _USER_PIN As String, _FAIL_ATTEMPTS As Short, _LAST_FAIL_TRY As Date, _PIN_REMINDER As String, _LAST_LOGIN_DT As Date, _LAST_LOGIN_STATUS As String, _PIN_ACTIVATED As String, _PIN_DATE As String, _IS_LOCKED As String, _IS_LOGINED As String, _USER_NAME As String, _PIN_STATUS As String, _PIN_STATUS_LUD As Date, _USER_STATUS As String, _LUCKY_NUM As String, _BIRTH_DT As Date, _USR_ROLE As String)
        Me._USER_ID = _USER_ID
        Me._USER_PIN = _USER_PIN
        Me._FAIL_ATTEMPTS = _FAIL_ATTEMPTS
        Me._LAST_FAIL_TRY = _LAST_FAIL_TRY
        Me._PIN_REMINDER = _PIN_REMINDER
        Me._LAST_LOGIN_DT = _LAST_LOGIN_DT
        Me._LAST_LOGIN_STATUS = _LAST_LOGIN_STATUS
        Me._PIN_ACTIVATED = _PIN_ACTIVATED
        Me._PIN_DATE = _PIN_DATE
        Me._IS_LOCKED = _IS_LOCKED
        Me._IS_LOGINED = _IS_LOGINED
        Me._USER_NAME = _USER_NAME
        Me._PIN_STATUS = _PIN_STATUS
        Me._PIN_STATUS_LUD = _PIN_STATUS_LUD
        Me._USER_STATUS = _USER_STATUS
        Me._LUCKY_NUM = _LUCKY_NUM
        Me._BIRTH_DT = _BIRTH_DT
        Me._USR_ROLE = _USR_ROLE
    End Sub

    Public Property USER_ID As String
        Get
            Return _USER_ID
        End Get
        Set(value As String)
            _USER_ID = value
        End Set
    End Property

    Public Property USER_PIN As String
        Get
            Return _USER_PIN
        End Get
        Set(value As String)
            _USER_PIN = value
        End Set
    End Property

    Public Property FAIL_ATTEMPTS As Short
        Get
            Return _FAIL_ATTEMPTS
        End Get
        Set(value As Short)
            _FAIL_ATTEMPTS = value
        End Set
    End Property

    Public Property LAST_FAIL_TRY As Date
        Get
            Return _LAST_FAIL_TRY
        End Get
        Set(value As Date)
            _LAST_FAIL_TRY = value
        End Set
    End Property

    Public Property PIN_REMINDER As String
        Get
            Return _PIN_REMINDER
        End Get
        Set(value As String)
            _PIN_REMINDER = value
        End Set
    End Property

    Public Property LAST_LOGIN_DT As Date
        Get
            Return _LAST_LOGIN_DT
        End Get
        Set(value As Date)
            _LAST_LOGIN_DT = value
        End Set
    End Property

    Public Property LAST_LOGIN_STATUS As String
        Get
            Return _LAST_LOGIN_STATUS
        End Get
        Set(value As String)
            _LAST_LOGIN_STATUS = value
        End Set
    End Property

    Public Property PIN_ACTIVATED As String
        Get
            Return _PIN_ACTIVATED
        End Get
        Set(value As String)
            _PIN_ACTIVATED = value
        End Set
    End Property

    Public Property PIN_DATE As String
        Get
            Return _PIN_DATE
        End Get
        Set(value As String)
            _PIN_DATE = value
        End Set
    End Property

    Public Property IS_LOCKED As String
        Get
            Return _IS_LOCKED
        End Get
        Set(value As String)
            _IS_LOCKED = value
        End Set
    End Property

    Public Property IS_LOGINED As String
        Get
            Return _IS_LOGINED
        End Get
        Set(value As String)
            _IS_LOGINED = value
        End Set
    End Property

    Public Property USER_NAME As String
        Get
            Return _USER_NAME
        End Get
        Set(value As String)
            _USER_NAME = value
        End Set
    End Property

    Public Property PIN_STATUS As String
        Get
            Return _PIN_STATUS
        End Get
        Set(value As String)
            _PIN_STATUS = value
        End Set
    End Property

    Public Property PIN_STATUS_LUD As Date
        Get
            Return _PIN_STATUS_LUD
        End Get
        Set(value As Date)
            _PIN_STATUS_LUD = value
        End Set
    End Property

    Public Property USER_STATUS As String
        Get
            Return _USER_STATUS
        End Get
        Set(value As String)
            _USER_STATUS = value
        End Set
    End Property

    Public Property LUCKY_NUM As String
        Get
            Return _LUCKY_NUM
        End Get
        Set(value As String)
            _LUCKY_NUM = value
        End Set
    End Property

    Public Property BIRTH_DT As Date
        Get
            Return _BIRTH_DT
        End Get
        Set(value As Date)
            _BIRTH_DT = value
        End Set
    End Property

    Public Property USR_ROLE As String
        Get
            Return _USR_ROLE
        End Get
        Set(value As String)
            _USR_ROLE = value
        End Set
    End Property


End Class
