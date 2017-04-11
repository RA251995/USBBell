Option Strict On
Option Explicit On

'''<summary>
''' Runs the application.
'''</summary> 
''' 
Public Class GenericHid

    Friend Shared FrmMy As usbio

    '''<summary>
    ''' Displays the application's main form.
    '''</summary> 

    Public Shared Sub Main()
        FrmMy = New usbio()
        Application.Run(FrmMy)
    End Sub

End Class



