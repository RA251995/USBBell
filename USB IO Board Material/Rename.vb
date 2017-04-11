Imports MaterialSkin
Public Class Rename

    Private Sub bOK_Click(sender As Object, e As EventArgs)
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Rename_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeMaterialSkin()
    End Sub
    Private Sub InitializeMaterialSkin()
        Dim SkinManager As MaterialSkinManager = MaterialSkinManager.Instance
        SkinManager.AddFormToManage(Me)
        SkinManager.Theme = MaterialSkinManager.Themes.DARK
        SkinManager.ColorScheme = New ColorScheme(Primary.Grey800, Primary.Grey900, Primary.Grey500, Accent.Amber100, TextShade.WHITE)
    End Sub

End Class
