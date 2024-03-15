Imports System.Data.OleDb

Public Class Bill
    Dim myconnection As New OleDbConnection("Data source=localhost; password=int1; user Id=system; provider=oraOLEDB.oracle")

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            myconnection.Open()
            Dim sql As String = "INSERT INTO BILLS(BILL_ID, CUSTOMER, TOY_ID, QTY, DISCOUNT, TOTAL_AMOUNT, BUY_DATE) VALUES(?, ?, ?, ?, ?, ?, TO_DATE(?, 'YYYY-MM-DD'))"

            Using command As New OleDb.OleDbCommand(sql, myconnection)
                command.Parameters.AddWithValue("?", CInt(TextBox1.Text))
                command.Parameters.AddWithValue("?", TextBox2.Text)
                command.Parameters.AddWithValue("?", CInt(TextBox3.Text))
                command.Parameters.AddWithValue("?", CInt(TextBox4.Text))
                command.Parameters.AddWithValue("?", CInt(TextBox5.Text))
                command.Parameters.AddWithValue("?", CInt(TextBox13.Text))
                command.Parameters.AddWithValue("?", DateTimePicker1.Value.ToString("yyyy-MM-dd"))

                Dim affectedRows = command.ExecuteNonQuery()

                If affectedRows >= 1 Then
                    MessageBox.Show("Data Inserted")
                    FillDataDridBill()
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            myconnection.Close()
        End Try
    End Sub

    ' Private Sub qin_ValueChanged(sender As Object, e As EventArgs) Handles qin.ValueChanged
    'Try
    'Dim q As Decimal = Convert.ToDecimal(qin.Value)

    '      total_amout = q * price
    '     amoutin.Text = Convert.ToDecimal(total_amout)
    '  Catch ex As Exception

    '  End Try
    ' End Sub

    ' Private Sub din_ValueChanged(sender As Object, e As EventArgs) Handles din.ValueChanged
    'Try
    'Dim d As Decimal = Convert.ToDecimal(din.Value) / 100

    '  total_amout -= total_amout * d
    ' amoutin.Text = Convert.ToDecimal(total_amout)
    'Catch ex As Exception

    'End Try
    'End Sub
    Private Sub FillDataDridBill()
        Dim adp As OleDbDataAdapter
        Dim ds As New DataSet
        adp = New OleDb.OleDbDataAdapter("SELECT * FROM BILLS", myconnection)
        adp.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub generateBill()
    End Sub
    Private Sub Bill_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillDataDridBill()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        myconnection.Open()
        Dim adp As New OleDbDataAdapter("select max(QTY) as maximum from bills", myconnection)
        Dim ds As New DataSet
        adp.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        myconnection.Close()
    End Sub
End Class
