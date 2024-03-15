Imports System.Data.Common
Imports System.Data.OleDb

Public Class sales
    Dim myconnection As New OleDbConnection("Data source = localhost; password = int1; user Id = system; provider=oraOLEDB.oracle")

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim ds As New DataSet
            myconnection.Open()


            Dim startDate As DateTime = DateTimePicker1.Value.ToString("dd-mm-yy")
            Dim endDate As DateTime = DateTimePicker2.Value.ToString("dd-mm-yy")
            Dim sql As String = "SELECT * FROM bills WHERE TO_DATE(buy_date, 'dd-mm-yy') BETWEEN ? AND ?"
            ' sql As String = "select * from bills where buy_date between ? and ?"
            Dim command As New OleDbCommand(sql, myconnection)

            command.Parameters.AddWithValue("?", startDate)
            command.Parameters.AddWithValue("?", endDate)

            ds = New DataSet
            Dim dataadapter As New OleDbDataAdapter(command)
            ds.Clear()

            dataadapter.Fill(ds)

            If ds.Tables.Count > 0 Then
                If ds.Tables(0).Rows.Count > 0 Then
                    DataGridView1.DataSource = ds.Tables(0)
                Else
                    MsgBox("No sales found for the selected date range.")
                End If
            Else
                MsgBox("No data available")
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            myconnection.Close()
        End Try
    End Sub

    Private Sub FillDataDrid()
        Try
            Dim adp As New OleDbDataAdapter("select * from bills", myconnection)
            Dim ds As New DataSet
            adp.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub sales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillDataDrid()
    End Sub
End Class