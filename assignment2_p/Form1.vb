Public Class Form1
    Private Sub ToyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToyToolStripMenuItem.Click
        Toy.show()
    End Sub

    Private Sub AgeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgeToolStripMenuItem.Click
        Age.Show()
    End Sub

    Private Sub BillsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BillsToolStripMenuItem.Click
        Bill.Show()
    End Sub

    Private Sub SalesoflastweekToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BillsToolStripMenuItem.Click
        sales.Show()
    End Sub

End Class
