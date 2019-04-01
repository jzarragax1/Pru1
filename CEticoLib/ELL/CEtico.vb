Namespace ELL

    Public Class CEtico

        Private _planta As Integer = Integer.MinValue
        Private _id As Integer = Integer.MinValue
        Private _plantaDesc As String = String.Empty
        Private _idTra As String = String.Empty
        Private _fecha As Date = Date.MinValue
        Private _codCategoria As String = String.Empty
        Private _comentario As String = String.Empty
        Private _comentariocorto As String = String.Empty
        Private _Accion As String = String.Empty
        Private _email As String = String.Empty
        Private _traduccion As String = String.Empty
        Private _traduccioncorto As String = String.Empty
        Private _cierre As String = String.Empty



#Region "Enumeracion"

        Public Enum TipoJornada As Integer
            Partida = 0
            Intensiva = 1
        End Enum

#End Region

        ''' <summary>
        ''' Identificador del Empleado
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>        
        Public Property planta() As Integer
            Get
                Return _planta
            End Get
            Set(ByVal value As Integer)
                _planta = value
            End Set
        End Property
        Public Property Id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal value As Integer)
                _id = value
            End Set
        End Property
        Public Property plantaDesc() As String
            Get
                Return _plantaDesc
            End Get
            Set(ByVal value As String)
                _plantaDesc = value
            End Set
        End Property
        Public Property Idtra() As String
            Get
                Return _idTra
            End Get
            Set(ByVal value As String)
                _idTra = value
            End Set
        End Property

        Public Property codCategoria() As String
            Get
                Return _codCategoria
            End Get
            Set(ByVal value As String)
                _codCategoria = value
            End Set
        End Property
        Public Property Accion() As String
            Get
                Return _Accion
            End Get
            Set(ByVal value As String)
                _Accion = value
            End Set
        End Property
        ''' <summary>
        ''' Fecha del registro
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>        
        Public Property Fecha() As Date
            Get
                Return _fecha
            End Get
            Set(ByVal value As Date)
                _fecha = value
            End Set
        End Property



        ''' <summary>
        ''' comentario
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property comentario() As String
            Get
                Return _comentario
            End Get
            Set(ByVal value As String)
                _comentario = value
            End Set
        End Property
        Public Property comentariocorto() As String
            Get
                Return _comentariocorto
            End Get
            Set(ByVal value As String)
                _comentariocorto = value
            End Set
        End Property

        Public Property email() As String
            Get
                Return _email
            End Get
            Set(ByVal value As String)
                _email = value
            End Set
        End Property
        Public Property traduccion() As String
            Get
                Return _traduccion
            End Get
            Set(ByVal value As String)
                _traduccion = value
            End Set
        End Property
        Public Property traduccioncorto() As String
            Get
                Return _traduccioncorto
            End Get
            Set(ByVal value As String)
                _traduccioncorto = value
            End Set
        End Property
        Public Property cierre() As String
            Get
                Return _cierre
            End Get
            Set(ByVal value As String)
                _cierre = value
            End Set
        End Property
    End Class

    Public Class gtkGridView
            ''' <summary>
            ''' Identificador del Registro Seleccionado.
            ''' </summary>
            Private _IdSeleccionado As Nullable(Of Integer)
            ''' <summary>
            ''' Nombre de la PROPIEDAD por la que se quiere ordenar los objetos.
            ''' </summary>
            Private _CampoOrdenacion As String
            ''' <summary>
            ''' Direccion de Ordenacion para el Campo de Ordenacion (Nombre de la Propiedad).
            ''' </summary>
            Private _DireccionOrdenacion As Nullable(Of System.ComponentModel.ListSortDirection)
            ''' <summary>
            ''' Indice de la página en curso.
            ''' </summary>
            Private _Pagina As Nullable(Of Integer)

            ''' <summary>
            ''' Identificador del Registro Seleccionado.
            ''' </summary>
            Public Property IdSeleccionado() As Nullable(Of Integer)
                Get
                    Return _IdSeleccionado
                End Get
                Set(ByVal value As Nullable(Of Integer))
                    _IdSeleccionado = value
                End Set
            End Property

            ''' <summary>
            ''' Nombre de la PROPIEDAD por la que se quiere ordenar los objetos.
            ''' </summary>
            Public Property CampoOrdenacion() As String
                Get
                    Return _CampoOrdenacion
                End Get
                Set(ByVal value As String)
                    _CampoOrdenacion = value
                End Set
            End Property
            ''' <summary>
            ''' Direccion de Ordenacion para el Campo de Ordenacion (Nombre de la Propiedad).
            ''' </summary>
            Public Property DireccionOrdenacion() As Nullable(Of System.ComponentModel.ListSortDirection)
                Get
                    Return _DireccionOrdenacion
                End Get
                Set(ByVal value As Nullable(Of System.ComponentModel.ListSortDirection))
                    _DireccionOrdenacion = value
                End Set
            End Property

            ''' <summary>
            ''' Indice de la página en curso.
            ''' </summary>
            Public Property Pagina As Nullable(Of Integer)
                Get
                    Return _Pagina
                End Get
                Set(ByVal value As Nullable(Of Integer))
                    _Pagina = value
                End Set
            End Property

        End Class






    Public Class Responsables
        Private _planta As Integer = Integer.MinValue
        Private _id As Integer = Integer.MinValue
        Private _Abrev As String = String.Empty
        Private _nombre As String = String.Empty
        Private _mail As String = String.Empty

        Public Property Planta() As Integer
            Get
                Return _planta
            End Get
            Set(ByVal value As Integer)
                _planta = value
            End Set
        End Property
        Public Property Id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal value As Integer)
                _id = value
            End Set
        End Property

        Public Property Nombre() As String
            Get
                Return _nombre
            End Get
            Set(ByVal value As String)
                _nombre = value
            End Set
        End Property

        Public Property Abrev() As String
            Get
                Return _Abrev
            End Get
            Set(ByVal value As String)
                _Abrev = value
            End Set
        End Property
        Public Property Mail() As String
            Get
                Return _mail
            End Get
            Set(ByVal value As String)
                _mail = value
            End Set
        End Property

    End Class



    Public Class Rol

#Region "Variables miembro"

        Private _planta As Integer = Integer.MinValue
        Private _id As Integer = Integer.MinValue
        Private _rol As Integer = Integer.MinValue
        Private _NombreRol As String = String.Empty
        Private _NombreUser As String = String.Empty



#End Region

#Region "Properties"

        ''' <summary>
        ''' Id
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>        
        Public Property Planta() As Integer
            Get
                Return _planta
            End Get
            Set(ByVal value As Integer)
                _planta = value
            End Set
        End Property
        Public Property Id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal value As Integer)
                _id = value
            End Set
        End Property
        Public Property rol() As Integer
            Get
                Return _rol
            End Get
            Set(ByVal value As Integer)
                _rol = value
            End Set
        End Property

        Public Property NombreRol() As String
            Get
                Return _NombreRol
            End Get
            Set(ByVal value As String)
                _NombreRol = value
            End Set
        End Property
        Public Property NombreUser() As String
            Get
                Return _NombreUser
            End Get
            Set(ByVal value As String)
                _NombreUser = value
            End Set
        End Property
#End Region

    End Class

End Namespace
