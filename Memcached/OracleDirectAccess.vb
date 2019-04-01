Public Class OracleDirectAccess
    Public Shared Function Seleccionar(ByVal query As String, ByVal connetion As OracleConnection, ByVal ParamArray p() As OracleParameter) As List(Of String())
        If connetion.State <> ConnectionState.Open Then
            Throw New Exception("La conexion esta cerrada dentro de la transaccion")
        End If
        Dim cmd As New OracleCommand(query, connetion)
        cmd.BindByName = True   'CON ESTA CLAUSULA, DEJA DE IMPORTAR EL ORDEN Y SE FIJA EN EL NOMBRE DE LOS PARAMETROS
        If (p IsNot Nothing) Then
            For Each ptr As OracleParameter In p
                If (ptr IsNot Nothing) Then cmd.Parameters.Add(ptr)
            Next
        End If

        Dim lst As New List(Of String())
        Dim odr As OracleDataReader
        Dim schemaTable As DataTable
        odr = cmd.ExecuteReader()
        schemaTable = odr.GetSchemaTable()
        Dim num = schemaTable.Rows.Count
        If odr.HasRows Then
            While (odr.Read())
                'Leer las lineas de datos
                Dim str(num - 1) As String
                For i As Integer = 0 To num - 1
                    'Leer las columnas
                    Dim cultEs As New System.Globalization.CultureInfo("es-ES")
                    If (odr.GetOracleValue(i).GetType().Name = New OracleDate().GetType().Name) Then
                        If (odr.IsDBNull(i)) Then
                            str(i) = Date.MinValue
                        Else
                            str(i) = Convert.ToDateTime(odr.GetOracleValue(i).value.ToString(), cultEs.DateTimeFormat).ToString()
                        End If
                    ElseIf (odr.GetOracleValue(i).GetType().Name.ToLower = "oracleblob") Then
                        If (Not odr.IsDBNull(i)) Then
                            Dim mByte As Byte() = CType(odr.GetOracleValue(i).value, Byte())
                            Dim enc As New System.Text.UTF8Encoding()
                            str(i) = enc.GetString(mByte)
                        End If
                    ElseIf (odr.GetOracleValue(i).GetType().Name.ToLower = "oracleclob") Then
                        If (Not odr.IsDBNull(i)) Then str(i) = odr.GetOracleValue(i).value
                    Else
                        If (Not odr.IsDBNull(i)) Then str(i) = odr.GetOracleValue(i).ToString
                    End If
                Next
                lst.Add(str)
            End While
        End If
        Return lst
    End Function
    Public Shared Function Seleccionar(ByVal query As String, ByVal connetion As String, ByVal ParamArray p() As OracleParameter) As List(Of String())
        Dim cn As New OracleConnection(connetion)
        Dim cmd As New OracleCommand(query, cn)
        cmd.BindByName = True
        If (p IsNot Nothing) Then
            For Each ptr As OracleParameter In p
                If (ptr IsNot Nothing) Then cmd.Parameters.Add(ptr)
            Next
        End If

        Dim lst As New List(Of String())
        Dim odr As OracleDataReader
        Dim schemaTable As DataTable
        Try
            cn.Open()
            odr = cmd.ExecuteReader()
            schemaTable = odr.GetSchemaTable()
            Dim num = schemaTable.Rows.Count
            If odr.HasRows Then
                While (odr.Read())
                    'Leer las lineas de datos
                    Dim str(num - 1) As String
                    For i As Integer = 0 To num - 1
                        'Leer las columnas
                        Dim cultEs As New System.Globalization.CultureInfo("es-ES")
                        If (odr.GetOracleValue(i).GetType().Name = New OracleDate().GetType().Name) Then
                            If (odr.IsDBNull(i)) Then
                                str(i) = Date.MinValue
                            Else
                                str(i) = Convert.ToDateTime(odr.GetOracleValue(i).value.ToString(), cultEs.DateTimeFormat).ToString()
                            End If
                        ElseIf (odr.GetOracleValue(i).GetType().Name.ToLower = "oracleblob") Then
                            If (Not odr.IsDBNull(i)) Then
                                Dim mByte As Byte() = CType(odr.GetOracleValue(i).value, Byte())
                                Dim enc As New System.Text.UTF8Encoding()
                                str(i) = enc.GetString(mByte)
                            End If
                        ElseIf (odr.GetOracleValue(i).GetType().Name.ToLower = "oracleclob") Then
                            If (Not odr.IsDBNull(i)) Then str(i) = odr.GetOracleValue(i).value
                        Else
                            If (Not odr.IsDBNull(i)) Then str(i) = odr.GetOracleValue(i).ToString
                        End If
                    Next
                    lst.Add(str)
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
End Class