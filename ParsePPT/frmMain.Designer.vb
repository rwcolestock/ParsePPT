<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.panelStep = New System.Windows.Forms.Panel()
        Me.lblStepText = New System.Windows.Forms.Label()
        Me.lblStepNumber = New System.Windows.Forms.Label()
        Me.panelMain = New System.Windows.Forms.FlowLayoutPanel()
        Me.panelButtons = New System.Windows.Forms.Panel()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.panelStep.SuspendLayout()
        Me.panelButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelStep
        '
        Me.panelStep.BackColor = System.Drawing.Color.White
        Me.panelStep.Controls.Add(Me.lblStepText)
        Me.panelStep.Controls.Add(Me.lblStepNumber)
        Me.panelStep.Location = New System.Drawing.Point(12, 12)
        Me.panelStep.Name = "panelStep"
        Me.panelStep.Size = New System.Drawing.Size(602, 59)
        Me.panelStep.TabIndex = 1
        '
        'lblStepText
        '
        Me.lblStepText.AutoSize = True
        Me.lblStepText.Location = New System.Drawing.Point(15, 33)
        Me.lblStepText.Name = "lblStepText"
        Me.lblStepText.Size = New System.Drawing.Size(305, 13)
        Me.lblStepText.TabIndex = 2
        Me.lblStepText.Text = "Select the presentation to read and then click the 'Next' button."
        '
        'lblStepNumber
        '
        Me.lblStepNumber.AutoSize = True
        Me.lblStepNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStepNumber.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblStepNumber.Location = New System.Drawing.Point(15, 11)
        Me.lblStepNumber.Name = "lblStepNumber"
        Me.lblStepNumber.Size = New System.Drawing.Size(44, 13)
        Me.lblStepNumber.TabIndex = 1
        Me.lblStepNumber.Text = "Step 1"
        '
        'panelMain
        '
        Me.panelMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.panelMain.Location = New System.Drawing.Point(12, 77)
        Me.panelMain.Name = "panelMain"
        Me.panelMain.Size = New System.Drawing.Size(602, 264)
        Me.panelMain.TabIndex = 2
        '
        'panelButtons
        '
        Me.panelButtons.BackColor = System.Drawing.Color.Silver
        Me.panelButtons.Controls.Add(Me.btnNext)
        Me.panelButtons.Controls.Add(Me.btnCancel)
        Me.panelButtons.Location = New System.Drawing.Point(12, 347)
        Me.panelButtons.Name = "panelButtons"
        Me.panelButtons.Size = New System.Drawing.Size(602, 48)
        Me.panelButtons.TabIndex = 3
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(515, 13)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(75, 23)
        Me.btnNext.TabIndex = 1
        Me.btnNext.Text = "&Next ->"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(434, 13)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(626, 410)
        Me.Controls.Add(Me.panelButtons)
        Me.Controls.Add(Me.panelMain)
        Me.Controls.Add(Me.panelStep)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.Text = "Presentation Extractor"
        Me.panelStep.ResumeLayout(False)
        Me.panelStep.PerformLayout()
        Me.panelButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelStep As Windows.Forms.Panel
    Friend WithEvents lblStepText As Windows.Forms.Label
    Friend WithEvents lblStepNumber As Windows.Forms.Label
    Friend WithEvents panelMain As Windows.Forms.FlowLayoutPanel
    Friend WithEvents panelButtons As Windows.Forms.Panel
    Friend WithEvents btnNext As Windows.Forms.Button
    Friend WithEvents btnCancel As Windows.Forms.Button
End Class
