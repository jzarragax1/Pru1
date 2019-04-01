'Imports Oracle.ManagedDataAccess
'Imports Oracle.ManagedDataAccess.Client

Public Class OracleManagedDirectAccess

    Public Shared Function seleccionar(Of O)(ByVal f As Func(Of OracleDataReader, O), ByVal query As String, ByVal connetion As String, ByVal ParamArray p() As OracleParameter) As List(Of O)
        Dim cn As New OracleConnection(connetion)
        Dim cmd As New OracleCommand(query, cn)
        cmd.BindByName = True
        If (p IsNot Nothing) Then
            For Each ptr As OracleParameter In p
                If (ptr IsNot Nothing) Then cmd.Parameters.Add(ptr)
            Next
        End If

        Dim lst As New List(Of O)
        Dim odr As OracleDataReader
        Dim schemaTable As DataTable
        Try
            cn.Open()
            odr = cmd.ExecuteReader()
            schemaTable = odr.GetSchemaTable()
            Dim num = schemaTable.Rows.Count
            If odr.HasRows Then
                While (odr.Read())
                    'Asign values to the O type object applying the higher order function f
                    lst.Add(f(odr))
                End While
            End If
            cn.Close()
            cmd.Dispose()
            odr.Dispose()
        Catch ex As Exception
            cn.Close()
            cmd.Dispose()
            Throw
        End Try
        Return lst
    End Function
    Public Shared Function seleccionar(Of O)(ByVal f As Func(Of OracleDataReader, O), ByVal query As String, ByVal connection As OracleConnection, ByVal ParamArray p() As OracleParameter) As List(Of O)
        If connection.State <> ConnectionState.Open Then
            Throw New Exception("La conexion esta cerrada dentro de la transaccion")
        End If
        Dim cmd As New OracleCommand(query, connection)
        cmd.BindByName = True
        If (p IsNot Nothing) Then
            For Each ptr As OracleParameter In p
                If (ptr IsNot Nothing) Then cmd.Parameters.Add(ptr)
            Next
        End If

        Dim lst As New List(Of O)
        Dim odr As OracleDataReader
        Dim schemaTable As DataTable

        odr = cmd.ExecuteReader()
        schemaTable = odr.GetSchemaTable()
        Dim num = schemaTable.Rows.Count
        If odr.HasRows Then
            While (odr.Read())
                'Asign values to the O type object applying the higher order function f
                lst.Add(f(odr))
            End While
        End If

        Return lst
    End Function

    Public Shared Function SeleccionarDiccionario(ByVal query As String, ByVal connetion As String, ByVal ParamArray p() As OracleParameter) As Dictionary(Of String, String)
        Dim cn As New OracleConnection(connetion)
        Dim cmd As New OracleCommand(query, cn)
        cmd.BindByName = True
        If (p IsNot Nothing) Then
            For Each ptr As OracleParameter In p
                If (ptr IsNot Nothing) Then cmd.Parameters.Add(ptr)
            Next
        End If

        Dim lst As New Dictionary(Of String, String)
        Dim odr As OracleDataReader
        Dim schemaTable As DataTable
        Try
            cn.Open()
            odr = cmd.ExecuteReader()
            schemaTable = odr.GetSchemaTable()
            Dim num = schemaTable.Rows.Count
            If odr.HasRows Then
                While odr.Read
                    'Leer las lineas de datos
                    lst.Add(odr.GetOracleValue(0).ToString(), odr.GetOracleValue(1).ToString())
                End While
            End If
            cn.Close()
            cmd.Dispose()
            odr.Dispose()
        Catch ex As Exception
            cn.Close()
            cmd.Dispose()
            Throw
        End Try
        Return lst
    End Function

    Public Shared Function SeleccionarEscalar(Of T)(ByVal query As String, ByVal connetion As OracleConnection, ByVal ParamArray p() As OracleParameter) As T
        If connetion.State <> ConnectionState.Open Then
            Throw New Exception("La conexion esta cerrada dentro de la transaccion")
        End If
        Dim cmd As New OracleCommand(query, connetion)
        cmd.BindByName = True
        If (p IsNot Nothing) Then
            For Each ptr As OracleParameter In p
                If (ptr IsNot Nothing) Then cmd.Parameters.Add(ptr)
            Next
        End If

        Dim s As T
        Dim o = cmd.ExecuteScalar()
        If Not o Is Nothing AndAlso Not o.Equals(DBNull.Value) Then
            s = o
        End If
        Return s
    End Function
    Public Shared Function SeleccionarEscalar(Of T)(ByVal query As String, ByVal connetion As String, ByVal ParamArray p() As OracleParameter) As T
        Dim cn As New OracleConnection(connetion)
        Dim cmd As New OracleCommand(query, cn)
        cmd.BindByName = True
        If (p IsNot Nothing) Then
            For Each ptr As OracleParameter In p
                If (ptr IsNot Nothing) Then cmd.Parameters.Add(ptr)
            Next
        End If

        Dim s As T
        Try
            cn.Open()
            Dim o = cmd.ExecuteScalar()
            If Not o Is Nothing AndAlso Not o.Equals(DBNull.Value) Then
                s = o
            End If
            cn.Close()
            cmd.Dispose()
        Catch ex As Exception
            cn.Close()
            cmd.Dispose()
            Throw
        End Try
        Return s
    End Function

    Public Shared Sub NoQuery(ByVal query As String, ByVal connetion As String, ByVal ParamArray p() As OracleParameter)
        Dim cn As New OracleConnection(connetion)
        Dim cmd As New OracleCommand(query, cn)
        cmd.BindByName = True
        If (p IsNot Nothing) Then
            For Each ptr As OracleParameter In p
                If (ptr IsNot Nothing) Then cmd.Parameters.Add(ptr)
            Next
        End If

        Try
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            cmd.Dispose()
        Catch ex As Exception
            cn.Close()
            cmd.Dispose()
            Throw
        End Try
    End Sub
    Public Shared Sub NoQuery(ByVal query As String, ByVal connetion As OracleConnection, ByVal ParamArray p() As OracleParameter)
        If connetion.State <> ConnectionState.Open Then
            Throw New Exception("La conexion esta cerrada dentro de la transaccion")
        End If
        Dim cmd As New OracleCommand(query, connetion)
        cmd.BindByName = True
        If (p IsNot Nothing) Then
            For Each ptr As OracleParameter In p
                If (ptr IsNot Nothing) Then cmd.Parameters.Add(ptr)
            Next
        End If

        cmd.ExecuteNonQuery()
        cmd.Dispose()
    End Sub

    Public Shared Sub NoQueryProcedure(ByVal query As String, ByVal connetion As OracleConnection, ByVal ParamArray p() As OracleParameter)
        If connetion.State <> ConnectionState.Open Then
            Throw New Exception("La conexion esta cerrada dentro de la transaccion")
        End If
        Dim cmd As New OracleCommand(query, connetion)
        cmd.BindByName = True
        cmd.CommandType = CommandType.StoredProcedure
        If (p IsNot Nothing) Then
            For Each ptr As OracleParameter In p
                If (ptr IsNot Nothing) Then cmd.Parameters.Add(ptr)
            Next
        End If

        cmd.ExecuteNonQuery()
        cmd.Dispose()
    End Sub
    Public Shared Sub NoQueryProcedure(ByVal query As String, ByVal connetion As String, ByVal ParamArray p() As OracleParameter)
        Dim cn As New OracleConnection(connetion)
        Dim cmd As New OracleCommand(query, cn)
        cmd.BindByName = True
        cmd.CommandType = CommandType.StoredProcedure
        If (p IsNot Nothing) Then
            For Each ptr As OracleParameter In p
                If (ptr IsNot Nothing) Then cmd.Parameters.Add(ptr)
            Next
        End If
        Try
            cn.Open()
            cmd.ExecuteNonQuery()
            cn.Close()
            cmd.Dispose()
        Catch ex As Exception
            cn.Close()
            cmd.Dispose()
            Throw
        End Try
    End Sub
    Public Shared Function castDBValueToNullable(Of Q As Structure)(r As Object) As Q?
        If r Is DBNull.Value Then
            Return New Q?
        End If
        Return New Q?(r)
    End Function
End Class


