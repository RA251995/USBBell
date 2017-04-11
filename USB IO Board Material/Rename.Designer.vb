<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rename
    Inherits MaterialSkin.Controls.MaterialForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tbRename = New MaterialSkin.Controls.MaterialSingleLineTextField()
        Me.bOK = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.bCancel = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.SuspendLayout()
        '
        'tbRename
        '
        Me.tbRename.Depth = 0
        Me.tbRename.Hint = ""
        Me.tbRename.Location = New System.Drawing.Point(13, 72)
        Me.tbRename.MaxLength = 32767
        Me.tbRename.MouseState = MaterialSkin.MouseState.HOVER
        Me.tbRename.Name = "tbRename"
        Me.tbRename.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.tbRename.SelectedText = ""
        Me.tbRename.SelectionLength = 0
        Me.tbRename.SelectionStart = 0
        Me.tbRename.Size = New System.Drawing.Size(208, 23)
        Me.tbRename.TabIndex = 4
        Me.tbRename.TabStop = False
        Me.tbRename.UseSystemPasswordChar = False
        '
        'bOK
        '
        Me.bOK.Depth = 0
        Me.bOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.bOK.Location = New System.Drawing.Point(13, 102)
        Me.bOK.MouseState = MaterialSkin.MouseState.HOVER
        Me.bOK.Name = "bOK"
        Me.bOK.Primary = True
        Me.bOK.Size = New System.Drawing.Size(101, 30)
        Me.bOK.TabIndex = 5
        Me.bOK.Text = "RENAME"
        Me.bOK.UseVisualStyleBackColor = True
        '
        'bCancel
        '
        Me.bCancel.Depth = 0
        Me.bCancel.Location = New System.Drawing.Point(121, 102)
        Me.bCancel.MouseState = MaterialSkin.MouseState.HOVER
        Me.bCancel.Name = "bCancel"
        Me.bCancel.Primary = True
        Me.bCancel.Size = New System.Drawing.Size(100, 30)
        Me.bCancel.TabIndex = 6
        Me.bCancel.Text = "CANCEL"
        Me.bCancel.UseVisualStyleBackColor = True
        '
        'Rename
        '
        Me.AcceptButton = Me.bOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CancelButton = Me.bCancel
        Me.ClientSize = New System.Drawing.Size(233, 147)
        Me.ControlBox = False
        Me.Controls.Add(Me.bCancel)
        Me.Controls.Add(Me.bOK)
        Me.Controls.Add(Me.tbRename)
        Me.ForeColor = System.Drawing.Color.Snow
        Me.Name = "Rename"
        Me.Text = "Rename"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbRename As MaterialSkin.Controls.MaterialSingleLineTextField
    Friend WithEvents bOK As MaterialSkin.Controls.MaterialRaisedButton
    Friend WithEvents bCancel As MaterialSkin.Controls.MaterialRaisedButton
End Class
