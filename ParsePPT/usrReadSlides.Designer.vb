<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class usrReadSlides
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.lblSlideNumber = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.panelSlideContents = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblSlideNumber
        '
        Me.lblSlideNumber.AutoSize = True
        Me.lblSlideNumber.Location = New System.Drawing.Point(24, 11)
        Me.lblSlideNumber.Name = "lblSlideNumber"
        Me.lblSlideNumber.Size = New System.Drawing.Size(70, 13)
        Me.lblSlideNumber.TabIndex = 3
        Me.lblSlideNumber.Text = "Slide Number"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(100, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "High Level Topic"
        '
        'panelSlideContents
        '
        Me.panelSlideContents.AutoScroll = True
        Me.panelSlideContents.BackColor = System.Drawing.Color.White
        Me.panelSlideContents.Location = New System.Drawing.Point(18, 28)
        Me.panelSlideContents.Name = "panelSlideContents"
        Me.panelSlideContents.Size = New System.Drawing.Size(567, 221)
        Me.panelSlideContents.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(476, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "State"
        '
        'usrReadSlides
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.panelSlideContents)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblSlideNumber)
        Me.Name = "usrReadSlides"
        Me.Size = New System.Drawing.Size(602, 264)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblSlideNumber As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents panelSlideContents As Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label2 As Windows.Forms.Label
End Class
