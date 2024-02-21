﻿Public Class penjualan
    Dim id = "0"
    Dim aksi = False

    Sub awal()
        'MsgBox(getCount("select * from transaksi where pembeli like '%" & TextBox1.Text & "%'"))
        DataGridView1.DataSource = getData("select * from penjualan where id_pelanggan like '%" & TextBox1.Text & "%'")
        clearForm(GroupBox2)
        'MsgBox(getValue("select * from transaksi where pembeli like '%" & TextBox1.Text & "%'", "pembeli"))
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).HeaderText = "Tanggal Penjualan"
        DataGridView1.Columns(2).HeaderText = "Total Harga"
        DataGridView1.Columns(3).HeaderText = "Nama Pelanggan"
        GroupBox1.Enabled = True
        GroupBox2.Enabled = False
        GroupBox3.Enabled = True
        id = "0"
    End Sub

    Sub buka()
        GroupBox1.Enabled = False
        GroupBox2.Enabled = True
        GroupBox3.Enabled = False
    End Sub
    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        awal()
    End Sub

    Private Sub penjualan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If adaKosong(GroupBox2) Then
            MsgBox("Ada data kosong")
        Else
            Dim sql
            If Not aksi Then
                sql = "insert into pelanggan values('" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "','" & TextBox2.Text & "','" & TextBox3.Text & "')"
                'MsgBox(sql)
                exc(sql)
                clearForm(GroupBox2)
                MsgBox("Data berhasil ditambah")
                awal()
            Else
                sql = "update pelanggan set id_pelanggan = '" & TextBox2.Text & "', tgl_penjualan = '" & DateTimePicker1.Value.ToString("yyyy-MM-dd") & "', total_harga = '" & TextBox2.Text & "', nama_pelanggan = '" & TextBox3.Text & "' where id_penjualan = " & id
                'MsgBox(sql)
                exc(sql)
                clearForm(GroupBox2)
                MsgBox("Data berhasil diubah")
                awal()
            End If
        End If
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        clearForm(GroupBox2)
        awal()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        buka()
        clearForm(GroupBox2)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If id = "0" Then
            MsgBox("Pilih data dulu")
        Else
            aksi = True
            buka()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If id = "0" Then
            MsgBox("Pilih data dulu")
        Else
            If dialog("Apakah anda yakin ingin menghapus?") Then
                Dim sql = "delete from penjualan where id_penjualan =" & id
                'MsgBox(sql)
                exc(sql)
                clearForm(GroupBox2)
                awal()
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then

            DateTimePicker1.Value = DataGridView1.Rows(e.RowIndex).Cells(1).Value
            TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
            TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value


            id = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        End If

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub
End Class