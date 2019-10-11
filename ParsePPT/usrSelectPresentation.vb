Public Class usrSelectPresentation
    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click

        dialogOpenFile.ShowDialog()
        txtPresentation.Text = dialogOpenFile.FileName

    End Sub
End Class
