
Imports System.Data.OleDb
Imports System.Drawing.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Age
    Dim myconnection As New OleDbConnection("Data source = localhost;" + "password = int1; user Id = system ;provider=oraOLEDB.oracle")
    Private Sub Age_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillDataGrid_age()
    End Sub
    Private Sub FillDataGrid_age()
        Dim adp As OleDbDataAdapter
        Dim ds As New DataSet
        adp = New OleDb.OleDbDataAdapter("select * from AGE_CATEGORY", myconnection)
        adp.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim sql As String = "INSERT INTO AGE_CATEGORY(AGE_CODE,YEARS)VALUES(?,?)"
            myconnection.Open()
            Dim command As New OleDb.OleDbCommand(sql, myconnection)
            command.Parameters.AddWithValue("?", TextBox1.Text)
            command.Parameters.AddWithValue("?", TextBox2.Text)

            Dim affectedrow = command.ExecuteNonQuery()
            myconnection.Close()

            If (affectedrow >= 1) Then
                MessageBox.Show("Data Inserted")
                FillDataGrid_age()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            myconnection.Close()
        End Try
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim sql As String = "UPDATE AGE_CATEGORY SET YEARS=? WHERE AGE_CODE=?"
            myconnection.Open()

            Dim command As New OleDbCommand(sql, myconnection)

            command.Parameters.AddWithValue("?", TextBox2.Text) ' YEARS
            command.Parameters.AddWithValue("?", TextBox1.Text) ' AGE_CODE

            Dim affectedrow = command.ExecuteNonQuery()
            myconnection.Close()

            If (affectedrow >= 1) Then
                MessageBox.Show("Data Updated")
                FillDataGrid_age()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            myconnection.Close()
        End Try
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        Try
            TextBox1.Text = DataGridView1.SelectedRows(0).Cells(0).Value.ToString()
            TextBox2.Text = DataGridView1.SelectedRows(0).Cells(1).Value.ToString()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Try
            myconnection.Open()
            Dim sql As String = "DELETE FROM AGE_CATEGORY WHERE AGE_CODE=?"

            Dim command As New OleDb.OleDbCommand(sql, myconnection)
            command.Parameters.AddWithValue("?", TextBox1.Text)

            Dim affectedrow = command.ExecuteNonQuery()
            myconnection.Close()

            If (affectedrow >= 1) Then
                MessageBox.Show("Data Deleted")
                FillDataGrid_age()

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            myconnection.Close()
        End Try
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim adp As OleDbDataAdapter
        Dim ds As New DataSet
        adp = New OleDb.OleDbDataAdapter("select * from AGE_CATEGORY where AGE_CODE<10 ", myconnection)
        adp.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
    End Sub
End Class