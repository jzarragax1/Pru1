Imports System.Configuration
Imports Oracle.DataAccess.Client
Imports System.Web
Imports System.Web.Script.Serialization

Namespace BLL
    Public Class cEtico

        Public Function SQLPrueba() As List(Of ELL.CEtico)

            Dim query As String = " Select  RID,Name,Comment from CommentPerCourses order by 1 desc"
            Return Memcached.SQLServerDirectAccess.seleccionar(Of ELL.CEtico)(Function(r As SqlClient.SqlDataReader) _
            New ELL.CEtico With {.Id = CInt(r("RID")), .plantaDesc = CStr(r("Name")), .comentario = CStr(r("Comment"))}, query, "Data Source = 188.121.44.217;Initial Catalog=clinicampus;User Id=User_clinicampus;Password=Napoleonx2;")

        End Function

        'Public Shared Function getRoles(ByVal idRol As Integer) As List(Of String())
        '    Dim query As String = "SELECT idusr from roles_USR where idROL=41 "
        '    Dim parameter As New OracleParameter("ID", OracleDbType.Int32, idRol, ParameterDirection.Input)

        '    Return Memcached.OracleDirectAccess.seleccionar(query, CadenaConexion)


        'End Function

        Public Function JsonSerializer(Of T)(o As T) As String
            Dim ser As New JavaScriptSerializer()
            Return ser.Serialize(o)
        End Function



    End Class
End Namespace