Imports System
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Web
Imports GrupoMaterial
Imports Oracle.DataAccess.Client
Imports SabLib.BLL.Utils

Imports System.Web.Script.Serialization

Public Class DataAccessLayer

    Public cnStr As String = Configuration.ConfigurationManager.ConnectionStrings("CONNECTION").ConnectionString



#Region "GetAll"



    Public Function JsonSerializer(Of T)(o As T) As String
        Dim ser As New JavaScriptSerializer()
        Return ser.Serialize(o)
    End Function


    Public Function SQLPrueba() As List(Of CEtico)

        Dim query As String = " Select  RID,Name,Comment from CommentPerCourses order by 1 desc"
        Return Memcached.SQLServerDirectAccess.seleccionar(Of CEtico)(Function(r As SqlClient.SqlDataReader) _
            New CEtico With {.plantaDesc = CStr(r("Name")), .dni = CStr(r("Comment"))}, query, "Data Source = 188.121.44.217;Initial Catalog=clinicampus;User Id=User_clinicampus;Password=Napoleonx2;")

    End Function

    Public Function SQLPrueba2() As List(Of CEtico)

        Dim query As String = " Select  RID,Name,Comment from CommentPerCourses where name like '%ab%' order by 1 desc"
        Return Memcached.SQLServerDirectAccess.seleccionar(Of CEtico)(Function(r As SqlClient.SqlDataReader) _
            New CEtico With {.plantaDesc = CStr(r("Name")), .dni = CStr(r("Comment"))}, query, "Data Source = 188.121.44.217;Initial Catalog=clinicampus;User Id=User_clinicampus;Password=Napoleonx2;")

    End Function

#End Region


End Class
