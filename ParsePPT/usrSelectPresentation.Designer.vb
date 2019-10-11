<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class usrSelectPresentation
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
        Me.lblPresentation = New System.Windows.Forms.Label()
        Me.txtPresentation = New System.Windows.Forms.TextBox()
        Me.dialogOpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblPresentation
        '
        Me.lblPresentation.AutoSize = True
        Me.lblPresentation.Location = New System.Drawing.Point(15, 10)
        Me.lblPresentation.Name = "lblPresentation"
        Me.lblPresentation.Size = New System.Drawing.Size(66, 13)
        Me.lblPresentation.TabIndex = 0
        Me.lblPresentation.Text = "Presentation"
        '
        'txtPresentation
        '
        Me.txtPresentation.Location = New System.Drawing.Point(87, 7)
        Me.txtPresentation.Name = "txtPresentation"
        Me.txtPresentation.Size = New System.Drawing.Size(423, 20)
        Me.txtPresentation.TabIndex = 1
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(512, 6)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(32, 22)
        Me.btnBrowse.TabIndex = 2
        Me.btnBrowse.Text = "---"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'usrSelectPresentation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.txtPresentation)
        Me.Controls.Add(Me.lblPresentation)
        Me.Name = "usrSelectPresentation"
        Me.Size = New System.Drawing.Size(602, 264)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblPresentation As Windows.Forms.Label
    Friend WithEvents txtPresentation As Windows.Forms.TextBox
    Friend WithEvents dialogOpenFile As Windows.Forms.OpenFileDialog
    Friend WithEvents btnBrowse As Windows.Forms.Button
End Class
