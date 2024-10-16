Module Module1
    Sub Main()
        Dim arr() As Integer = {10, 20, 4, 45, 99}

        Dim largest As Integer = Integer.MinValue
        Dim secondLargest As Integer = Integer.MinValue

        For Each num As Integer In arr
            If num > largest Then
                secondLargest = largest
                largest = num
            ElseIf num > secondLargest AndAlso num <> largest Then
                secondLargest = num
            End If
        Next

        Console.WriteLine("The second largest element is " & secondLargest)
    End Sub
End Module
