''''''''''''''''''''''''''''''''                           
'' Developer     :RA          ''
'' Date Modified :03-10-2015  ''
''''''''''''''''''''''''''''''''
Option Strict On
Option Explicit On
Imports MaterialSkin
Imports System.Drawing.Drawing2D

Imports USB_IO_Board.DeviceManagement
Imports USB_IO_Board.FileIO
Imports USB_IO_Board.Hid
Imports Microsoft.Win32.SafeHandles
Imports System.Globalization
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Timers

Public Class usbio
    Dim mydata1(65) As Byte
    Dim flagb As Boolean
    Private deviceNotificationHandle As IntPtr
    Private exclusiveAccess As Boolean
    Private fileStreamdevicedata As IO.FileStream
    Private hidHandle As SafeFileHandle
    Private hidUsage As String
    Private myDeviceDetected As Boolean
    Private myDevicePathName As String
    Private transferInProgress As Boolean = False
    Private writeHandle As SafeFileHandle

    Private MyDeviceManagement As New DeviceManagement()
    Private MyHid As New Hid()

    Private Shared tmrReadTimeout As System.Timers.Timer
    Private Shared tmrContinuousDataCollect As System.Timers.Timer

    Private duration As Integer              'Duration of bell from listview
    Private bellTimings As List(Of [String]) 'Store current timing data (FORMAT : TIME#DURATION)
    Private filename As String               'Filename of timing list file selected
    Private stopwatch As New Stopwatch
    Private bellOn As Boolean
    Private bellStatus As Boolean

    ''' <summary>
    ''' Analog Clock Variables
    ''' </summary>

    Const Convert1 As Double = Math.PI / 180

    Const SecRadius As Double = 155
    Const MinRadius As Double = 120
    Const HrRadius As Double = 80
    Dim SecAngle As Double
    Dim MinAngle As Double
    Dim HrAngle As Double
    Dim SecX As Single = 220
    Dim SecY As Single = 70
    Dim MinX As Single = 220
    Dim MinY As Single = 70
    Dim HrX As Single = 220
    Dim HrY As Single = 70
    Dim hrs, min, value As Integer

    Dim WithEvents tmrClock As New Timer

    Dim StartPoint(60) As PointF
    Dim EndPoint(60) As PointF

    'Create the Pens 
    Dim WhitePen As Pen = New Pen(Color.White, 1)
    Dim WhitePen1 As Pen = New Pen(Color.White, 3)
    Dim WhitePen2 As Pen = New Pen(Color.White, 2)

    'Create the Bitmap to draw the clock face 
    Dim ClockFace As New Bitmap(445, 445)
    Dim gr As Graphics = Graphics.FromImage(ClockFace)

    ''' <summary>
    ''' Analog Clock Variables
    ''' </summary>



    Friend Sub OnDeviceChange(ByVal m As Message)

        Try
            If (m.WParam.ToInt32 = DBT_DEVICEARRIVAL) Then

                ' If WParam contains DBT_DEVICEARRIVAL, a device has been attached.

                ' Find out if it's the device we're communicating with.

                If MyDeviceManagement.DeviceNameMatch(m, myDevicePathName) Then
                    bellStatus = True

                    Status.Text = "USB BELL CONNECTED"

                    Timer2.Start()

                End If

            ElseIf (m.WParam.ToInt32 = DBT_DEVICEREMOVECOMPLETE) Then

                ' If WParam contains DBT_DEVICEREMOVAL, a device has been removed.

                ' Find out if it's the device we're communicating with.

                If MyDeviceManagement.DeviceNameMatch(m, myDevicePathName) Then
                    bellStatus = False

                    Status.Text = "USB BELL DISCONNECTED"

                    Timer2.Stop()
                    ' Set MyDeviceDetected False so on the next data-transfer attempt,
                    ' FindTheHid() will be called to look for the device 
                    ' and get a new handle.

                    Me.myDeviceDetected = False
                End If
            End If



        Catch ex As Exception
            DisplayException(Me.Name, ex)
            Throw
        End Try
    End Sub

    Protected Overrides Sub WndProc(ByRef m As Message)

        Try
            ' The OnDeviceChange routine processes WM_DEVICECHANGE messages.

            If m.Msg = WM_DEVICECHANGE Then
                OnDeviceChange(m)
            End If

            ' Let the base form process the message.

            MyBase.WndProc(m)

        Catch ex As Exception
            DisplayException(Me.Name, ex)
            Throw
        End Try

    End Sub

    Private Function FindTheHid() As Boolean

        Dim deviceFound As Boolean
        Dim devicePathName(127) As String
        Dim hidGuid As System.Guid
        Dim inputReportBuffer As Byte() = Nothing
        Dim memberIndex As Int32
        Dim myProductID As Int32
        Dim myVendorID As Int32
        Dim outputReportBuffer As Byte() = Nothing
        Dim success As Boolean

        Try
            myDeviceDetected = False

            ' Set the device's Vendor ID and Product ID.

            myVendorID = &H4D8
            myProductID = &H42
            ' ***
            ' API function: 'HidD_GetHidGuid

            ' Purpose: Retrieves the interface class GUID for the HID class.

            ' Accepts: 'A System.Guid object for storing the GUID.
            ' ***

            HidD_GetHidGuid(hidGuid)

            ' Fill an array with the device path names of all attached HIDs.

            deviceFound = MyDeviceManagement.FindDeviceFromGuid _
             (hidGuid,
             devicePathName)

            ' If there is at least one HID, attempt to read the Vendor ID and Product ID
            ' of each device until there is a match or all devices have been examined.

            If deviceFound Then

                memberIndex = 0

                Do
                    ' ***
                    ' API function:
                    ' CreateFile

                    ' Purpose:
                    ' Retrieves a handle to a device.

                    ' Accepts:
                    ' A device path name returned by SetupDiGetDeviceInterfaceDetail
                    ' The type of access requested (read/write).
                    ' FILE_SHARE attributes to allow other processes to access the device while this handle is open.
                    ' A Security structure or IntPtr.Zero. 
                    ' A creation disposition value. Use OPEN_EXISTING for devices.
                    ' Flags and attributes for files. Not used for devices.
                    ' Handle to a template file. Not used.

                    ' Returns: a handle without read or write access.
                    ' This enables obtaining information about all HIDs, even system
                    ' keyboards and mice. 
                    ' Separate handles are used for reading and writing.
                    ' ***

                    ' Open the handle without read/write access to enable getting information about any HID, even system keyboards and mice.

                    hidHandle = CreateFile(devicePathName(memberIndex), 0, FILE_SHARE_READ Or FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, 0, 0)

                    '     Debug.WriteLine(MyDebugging.ResultOfAPICall("CreateFile"))
                    '     Debug.WriteLine("  Returned handle: " & hidHandle.ToString)

                    If Not (hidHandle.IsInvalid) Then

                        ' The returned handle is valid, 
                        ' so find out if this is the device we're looking for.

                        ' Set the Size property of DeviceAttributes to the number of bytes in the structure.

                        MyHid.DeviceAttributes.Size = Marshal.SizeOf(MyHid.DeviceAttributes)

                        ' ***
                        ' API function:
                        ' HidD_GetAttributes

                        ' Purpose:
                        ' Retrieves a HIDD_ATTRIBUTES structure containing the Vendor ID, 
                        ' Product ID, and Product Version Number for a device.

                        ' Accepts:
                        ' A handle returned by CreateFile.
                        ' A pointer to receive a HIDD_ATTRIBUTES structure.

                        ' Returns:
                        ' True on success, False on failure.
                        ' ***

                        success = HidD_GetAttributes(hidHandle, MyHid.DeviceAttributes)

                        If success Then

                            ' Find out if the device matches the one we're looking for.

                            If (MyHid.DeviceAttributes.VendorID = myVendorID) And
                             (MyHid.DeviceAttributes.ProductID = myProductID) Then

                                ' Display the information in form's list box.

                                ' MessageBox.Show("Device detected: Vendor ID= " & Hex(MyHid.DeviceAttributes.VendorID) & "  Product ID = " & Hex(MyHid.DeviceAttributes.ProductID))
                                bellStatus = True

                                Status.Text = "USB BELL CONNECTED"

                                Timer1.Stop()
                                Timer2.Start()
                                myDeviceDetected = True

                                ' Save the DevicePathName for OnDeviceChange().

                                myDevicePathName = devicePathName(memberIndex)
                            Else

                                ' It's not a match, so close the handle.

                                myDeviceDetected = False

                                hidHandle.Close()

                            End If

                        Else
                            ' There was a problem in retrieving the information.

                            myDeviceDetected = False
                            hidHandle.Close()
                        End If

                    End If

                    ' Keep looking until we find the device or there are no devices left to examine.

                    memberIndex = memberIndex + 1

                Loop Until (myDeviceDetected Or (memberIndex = devicePathName.Length))

            End If

            If myDeviceDetected Then

                ' The device was detected.
                ' Register to receive notifications if the device is removed or attached.
                success = True
                'error was here
                Dim xdev1 As New DeviceManagement()
                success = xdev1.RegisterForDeviceNotifications(myDevicePathName, Me.Handle, hidGuid, deviceNotificationHandle)

                ' MessageBox.Show("RegisterForDeviceNotifications = " & success)

                ' Learn the capabilities of the device.

                MyHid.Capabilities = MyHid.GetDeviceCapabilities(hidHandle)

                If success Then

                    ' Find out if the device is a system mouse or keyboard.

                    hidUsage = MyHid.GetHidUsage(MyHid.Capabilities)

                    ' Get the Input report buffer size.

                    ' GetInputReportBufferSize()


                    'Close the handle and reopen it with read/write access.

                    hidHandle.Close()

                    hidHandle = CreateFile(myDevicePathName, GENERIC_READ Or GENERIC_WRITE, FILE_SHARE_READ Or FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, 0, 0)

                    If hidHandle.IsInvalid Then

                        exclusiveAccess = True
                        '        lstResults.Items.Add("The device is a system " + hidUsage + ".")
                        '    lstResults.Items.Add("Windows 2000 and Windows XP obtain exclusive access to Input and Output reports for this devices.")
                        '    lstResults.Items.Add("Applications can access Feature reports only.")
                        '    ScrollToBottomOfListBox()

                    Else

                        If (MyHid.Capabilities.InputReportByteLength > 0) Then

                            ' Set the size of the Input report buffer. 
                            ' Subtract 1 from the value in the Capabilities structure because 
                            ' the array begins at index 0.

                            Array.Resize(inputReportBuffer, MyHid.Capabilities.InputReportByteLength)

                            fileStreamdevicedata = New FileStream(hidHandle, FileAccess.Read Or FileAccess.Write, inputReportBuffer.Length, False)

                        End If

                        If (MyHid.Capabilities.OutputReportByteLength > 0) Then

                            ' Set the size of the Output report buffer. 
                            ' Subtract 1 from the value in the Capabilities structure because 
                            ' the array begins at index 0.

                            Array.Resize(outputReportBuffer, MyHid.Capabilities.OutputReportByteLength)

                        End If

                        ' Flush any waiting reports in the input buffer. (optional)

                        MyHid.FlushQueue(hidHandle)

                    End If
                End If
            Else
                ' The device wasn't detected.
                bellStatus = False
                Status.Text = "USB BELL DISCONNECTED "

                Timer2.Stop()
                Timer1.Start()

            End If

            Return myDeviceDetected

        Catch ex As Exception
            DisplayException(Me.Name, ex)
            Throw
        End Try
    End Function

    Private Sub ExchangeInputAndOutputReports(ByVal command As Byte, ByVal bytec2 As Byte, ByVal bytec3 As Byte)


        Dim inputReportBuffer() As Byte = Nothing
        Dim outputReportBuffer() As Byte = Nothing
        Dim success As Boolean

        Try
            success = False

            ' Don't attempt to exchange reports if valid handles aren't available
            ' (as for a mouse or keyboard under Windows 2000/XP.)

            If (Not (hidHandle.IsInvalid)) Then

                ' Don't attempt to send an Output report if the HID has no Output report.

                If (MyHid.Capabilities.OutputReportByteLength > 0) Then

                    ' Set the upper bound of the Output report buffer. 
                    ' Subtract 1 from OutputReportByteLength because the array begins at index 0.

                    Array.Resize(outputReportBuffer, MyHid.Capabilities.OutputReportByteLength)

                    ' Store the report ID in the first byte of the buffer:

                    outputReportBuffer(0) = 0

                    ' Store the report data following the report ID.
                    ' Use the data in the combo boxes on the form.
                    outputReportBuffer(1) = command
                    outputReportBuffer(2) = bytec2
                    outputReportBuffer(3) = bytec3

                    Dim ijk As Integer
                    For ijk = 4 To UBound(outputReportBuffer)
                        outputReportBuffer(ijk) = &HFF
                    Next ijk

                    ' Write a report.

                    ' If the HID has an interrupt OUT endpoint, the host uses an 
                    ' interrupt transfer to send the report. 
                    ' If not, the host uses a control transfer.

                    If (fileStreamdevicedata.CanWrite) Then
                        fileStreamdevicedata.Write(outputReportBuffer, 0, outputReportBuffer.Length)
                        success = True
                    Else
                        CloseCommunications()
                        MessageBox.Show("The attempt to read an Input report has failed.")
                    End If


                    If success Then

                        ' MessageBox.Show("An Output report has been written.")

                        ' Display the report data in the form's list box.


                        ' MessageBox.Show(" Output Report ID: " & String.Format("{0:X2} ", outputReportBuffer(0)))
                        ' MessageBox.Show(" Output Report Data:")


                        ' For count = 1 To UBound(outputReportBuffer)

                        ' Display bytes as 2-character hex strings.

                        ' byteValue = String.Format("{0:X2} ", outputReportBuffer(count))

                        '   Next count
                    Else
                        CloseCommunications()
                        MessageBox.Show("The attempt to write an Output report failed.")
                    End If


                Else
                    MessageBox.Show("The HID doesn't have an Output report.")
                End If

                ' Read an Input report.

                success = False

                ' Don't attempt to send an Input report if the HID has no Input report.
                ' (The HID spec requires all HIDs to have an interrupt IN endpoint,
                ' which suggests that all HIDs must support Input reports.)

                If (MyHid.Capabilities.InputReportByteLength > 0) Then

                    ' Set the size of the Input report buffer. 
                    ' Subtract 1 from the value in the Capabilities structure because 
                    ' the array begins at index 0.

                    Array.Resize(inputReportBuffer, MyHid.Capabilities.InputReportByteLength)

                    ' Read a report using interrupt transfers.                
                    ' To enable reading a report without blocking the main thread, this
                    ' application uses an asynchronous delegate.

                    Dim ar As IAsyncResult = Nothing
                    transferInProgress = True

                    ' Timeout if no report is available.

                    ' tmrReadTimeout.Start()

                    If (fileStreamdevicedata.CanRead) Then

                        fileStreamdevicedata.BeginRead(inputReportBuffer, 0, inputReportBuffer.Length, New AsyncCallback(AddressOf GetInputReportData), inputReportBuffer)

                    Else
                        CloseCommunications()
                        MessageBox.Show("The attempt to read an Input report has failed.")
                    End If

                Else
                    MessageBox.Show("No attempt to read an Input report was made.")
                    MessageBox.Show("The HID doesn't have an Input report.")
                    MessageBox.Show("EnableCmdOnce", "")
                End If
            Else
                MessageBox.Show("Invalid handle. The device is probably a system mouse or keyboard.")
                MessageBox.Show("No attempt to write an Output report or read an Input report was made.")
                MessageBox.Show("EnableCmdOnce", "")
            End If



        Catch ex As Exception
            DisplayException(Me.Name, ex)
            Throw
        End Try

    End Sub

    ''' <summary>
    ''' Retrieves Input report data and status information.
    ''' This routine is called automatically when myInputReport.Read
    ''' returns. Calls several marshaling routines to access the main form.
    ''' </summary>
    ''' 
    ''' <param name="ar"> an object containing status information about 
    ''' the asynchronous operation. </param>

    Private Sub GetInputReportData(ByVal ar As IAsyncResult)


        Dim count As Int32
        Dim inputReportBuffer As Byte() = Nothing

        Try
            inputReportBuffer = CType(ar.AsyncState, Byte())

            fileStreamdevicedata.EndRead(ar)

            '                                      tmrReadTimeout.Stop()

            ' Display the received report data in the form's list box.

            If (ar.IsCompleted) Then

                '   MessageBox.Show("AddItemToListBox", "An Input report has been read.")

                '   MessageBox.Show("AddItemToListBox", " Input Report ID: " & String.Format("{0:X2} ", inputReportBuffer(0)))

                '   MessageBox.Show("AddItemToListBox", " Input Report Data:")

                For count = 1 To UBound(inputReportBuffer)

                    ' Display bytes as 2-character Hex strings.
                    mydata1(count) = inputReportBuffer(count)

                Next count

            Else
                MessageBox.Show("The attempt to read an Input report has failed.")
                Debug.Write("The attempt to read an Input report has failed")
            End If

            ' MessageBox.Show("ScrollToBottomOfListBox", "")

            ' Enable requesting another transfer.

            ' MessageBox.Show("EnableCmdOnce", "")
            transferInProgress = False

        Catch ex As Exception
            '   DisplayException(Me.Name, ex)
            '   Throw
        End Try

    End Sub

    ''' <summary>
    ''' Close the handle and FileStreams for a device.
    ''' </summary>

    Private Sub CloseCommunications()

        If (Not (fileStreamdevicedata Is Nothing)) Then

            fileStreamdevicedata.Close()
        End If

        If ((Not (hidHandle Is Nothing)) And (Not hidHandle.IsInvalid)) Then

            hidHandle.Close()
        End If

        ' The next attempt to communicate will get new handles and FileStreams.

        myDeviceDetected = False


    End Sub

    Private Sub usbio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FindTheHid()
        InitializeMaterialSkin()
        InitializeAnalogClock()

        bellTimings = New List(Of [String])()

        Dim lines() As String = IO.File.ReadAllLines("TimingNames.txt")

        For Each line As String In lines
            lvTimings.Items.Add(line)
        Next


        lvTimings.Items(0).Selected = True

        filename = "Timing1.txt"

        ReadFile()
    End Sub


    Private Sub InitializeMaterialSkin()
        Dim SkinManager As MaterialSkinManager = MaterialSkinManager.Instance
        SkinManager.AddFormToManage(Me)
        SkinManager.Theme = MaterialSkinManager.Themes.DARK
        SkinManager.ColorScheme = New ColorScheme(Primary.Grey800, Primary.Grey900, Primary.Grey500, Accent.Amber100, TextShade.WHITE)
    End Sub


    Private Sub InitializeAnalogClock()
        PictureBox1.Image = ClockFace
        WhitePen1.SetLineCap(LineCap.Round, LineCap.Round, DashCap.Flat)
        DoubleBuffered = True

        CalculateIncrements()
        DrawClockFace()

    End Sub
    Private Sub DrawClockFace()
        gr.SmoothingMode = SmoothingMode.HighQuality
        'Draw Clock Background 
        gr.DrawEllipse(Pens.White, 90, 90, 260, 260)
        'Draw Increments around cicumferance 
        For I As Integer = 1 To 60
            gr.DrawLine(WhitePen, StartPoint(I), EndPoint(I))
        Next
    End Sub
    Private Sub CalculateIncrements()
        Dim X, Y As Integer
        Dim radius As Integer
        For I As Integer = 1 To 60
            radius = 160
            'Calculate Start Point 
            X = CInt(radius * Math.Cos((90 - I * 6) * Convert1)) + 220
            Y = 220 - CInt(radius * Math.Sin((90 - I * 6) * Convert1))
            StartPoint(I) = New PointF(X, Y)
            'Calculate End Point 
            X = CInt(170 * Math.Cos((90 - I * 6) * Convert1)) + 220
            Y = 220 - CInt(170 * Math.Sin((90 - I * 6) * Convert1))
            EndPoint(I) = New PointF(X, Y)
        Next
    End Sub
    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality
        'Draw Clock Background 
        e.Graphics.DrawImage(ClockFace, Point.Empty)
        'Draw Hands 
        e.Graphics.DrawLine(WhitePen1, 220, 220, HrX, HrY)
        e.Graphics.FillEllipse(Brushes.White, 210, 210, 20, 20)
        e.Graphics.DrawLine(WhitePen1, 220, 220, MinX, MinY)
        e.Graphics.FillEllipse(Brushes.White, 212, 212, 16, 16)
        e.Graphics.DrawLine(WhitePen2, 220, 220, SecX, SecY)
        Dim GreyBrush As SolidBrush = New SolidBrush(Color.FromArgb(67, 67, 67))
        e.Graphics.FillEllipse(GreyBrush, 215, 215, 10, 10)
    End Sub

    Private Sub TimerClock_Tick(sender As Object, e As EventArgs) Handles TimerClock.Tick

        'Analog Clock
        'Set The Angle of the Second, Minute and Hour hand according to the time 
        SecAngle = (Now.Second * 6)
        MinAngle = (Now.Minute + Now.Second / 60) * 6
        HrAngle = (Now.Hour + Now.Minute / 60) * 30
        'Get the X,Y co-ordinates of the end point of each hand 
        SecX = CInt(SecRadius * Math.Cos((90 - SecAngle) * Convert1)) + 220
        SecY = 220 - CInt(SecRadius * Math.Sin((90 - SecAngle) * Convert1))
        MinX = CInt(MinRadius * Math.Cos((90 - MinAngle) * Convert1)) + 220
        MinY = 220 - CInt(MinRadius * Math.Sin((90 - MinAngle) * Convert1))
        HrX = CInt(HrRadius * Math.Cos((90 - HrAngle) * Convert1)) + 220
        HrY = 220 - CInt(HrRadius * Math.Sin((90 - HrAngle) * Convert1))
        Refresh()

        PictureBox1.Refresh()
        'Analog Clock

        Dim time As String = DateTime.Now.ToString("HH:mm")
        lTime.Text = time

        For Each eachItem As ListViewItem In lvBell.Items
            If eachItem.SubItems(0).Text.Equals(time) Then
                TimerClock.Stop()
                FindTheHid()
                ReadAndWriteToDevice1()
                Me.stopwatch.Restart()
                duration = Int32.Parse(eachItem.SubItems(1).Text)
                bellOn = True
                lBell.Text = "ON"
                TimerClock2.Start()
            End If
        Next
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        FindTheHid()

    End Sub

    Private Sub ReadAndWriteToDevice1()

        Try
            ' If the device hasn't been detected, was removed, or timed out on a previous attempt
            ' to access it, look for the device.

            If (myDeviceDetected = False) Then

                myDeviceDetected = FindTheHid()

            End If

            If (myDeviceDetected = True) Then

                ' Get the bytes to send in a report from the combo boxes.
                ' Increment the values if the autoincrement check box is selected.



                ' An option button selects whether to exchange Input and Output reports
                ' or Feature reports.
                Dim byte2, byte3 As Byte

                If flagb = True Then
                    byte2 = Byte.Parse("FF", NumberStyles.AllowHexSpecifier)
                    flagb = False
                Else
                    byte2 = Convert.ToByte(255)
                End If

                ExchangeInputAndOutputReports(&H80, byte2, byte3)
            End If
        Catch ex As Exception


        End Try

    End Sub

    Private Sub ReadAndWriteToDevice2()

        Try
            ' If the device hasn't been detected, was removed, or timed out on a previous attempt
            ' to access it, look for the device.

            If (myDeviceDetected = False) Then

                myDeviceDetected = FindTheHid()

            End If

            If (myDeviceDetected = True) Then

                ' Get the bytes to send in a report from the combo boxes.
                ' Increment the values if the autoincrement check box is selected.

                ' An option button selects whether to exchange Input and Output reports
                ' or Feature reports.
                Dim byte2, byte3 As Byte

                If flagb = True Then
                    byte2 = Byte.Parse("0", NumberStyles.AllowHexSpecifier)
                    flagb = False
                Else
                    byte2 = Convert.ToByte(0)
                End If

                ExchangeInputAndOutputReports(&H80, byte2, byte3)
            End If
        Catch ex As Exception


        End Try

    End Sub

    Private Sub lvTimings_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvTimings.SelectedIndexChanged

        If lvTimings.SelectedItems.Count > 0 Then
            Dim str As String = lvTimings.SelectedItems(0).Text
            Dim suffix As Integer = lvTimings.SelectedIndices(0) + 1
            filename = Convert.ToString("Timing") & Convert.ToString(suffix) & Convert.ToString(".txt")
            bellTimings.Clear()
            lvBell.Items.Clear()
        End If

        ReadFile()

    End Sub

    Private Sub ReadFile()

        Dim counter As Integer = 0
        Dim line As String = ""

        ' Read the file and display it line by line.
        Dim file As New StreamReader(filename)

        bellTimings.Clear()
        lvBell.Items.Clear()

        While (InlineAssignHelper(line, file.ReadLine())) IsNot Nothing
            bellTimings.Add(line)
            updateListView()

            counter += 1
        End While

        file.Close()


    End Sub

    Private Sub updateListView()
        Dim listViewItem = New ListViewItem(bellTimings(bellTimings.Count - 1).Split("#"c))
        lvBell.Items.Add(listViewItem)

    End Sub

    Private Sub TimerClock2_Tick(sender As Object, e As EventArgs) Handles TimerClock2.Tick
        Dim elapsed As TimeSpan = Me.stopwatch.Elapsed
        If elapsed.Seconds > duration Then
            If bellOn Then
                bellOn = False
                FindTheHid()
                ReadAndWriteToDevice2()
                lBell.Text = "OFF"
            End If
            If elapsed.Seconds > 58 Then
                Me.stopwatch.Stop()
                TimerClock2.Stop()
                TimerClock.Start()
            End If
        End If

    End Sub

    Private Sub bTest_Click(sender As Object, e As EventArgs) Handles bTest.Click
        If bellStatus = True Then

            If bellOn = False Then
                TimerClock.Stop()
                TimerClock2.Stop()
                stopwatch.Stop()
                bellOn = True
                lBell.Text = "ON"
                bTest.Text = "Test Off"
                FindTheHid()
                ReadAndWriteToDevice1()
            Else
                TimerClock.Start()
                bellOn = False
                lBell.Text = "OFF"
                bTest.Text = "Test On"
                FindTheHid()
                ReadAndWriteToDevice2()
            End If
        End If

    End Sub

    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
        target = value
        Return value
    End Function


    ''' <summary>
    ''' Add Modify
    ''' </summary>

    Private Sub MaterialTabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MaterialTabControl1.SelectedIndexChanged
        If MaterialTabControl1.SelectedIndex = 1 Then
            Dim lines() As String = IO.File.ReadAllLines("TimingNames.txt")
            lvTimings_Mod.Items.Clear()

            For Each line As String In lines
                lvTimings_Mod.Items.Add(line)
            Next
            lvTimings_Mod.Items(0).Selected = True
            filename = "Timing1.txt"

            readFileMod()
        End If
        If MaterialTabControl1.SelectedIndex = 0 Then
            saveTimings()
        End If
    End Sub

    Private Sub bSave_Click(sender As Object, e As EventArgs) Handles bSave.Click

        saveTimings()
        MaterialTabControl1.SelectedIndex = 0
    End Sub

    Private Sub saveTimings()
        bellTimings.Clear()
        lvBell.Items.Clear()

        lvTimings.Items.Clear()

        Dim lines() As String = IO.File.ReadAllLines("TimingNames.txt")

        For Each line As String In lines
            lvTimings.Items.Add(line)
        Next

        lvTimings.Items(0).Selected = True
        filename = "Timing1.txt"

        ReadFile()
    End Sub

    Private Sub lvTimings_Mod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvTimings_Mod.SelectedIndexChanged
        If lvTimings_Mod.SelectedItems.Count > 0 Then
            Dim str As String = lvTimings_Mod.SelectedItems(0).Text
            Dim suffix As Integer = lvTimings_Mod.SelectedIndices(0) + 1
            filename = Convert.ToString("Timing") & Convert.ToString(suffix) & Convert.ToString(".txt")
            bellTimings.Clear()
            lvBell_Mod.Items.Clear()
        End If

        readFileMod()
    End Sub

    Private Sub bAddBell_Click(sender As Object, e As EventArgs) Handles bAddBell.Click
        Dim row As String() = {dtpTime.Text, nupDuration.Text}

        Dim flag As Boolean = False
        For Each eachItem As ListViewItem In lvBell_Mod.Items
            If eachItem.SubItems(0).Text.Equals(row(0)) Then
                flag = True
            End If
        Next

        If Not flag Then
            bellTimings.Add(row(0) + "#" + row(1))

            updateListViewMod()

            bellTimings.Sort()

            Dim tw As TextWriter = New StreamWriter(filename, False)

            For Each s As [String] In bellTimings
                tw.WriteLine(s)
            Next

            tw.Close()
        End If
    End Sub

    Private Sub bDeleteBell_Click(sender As Object, e As EventArgs) Handles bDeleteBell.Click
        Dim indices As ListView.SelectedIndexCollection = lvBell_Mod.SelectedIndices

        For Each i As Integer In indices
            bellTimings.RemoveAt(i)
        Next
        For Each eachItem As ListViewItem In lvBell_Mod.SelectedItems
            lvBell_Mod.Items.Remove(eachItem)
        Next
        bellTimings.Sort()


        Dim fw As New StreamWriter(filename, False)
        For i As Integer = 0 To bellTimings.Count - 1
            fw.WriteLine(bellTimings(i))
        Next

        fw.Close()
    End Sub

    Private Sub readFileMod()

        Dim counter As Integer = 0
        Dim line As String = ""


        ' Read the file and display it line by line.
        Dim file As New StreamReader(filename)

        lvBell_Mod.Items.Clear()
        bellTimings.Clear()

        While (InlineAssignHelper(line, file.ReadLine())) IsNot Nothing
            bellTimings.Add(line)
            updateListViewMod()

            counter += 1
        End While

        file.Close()

    End Sub

    Private Sub updateListViewMod()
        Dim listViewItem = New ListViewItem(bellTimings(bellTimings.Count - 1).Split("#"c))
        lvBell_Mod.Items.Add(listViewItem)
    End Sub

    Private Sub lvTimings_Mod_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lvTimings_Mod.MouseDoubleClick
        Dim rename = New Rename
        If rename.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim index As Integer
            If lvTimings_Mod.SelectedItems.Count > 0 Then

                index = lvTimings_Mod.SelectedIndices(0)

            End If
            Dim newName As String = rename.tbRename.Text

            lvTimings_Mod.Items.RemoveAt(index)

            Dim lines() As String = System.IO.File.ReadAllLines("TimingNames.txt")
            lines(index) = newName
            System.IO.File.WriteAllLines("TimingNames.txt", lines)

            lvTimings_Mod.Items.Insert(index, newName)


        End If
    End Sub

End Class
