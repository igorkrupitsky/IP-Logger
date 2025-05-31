Imports System.Data.OleDb

Partial Class IpLogger
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request.QueryString("save") <> "" Then
            SaveIP(Request.QueryString("server"))
            Response.Write("OK")
            Response.End()
        ElseIf Request.QueryString("delete") <> "" Then
            DeleteServer(Request.QueryString("server"))
            Response.Write("OK")
            Response.End()
        End If

        Dim sSql As String = "SELECT IpAddress, MIN(AccessTime) AS EffectiveOn FROM IpLog " & _
                             " WHERE ServerName = '" & Request.QueryString("server") & "'" & _
                             " GROUP BY IpAddress ORDER BY IpAddress DESC"
        GridView1.DataSource = GetDataReader(sSql)
        GridView1.DataBind()

    End Sub

    Private Sub DeleteServer(ByVal sServerName As String)
        Dim sSql As String = "DELETE FROM IpLog WHERE ServerName = '" & sServerName & "'"
        ExecuteCommand(sSql)
    End Sub

    Private Sub SaveIP(ByVal sServerName As String)
        Dim sId As String = Request.ServerVariables("remote_addr")
        Dim sSql As String = "INSERT INTO IpLog (IpAddress, ServerName) VALUES ('" & sId & "', '" & sServerName & "')"
        ExecuteCommand(sSql)
    End Sub

    Private Function GetDataReader(ByVal sSql As String) As OleDbDataReader
        Dim sConnection As String = GetConnectionString() 
        Dim cn As New OleDbConnection(sConnection)
        Dim cmd As New OleDbCommand(sSql, cn)
        cn.Open()
        Try
            Return cmd.ExecuteReader(Data.CommandBehavior.CloseConnection)
        Catch ex As Exception
            Throw New Exception(ex.Message & "<br><br>SQL: " & Replace(sSql, vbCrLf, "<br>"))
        End Try
    End Function

    Private Sub ExecuteCommand(ByVal sSql As String)
        Dim cn As New OleDbConnection(GetConnectionString())
        Dim cmd As New OleDbCommand(sSql, cn)
        cn.Open()

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception(ex.Message & "; SQL: " & sSql)
        End Try

        cn.Close()
    End Sub

    Private Function GetConnectionString() As String
        Return "Provider=SQLOLEDB.1;Password=pass123;Persist Security Info=True;User ID=sa;Initial Catalog=IpLogger;Data Source=."
    End Function

End Class
