Imports System.Windows.Forms

Public Class frm_sale_inv_add
    Dim dbhpr As New db_helper
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click, Label2.Click, Label5.Click, Label4.Click, Label3.Click

    End Sub

    Private Sub txtcli_num_TextChanged(sender As Object, e As EventArgs) Handles txtcli_num.TextChanged

    End Sub

    Private Sub frm_sale_inv_add_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSexcode.SelectedIndexChanged

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles txtphoneNum.TextChanged

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles txtAddress.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub txtClinm_TextChanged(sender As Object, e As EventArgs) Handles txtClinm.TextChanged

    End Sub

    Private Sub txtClinm_KeyDown(sender As Object, e As KeyEventArgs) Handles txtClinm.KeyDown, txtVAT.KeyDown, txtphoneNum.KeyDown, txtNetAmt.KeyDown, txtMobilNum.KeyDown, txtMail.KeyDown, txtGrosamt.KeyDown, txtDiscntAmt.KeyDown, txtAddress.KeyDown, dtpInvDt.KeyDown, ComboBox1.KeyDown, cboSexcode.KeyDown
        If e.KeyCode = Keys.Enter Then
            SelectNextControl(sender, True, True, True, True)
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click


        With frmBill002AddItem
            Dim sqlStr As String = "select crcy_code,concat(crcy_code,': ', crcy_desc_en ) crcy_desc from tcurrency_masters where stat_cd='A'"
            Dim tbl As DataTable = dbhpr.SelectData(sqlStr, "client type")
            .cboType.DataSource = tbl
            .cboType.DisplayMember = "crcy_desc"
            .cboType.ValueMember = "crcy_code"

            .ShowDialog()
            If .DialogResult = System.Windows.Forms.DialogResult.Cancel Then
                .Close()
                .Dispose()

            End If

        End With
    End Sub
End Class
