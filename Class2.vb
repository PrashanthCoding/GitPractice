Module Module1
    Sub Main()
        Dim arr() As Integer = {1, 3, 5, 7, 9, 11}
        Dim target As Integer = 5
        Dim index As Integer = BinarySearch(arr, target)

        If index <> -1 Then
            Console.WriteLine("Element found at index " & index)
        Else
            Console.WriteLine("Element not found")
        End If
    End Sub

    Function BinarySearch(arr() As Integer, target As Integer) As Integer
        Dim left As Integer = 0
        Dim right As Integer = arr.Length - 1

        While left <= right
            Dim mid As Integer = left + (right - left) \ 2

            If arr(mid) = target Then
                Return mid
            ElseIf arr(mid) < target Then
                left = mid + 1
            Else
                right = mid - 1
            End If
        End While

        Return -1
    End Function
End Module
