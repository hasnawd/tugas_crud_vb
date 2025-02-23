<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormArtist
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
        components = New ComponentModel.Container()
        Button1 = New Button()
        Button2 = New Button()
        MySqlCommand1 = New MySql.Data.MySqlClient.MySqlCommand()
        dgvArtist = New DataGridView()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        ContextMenuStrip2 = New ContextMenuStrip(components)
        SettingToolStripMenuItem = New ToolStripMenuItem()
        CType(dgvArtist, ComponentModel.ISupportInitialize).BeginInit()
        ContextMenuStrip2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(1170, 12)
        Button1.Name = "Button1"
        Button1.Size = New Size(94, 29)
        Button1.TabIndex = 1
        Button1.Text = "Logout"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(12, 64)
        Button2.Name = "Button2"
        Button2.Size = New Size(94, 29)
        Button2.TabIndex = 2
        Button2.Text = "Add data"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' MySqlCommand1
        ' 
        MySqlCommand1.CacheAge = 0
        MySqlCommand1.Connection = Nothing
        MySqlCommand1.EnableCaching = False
        MySqlCommand1.Transaction = Nothing
        ' 
        ' dgvArtist
        ' 
        dgvArtist.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvArtist.Location = New Point(12, 111)
        dgvArtist.Name = "dgvArtist"
        dgvArtist.RightToLeft = RightToLeft.No
        dgvArtist.RowHeadersWidth = 51
        dgvArtist.Size = New Size(1252, 188)
        dgvArtist.TabIndex = 3
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.ImageScalingSize = New Size(20, 20)
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(61, 4)
        ' 
        ' ContextMenuStrip2
        ' 
        ContextMenuStrip2.ImageScalingSize = New Size(20, 20)
        ContextMenuStrip2.Items.AddRange(New ToolStripItem() {SettingToolStripMenuItem})
        ContextMenuStrip2.Name = "ContextMenuStrip2"
        ContextMenuStrip2.Size = New Size(126, 28)
        ' 
        ' SettingToolStripMenuItem
        ' 
        SettingToolStripMenuItem.Name = "SettingToolStripMenuItem"
        SettingToolStripMenuItem.Size = New Size(125, 24)
        SettingToolStripMenuItem.Text = "Setting"
        ' 
        ' FormArtist
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1276, 450)
        Controls.Add(dgvArtist)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Enabled = False
        Name = "FormArtist"
        Text = "FormArtist"
        CType(dgvArtist, ComponentModel.ISupportInitialize).EndInit()
        ContextMenuStrip2.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents MySqlCommand1 As MySql.Data.MySqlClient.MySqlCommand
    Friend WithEvents dgvArtist As DataGridView
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents SettingToolStripMenuItem As ToolStripMenuItem
End Class
