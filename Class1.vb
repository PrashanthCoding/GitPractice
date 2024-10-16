Imports System
Imports System.Text

Module Module1
    Sub Main()
        Dim length As Integer = 12
        Dim password As String = GeneratePassword(length)
        Console.WriteLine("Generated Password: " & password)
    End Sub

    Function GeneratePassword(length As Integer) As String
        Const validChars As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()"
        Dim res As New StringBuilder()
        Dim rnd As New Random()

        While length > 0
            res.Append(validChars(rnd.Next(validChars.Length)))
            length -= 1
        End While

        Return res.ToString()
    End Function
End Module
