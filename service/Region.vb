'------------------------------------------------------------------------------
' <auto-generated>
'    This code was generated from a template.
'
'    Manual changes to this file may cause unexpected behavior in your application.
'    Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class Region
    Public Property RegionID As Integer
    Public Property RegionDescription As String

    Public Overridable Property Territories As ICollection(Of Territory) = New HashSet(Of Territory)

End Class
