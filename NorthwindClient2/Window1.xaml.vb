Imports NorthwindClient2.Northwind
Imports System.Data.Services.Client

Public Class Window1
    Private context As NorthwindEntities
    Private customerId As String = "ALFKI"

    ' Replace the host server and port number with the values  
    ' for the test server hosting your Northwind data service instance. 
    Private svcUri As Uri = New Uri("http://localhost:60779/NorthwindService.svc")
    Private Sub Window1_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Try

            ' Instantiate the DataServiceContext.
            context = New NorthwindEntities(svcUri)

            ' Define a LINQ query that returns Orders and  
            ' Order_Details for a specific customer. 
            Dim ordersQuery = From o In context.Orders.Expand("Order_Details") _
                                  Where o.Customer.CustomerID = customerId _
                                  Select o

            ' Create an DataServiceCollection(Of T) based on 
            ' execution of the LINQ query for Orders. 
            Dim customerOrders As DataServiceCollection(Of Order) = New  _
                DataServiceCollection(Of Order)(ordersQuery)

            '' Make the DataServiceCollection<T> the binding source for the Grid. 
            'Me.orderItemsGrid.DataContext = customerOrders
            comboBoxOrder.DataContext = ordersQuery
            Me.orderItemsDataGrid.DataContext = customerOrders
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub buttonClose_Click(sender As Object, e As RoutedEventArgs) Handles buttonClose.Click
        Me.Close()
    End Sub

    Private Sub buttonSave_Click(sender As Object, e As RoutedEventArgs) Handles buttonSave.Click
        Try
            ' Save changes made to objects tracked by the context.
            context.SaveChanges()
        Catch ex As DataServiceRequestException
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

   
   
    
End Class
