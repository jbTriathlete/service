Imports System.Data.Services
Imports System.Data.Services.Common
Imports System.Linq
Imports System.ServiceModel.Web

Public Class NorthwindService
    ' TODO: replace [[class name]] with your data class name
    Inherits DataService(Of NorthwindEntities)

    ' This method is called only once to initialize service-wide policies.
    Public Shared Sub InitializeService(ByVal config As DataServiceConfiguration)
        ' Grant only the rights needed to support the client application.
        config.SetEntitySetAccessRule("Orders", EntitySetRights.AllRead _
             Or EntitySetRights.WriteMerge _
             Or EntitySetRights.WriteReplace)
        config.SetEntitySetAccessRule("Order_Details", EntitySetRights.AllRead _
            Or EntitySetRights.AllWrite)
        config.SetEntitySetAccessRule("Customers", EntitySetRights.AllRead)
    End Sub

End Class
