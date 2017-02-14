'Cindy's NumGuess Game
'author: Cindy Orbegoso
'date: December 20, 2015
'The user enters a number guess and the game gives hints until the user
'guesses the number correctly.

Public Class frmGame
    'variables to store the number answer and the user's guess
    Dim answer As Integer
    Dim guess As Integer

    Private Sub frmGame_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            CheckWin()
        End If
    End Sub
    Private Sub frmGame_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        startGame()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        CheckWin()
    End Sub

    Private Sub startGame()
        Randomize()
        answer = CInt(Int((100 * Rnd()) + 1))
        lblResults.Text = ""
    End Sub

    Private Sub CheckWin()
        'check if the user's guess is a number
        If IsNumeric(txtGuess.Text) Then
            'convert user's String guess to an integer
            guess = CInt(txtGuess.Text)
            'check if user's guess is invalid, too low, too high, or correct
            Select Case guess
                Case Is < 1
                    lblResults.ForeColor = Color.Red
                    lblResults.Text = "Your guess is invalid."
                Case Is > 100
                    lblResults.ForeColor = Color.Red
                    lblResults.Text = "Your guess is invalid."
                Case Is < answer
                    lblResults.ForeColor = Color.Blue
                    lblResults.Text = "Your guess is too low!"
                Case Is > answer
                    lblResults.ForeColor = Color.Blue
                    lblResults.Text = "Your guess is too high!"
                Case Else
                    Dim response = MsgBox("You guessed correctly!" & vbCrLf & "Would you like to play again?", MsgBoxStyle.YesNo, "Hooray!")
                    If response = MsgBoxResult.Yes Then
                        'Start game over
                        startGame()
                    ElseIf response = MsgBoxResult.No Then
                        'close game
                        Me.Close()
                    End If
            End Select
        End If
        txtGuess.Text = ""
    End Sub

    Private Overloads Sub txtGuess_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtGuess.KeyDown
        If e.KeyCode = Keys.Return Or e.KeyCode = Keys.Enter Then
            CheckWin()
        End If
    End Sub
End Class
