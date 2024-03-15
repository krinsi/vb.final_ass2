Imports System.Data.OleDb
Imports System.Drawing.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Public Class Toy
    Dim myconnection As New OleDbConnection("Data source = localhost;" + "password = int1; user Id = system ; provider=oraOLEDB.oracle")

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FillDataDrid()
        Try
            Dim myconnection As New OleDbConnection("Data source = localhost;" + "password = int1; user Id = system ;  provider=oraOLEDB.oracle")

            Dim sql As String = "INSERT INTO TOY(TOY_ID,TOY_NAME,DESCRIPTION,AGE,IMAGE_PATH,STOCK,PRICE)VALUES(?,?,?,?,?,?,?)"

            myconnection.Open()
            Dim command As New OleDbCommand(sql, myconnection)
            command.Parameters.AddWithValue("?", CInt(TextBox1.Text))
            'command.Parameters.AddWithValue("?", ComboBox1.SelectedItem)
            command.Parameters.AddWithValue("?", TextBox7.Text)
            command.Parameters.AddWithValue("?", TextBox2.Text)
            ' command.Parameters.AddWithValue("?", ComboBox2.SelectedItem)
            command.Parameters.AddWithValue("?", CInt(TextBox6.Text))
            command.Parameters.AddWithValue("?", TextBox3.Text)
            command.Parameters.AddWithValue("?", CInt(TextBox4.Text))
            command.Parameters.AddWithValue("?", CInt(TextBox5.Text))

            Dim affectedrow = command.ExecuteNonQuery()
            myconnection.Close()

            If (affectedrow >= 1) Then
                MessageBox.Show("Data Inserted")
                FillDataDrid()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            myconnection.Close()
        End Try

    End Sub


    Private Sub FillDataDrid()
        Dim adp As New OleDbDataAdapter("select * from toy", myconnection)
        Dim ds As New DataSet
        adp.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub Toy_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FillDataDrid()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim sql As String = "UPDATE TOY SET TOY_NAME=?, DESCRIPTION=?, AGE=?, IMAGE_PATH=?, STOCK=?, PRICE=? WHERE TOY_ID=?"
            myconnection.Open()

            Dim command As New OleDbCommand(sql, myconnection)
            command.Parameters.AddWithValue("?", CInt(TextBox1.Text))
            ' command.Parameters.AddWithValue("?", ComboBox1.SelectedItem)
            command.Parameters.AddWithValue("?", TextBox7.Text)
            command.Parameters.AddWithValue("?", TextBox2.Text)
            ' command.Parameters.AddWithValue("?", ComboBox2.SelectedItem)
            command.Parameters.AddWithValue("?", CInt(TextBox6.Text))
            command.Parameters.AddWithValue("?", TextBox3.Text)
            command.Parameters.AddWithValue("?", CInt(TextBox4.Text))
            command.Parameters.AddWithValue("?", CInt(TextBox5.Text)) ' Add the parameter for TOY_ID

            Dim affectedrow = command.ExecuteNonQuery()
            myconnection.Close()

            If (affectedrow >= 1) Then
                MessageBox.Show("Data Updated")
                FillDataDrid()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            myconnection.Close()
        End Try
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        Try
            TextBox1.Text = DataGridView1.SelectedRows(0).Cells(0).Value.ToString()
            ' ComboBox1.SelectedItem = DataGridView1.SelectedRows(0).Cells(1).Value.ToString()
            TextBox7.Text = DataGridView1.SelectedRows(0).Cells(1).Value.ToString()
            TextBox2.Text = DataGridView1.SelectedRows(0).Cells(2).Value.ToString()
            ' ComboBox2.SelectedItem = DataGridView1.SelectedRows(0).Cells(3).Value.ToString()
            TextBox6.Text = DataGridView1.SelectedRows(0).Cells(3).Value.ToString()
            TextBox3.Text = DataGridView1.SelectedRows(0).Cells(4).Value.ToString()
            TextBox4.Text = DataGridView1.SelectedRows(0).Cells(5).Value.ToString()
            TextBox5.Text = DataGridView1.SelectedRows(0).Cells(6).Value.ToString()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Try
            myconnection.Open()
            Dim sql As String = "DELETE FROM TOY WHERE TOY_ID=?"

            Dim command As New OleDb.OleDbCommand(sql, myconnection)
            command.Parameters.AddWithValue("?", CInt(TextBox1.Text))

            Dim affectedrow = command.ExecuteNonQuery()
            myconnection.Close()

            If (affectedrow >= 1) Then
                MessageBox.Show("Data Deleted")
                FillDataDrid()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            myconnection.Close()
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        myconnection.Open()
        Dim adp As New OleDbDataAdapter("select * from toy where stock<10", myconnection)
        Dim ds As New DataSet
        adp.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        myconnection.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Age.Show()
    End Sub
End Class