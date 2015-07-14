Imports System.Text
Imports System.Threading

Public Class ApplicationErrors
    Public Shared Sub Handle(ex As Exception, Optional extraInfo As String = Nothing)
        'Handle Errors here if needed
        Dim errorDetails As New StringBuilder()

        If Not String.IsNullOrEmpty(extraInfo) Then
            errorDetails.AppendLine(extraInfo)
        End If

        errorDetails.AppendLine("Exception: " & ex.Message)
        If Not IsNothing(ex.InnerException) Then
            errorDetails.AppendLine(Environment.NewLine & "Inner Exception: " & ex.InnerException.Message)
        End If
        errorDetails.AppendLine("Stack Trace: " & ex.StackTrace)

        'Current we simply show the error message with some detail.
        MessageBox.Show(errorDetails.ToString(), "An has error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Public Shared Sub UIThreadException(ByVal sender As Object, ByVal e As ThreadExceptionEventArgs)
        Handle(e.Exception)
    End Sub

    Public Shared Sub AppDomainException(ByVal sender As Object, ByVal e As UnhandledExceptionEventArgs)
        Dim ex As Exception = CType(e.ExceptionObject, Exception)
        Handle(ex)
    End Sub

End Class
