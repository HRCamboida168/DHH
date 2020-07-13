Imports System.Windows.Forms

Public Class frmBill002AddItem
    Dim dbHpr As New db_helper
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If txtName.Text.Trim = "" Then
            MsgBox("Please input Item name!!!", MsgBoxStyle.Critical, "ItemAdd")
            txtName.Focus()
            Exit Sub
        End If

        With frm_sale_inv_add
            For Each r As DataGridViewRow In .dgvOthers.Rows
                If r.Cells(1).Value.ToString.ToLower = txtName.Text.ToLower Then
                    MsgBox("Item is already added!!!", MsgBoxStyle.Exclamation, "Add Item")
                    txtName.Focus()
                    Exit Sub
                End If
            Next

            If txtPrice.Text.Trim = "" Or txtPrice.Text = "0" Then
                MsgBox("Please in put price of item!!!", MsgBoxStyle.Critical, "ItemAdd")
                txtPrice.Focus()
                Exit Sub
            End If
            If txtQty.Text.Trim = "" Or txtQty.Text = "0" Then
                MsgBox("Please input Item QTY!!!", MsgBoxStyle.Critical, "ItemAdd")
                txtQty.Focus()
                Exit Sub
            End If

            'add menu item if not exist in menu
            Dim menuNum As String = dbHpr.GenerateID("select max(menu_num) from tgh_food_menus", 3, "SD")
            If txtCode.Text.Trim = "" Then
                Dim errMsg As String = ""
                errMsg = dbHpr.ExecStored("tgh_food_menus_ins_no_img", "po_retrn", "menu_num", menuNum, "menu_nm", txtName.Text, "menu_nm_kh", "", "menu_desc", "", "menu_price", txtPrice.Text, "menu_cat", cboType.SelectedValue)
            End If
            'add row
            .dgvItem.Rows.Add(IIf(txtCode.Text.Trim = "", menuNum, txtCode.Text),
                                txtName.Text,
                                cboType.SelectedValue,
                                txtPrice.Text,
                                txtQty.Text,
                                txtAmt.Text,
                                0,
                                0)

            txtName.Text = ""
            txtCode.Text = ""
            txtPrice.Text = "0"
            txtQty.Text = "0"
            txtAmt.Text = "0"

            txtNetAmt.Text = "0"
            txtName.Focus()
        End With
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Sub ItemList()
        Dim str As String = "select top 5 m.menu_num,m.menu_nm,m.menu_cat,m.menu_price from tgh_food_menus m where m.stat_cd='A'  and m.menu_nm like   '%'+'" & txtName.Text & "'+'%'"
        Dim tbl As DataTable = dbHpr.SelectData(str, "ItemList")
        If tbl.Rows.Count > 0 Then
            'CLEAR COL ROWS
            dgvOthers.Rows.Clear()
            dgvOthers.Height = 20
            'SET NEW ROWS
            For Each r As DataRow In tbl.Rows
                dgvOthers.Rows.Add(r(0), r(1), r(2), r(3))
                dgvOthers.Height = dgvOthers.Height + 20
            Next
            dgvOthers.Visible = True

            'SET LOCATION
            dgvOthers.Left = txtName.Left
            dgvOthers.Top = txtName.Bottom
            dgvOthers.Width = txtName.Width

        Else
            dgvOthers.Visible = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        ItemList()
    End Sub

    Private Sub txtName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtName.KeyPress
        If e.KeyChar = Chr(8) Then
            ItemList()
        End If
    End Sub

    Private Sub txtName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtName.KeyDown
        If (e.KeyValue >= 48 And e.KeyValue <= 57) Or (e.KeyValue >= 65 And e.KeyValue <= 90) Or (e.KeyValue >= 96 And e.KeyValue <= 105) Then
            ItemList()
        ElseIf e.KeyCode = Keys.Enter Then
            If txtCode.Text.Trim <> "" Then
                SelectNextControl(sender, True, True, True, True)
            Else
                ItemList()
            End If
            If dgvOthers.Visible = True Then
                dgvOthers.Focus()
                dgvOthers.Rows(0).Selected = True
            End If
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Back Then
            txtCode.Text = ""
            txtPrice.Text = "0"
        ElseIf e.KeyCode = Keys.Escape Then
            dgvOthers.Visible = False
            txtName.Focus()
        ElseIf e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
            If dgvOthers.Visible = True Then
                dgvOthers.Focus()
            End If
        End If
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        Dim str As String = "select  m.menu_num  from tgh_food_menus m where m.stat_cd='A'  and lower(m.menu_nm) ='" & txtName.Text.ToLower & "'"
        Dim tbl As DataTable = dbHpr.SelectData(str, "ItemList")
        If tbl.Rows.Count = 0 Then
            txtCode.Text = ""
            cboType.Enabled = True
            txtPrice.Enabled = True
        Else
            cboType.Enabled = False
            txtPrice.Enabled = False
        End If
    End Sub

    Private Sub dgvOthers_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvOthers.KeyDown
        If e.KeyCode = Keys.Enter Then
            Get_Val_item()
            dgvOthers.Visible = False
        ElseIf e.KeyCode = Keys.Escape Then
            dgvOthers.Visible = False
        End If
    End Sub
    Sub Get_Val_item()
        If dgvOthers.SelectedRows.Count > 0 Then
            txtCode.Text = ""
            txtName.Text = ""
            txtPrice.Text = ""
            txtCode.Text = dgvOthers.SelectedCells(0).Value
            txtName.Text = dgvOthers.SelectedCells(1).Value
            cboType.SelectedValue = dgvOthers.SelectedCells(2).Value
            txtPrice.Text = dgvOthers.SelectedCells(3).Value
            txtQty.Focus()
        Else
            dgvOthers.Visible = False
        End If
    End Sub

    Private Sub txtName_LostFocus(sender As Object, e As EventArgs) Handles txtName.LostFocus

    End Sub

    Private Sub txtPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQty.KeyPress, txtPrice.KeyPress, txtAmt.KeyPress
        NumericInput(e)
    End Sub

    Private Sub txtPrice_TextChanged(sender As Object, e As EventArgs) Handles txtQty.TextChanged, txtPrice.TextChanged
        txtAmt.Text = IIf(IsNumeric(txtPrice.Text) = True, txtPrice.Text, 0) * IIf(IsNumeric(txtQty.Text) = True, txtQty.Text, 0)
    End Sub

    Private Sub dgvOthers_LostFocus(sender As Object, e As EventArgs) Handles dgvOthers.LostFocus
        dgvOthers.Visible = False
    End Sub

    Private Sub dgvOthers_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOthers.CellDoubleClick
        Get_Val_item()
        dgvOthers.Visible = False
    End Sub

    Private Sub txtPrice_KeyDown(sender As Object, e As KeyEventArgs) Handles txtQty.KeyDown, txtPrice.KeyDown, txtAmt.KeyDown, cboType.KeyDown
        If e.KeyCode = Keys.Enter Then
            SelectNextControl(sender, True, True, True, True)
        End If
    End Sub

End Class
