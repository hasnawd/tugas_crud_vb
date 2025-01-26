Imports System.Data.Odbc
Module Module1
    Public Conn As OdbcConnection
    Public Da As OdbcDataAdapter
    Public Ds As DataSet
    Public CMd As OdbcCommand
    Public Rd As OdbcDataReader

    Public MyDB As String
    Public Sub Koneksi()
        MyDB = "Driver={Mysql 9.0.1 driver};
database=crud_artis;server=localhost;uid=root"
        Conn = New OdbcConnection(MyDB)
        If Conn.State = ConnectionState.Closed Then Conn.Open()
    End Sub
End Module
