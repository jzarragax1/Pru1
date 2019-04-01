Imports System.Data.SqlClient
Public Class SQLServerDirectAccess
    Public Shared Function Seleccionar(ByVal query As String, ByVal connetion As String, ByVal ParamArray p() As SqlParameter) As List(Of String())
        Dim cn As New SqlConnection(connetion)
        Dim cmd As New SqlCommand(query, cn)

		If p IsNot Nothing Then
			For Each ptr As SqlParameter In p
				cmd.Parameters.Add(ptr)
			Next
		End If

		Dim lst As New List(Of String())
		Dim odr As SqlDataReader
		Dim schemaTable As DataTable
		Try
			cn.Open()
			odr = cmd.ExecuteReader()
			schemaTable = odr.GetSchemaTable()
			Dim num = schemaTable.Rows.Count
			If odr.HasRows Then
				While (odr.Read())
					'Leer las lineas de datos
					Dim str(num) As String
					For i As Integer = 0 To num - 1
						'Leer las columnas
						Dim cultEs As New System.Globalization.CultureInfo("es-ES")
						If (odr.GetValue(i).GetType().Name = GetType(DateTime).Name) Then
							str(i) = Convert.ToDateTime(odr.GetValue(i).ToString(), cultEs.DateTimeFormat).ToString()
						Else
							str(i) = odr.GetValue(i).ToString()
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

    Public Shared Function Seleccionar(ByVal query As String, ByVal connetion As SqlConnection, ByVal ParamArray p() As SqlParameter) As List(Of String())
        If connetion.State <> ConnectionState.Open Then
            Throw New Exception("La conexion esta cerrada dentro de la transaccion")
        End If
		Dim cmd As New SqlCommand(query, connetion)

		If p IsNot Nothing Then
			For Each ptr As SqlParameter In p
				cmd.Parameters.Add(ptr)
			Next
		End If

		Dim lst As New List(Of String())
		Dim odr As SqlDataReader
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
					If (odr.GetSqlValue(i).GetType().Name = New SqlTypes.SqlDateTime().GetType().Name) Then
						str(i) = Convert.ToDateTime(odr.GetSqlValue(i).value.ToString(), cultEs.DateTimeFormat).ToString()
					Else
						str(i) = odr.GetSqlValue(i).ToString()
					End If
				Next
				lst.Add(str)
			End While
		End If
		Return lst
	End Function


    Public Shared Function seleccionar(Of O)(ByVal f As Func(Of SqlDataReader, O), ByVal query As String, ByVal connetion As String, ByVal ParamArray p() As SqlParameter) As List(Of O)
        Dim cn As New SqlConnection(connetion)
        Dim cmd As New SqlCommand(query, cn)

		If p IsNot Nothing Then
			For Each ptr As SqlParameter In p
				cmd.Parameters.Add(ptr)
			Next
		End If

		Dim lst As New List(Of O)
		Dim odr As SqlDataReader
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

    Public Shared Function seleccionar(Of O)(ByVal f As Func(Of SqlDataReader, O), ByVal query As String, ByVal connection As SqlConnection, ByVal sqlTran As SqlTransaction, ByVal ParamArray p() As SqlParameter) As List(Of O)
        If connection.State <> ConnectionState.Open Then
            Throw New Exception("La conexion esta cerrada dentro de la transaccion")
        End If
        Dim cmd As New SqlCommand(query, connection)
        cmd.Transaction = sqlTran
        If p IsNot Nothing Then
            For Each ptr As SqlParameter In p
                cmd.Parameters.Add(ptr)
            Next
        End If

        Dim lst As New List(Of O)
        Dim odr As SqlDataReader
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
        odr.Close()

        Return lst
    End Function

    Public Shared Function SeleccionarEscalar(Of T)(ByVal query As String, ByVal connetion As SqlConnection, ByVal sqlTran As SqlTransaction, ByVal ParamArray p() As SqlParameter) As T
        If connetion.State <> ConnectionState.Open Then
            Throw New Exception("La conexion esta cerrada dentro de la transaccion")
        End If
        Dim cmd As New SqlCommand(query, connetion)
        cmd.Transaction = sqlTran
        If p IsNot Nothing Then
            For Each ptr As SqlParameter In p
                cmd.Parameters.Add(ptr)
            Next
        End If

        Dim s As T
        Dim o = cmd.ExecuteScalar()
        If Not o Is Nothing AndAlso Not o.Equals(DBNull.Value) Then
            s = o
        End If
        Return s
    End Function

    Public Shared Function SeleccionarEscalar(Of T)(ByVal query As String, ByVal connetion As String, ByVal ParamArray p() As SqlParameter) As T
        Dim cn As New SqlConnection(connetion)
        Dim cmd As New SqlCommand(query, cn)
        If p IsNot Nothing Then
            For Each ptr As SqlParameter In p
                cmd.Parameters.Add(ptr)
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

    Public Shared Sub NoQuery(ByVal query As String, ByVal connetion As String, ByVal ParamArray p() As SqlParameter)
        Dim cn As New SqlConnection(connetion)
        Dim cmd As New SqlCommand(query, cn)

		If p IsNot Nothing Then
			For Each ptr As SqlParameter In p
				cmd.Parameters.Add(ptr)
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

    Public Shared Sub NoQuery(ByVal query As String, ByVal connetion As SqlConnection, ByVal sqlTran As SqlTransaction, ByVal ParamArray p() As SqlParameter)
        If connetion.State <> ConnectionState.Open Then
            Throw New Exception("La conexion esta cerrada dentro de la transaccion")
        End If
        Dim cmd As New SqlCommand(query, connetion)
        cmd.Transaction = sqlTran
        If p IsNot Nothing Then
            For Each ptr As SqlParameter In p
                cmd.Parameters.Add(ptr)
            Next
        End If

        cmd.ExecuteNonQuery()
        cmd.Dispose()
    End Sub

    Public Shared Sub NoQueryProcedure(ByVal query As String, ByVal connetion As SqlConnection, ByVal ParamArray p() As SqlParameter)
        If connetion.State <> ConnectionState.Open Then
            Throw New Exception("La conexion esta cerrada dentro de la transaccion")
        End If
        Dim cmd As New SqlCommand(query, connetion)
		cmd.CommandType = CommandType.StoredProcedure
		If p IsNot Nothing Then
			For Each ptr As SqlParameter In p
				cmd.Parameters.Add(ptr)
			Next
		End If
		cmd.ExecuteNonQuery()
		cmd.Dispose()
	End Sub

End Class
