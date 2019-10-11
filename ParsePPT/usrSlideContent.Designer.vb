<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class usrSlideContent
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
        Me.txtHighLevelTopic = New System.Windows.Forms.Label()
        Me.txtSlideNumber = New System.Windows.Forms.Label()
        Me.txtState = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtHighLevelTopic
        '
        Me.txtHighLevelTopic.AutoSize = True
        Me.txtHighLevelTopic.Location = New System.Drawing.Point(79, 0)
        Me.txtHighLevelTopic.Name = "txtHighLevelTopic"
        Me.txtHighLevelTopic.Size = New System.Drawing.Size(88, 13)
        Me.txtHighLevelTopic.TabIndex = 6
        Me.txtHighLevelTopic.Text = "High Level Topic"
        '
        'txtSlideNumber
        '
        Me.txtSlideNumber.AutoSize = True
        Me.txtSlideNumber.Location = New System.Drawing.Point(3, 0)
        Me.txtSlideNumber.Name = "txtSlideNumber"
        Me.txtSlideNumber.Size = New System.Drawing.Size(70, 13)
        Me.txtSlideNumber.TabIndex = 5
        Me.txtSlideNumber.Text = "Slide Number"
        '
        'txtState
        '
        Me.txtState.AutoSize = True
        Me.txtState.Location = New System.Drawing.Point(455, 0)
        Me.txtState.Name = "txtState"
        Me.txtState.Size = New System.Drawing.Size(32, 13)
        Me.txtState.TabIndex = 7
        Me.txtState.Text = "State"
        '
        'usrSlideContent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.txtState)
        Me.Controls.Add(Me.txtHighLevelTopic)
        Me.Controls.Add(Me.txtSlideNumber)
        Me.Name = "usrSlideContent"
        Me.Size = New System.Drawing.Size(520, 16)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtHighLevelTopic As Windows.Forms.Label
    Friend WithEvents txtSlideNumber As Windows.Forms.Label
    Friend WithEvents txtState As Windows.Forms.Label
End Class
