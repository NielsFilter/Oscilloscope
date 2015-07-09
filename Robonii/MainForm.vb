Public Class MainForm

    Dim _frmOscilloscope As frmOscilloscope
    Dim _frmFFT As frmFFT

    Private Sub tsmiOscilloscope_Click(sender As Object, e As EventArgs) Handles tsmiOscilloscope.Click
        If Me.IsFormOpen(Me._frmOscilloscope) Then
            Exit Sub '// Form is already open
        End If

        Me._frmOscilloscope = New frmOscilloscope()
        Me._frmOscilloscope.MdiParent = Me
        Me._frmOscilloscope.Show()
    End Sub

    Private Sub tsmiFFT_Click(sender As Object, e As EventArgs) Handles tsmiFFT.Click
        If Me.IsFormOpen(Me._frmFFT) Then
            Exit Sub '// Form is already open
        End If

        Me._frmFFT = New frmFFT()
        Me._frmFFT.MdiParent = Me
        Me._frmFFT.Show()
    End Sub

    Private Function IsFormOpen(frm As Form) As Boolean
        If frm Is Nothing Then
            Return False
        End If
        For Each openForm In Application.OpenForms
            If openForm.GetType() = frm.GetType() Then
                Return True
            End If
        Next

        Return False
    End Function
End Class
