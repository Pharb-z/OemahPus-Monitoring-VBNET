' Draft reservasi 3 langkah, tiru localStorage draftReservasi di prototipe.
Public Class ReservationDraft
    Public Property CustomerId As Integer
    Public Property CustomerName As String = String.Empty
    Public Property Phone As String = String.Empty
    Public Property Address As String = String.Empty
    Public Property HealthNotes As String = String.Empty
    Public Property CatId As Integer
    Public Property CatName As String = String.Empty
    Public Property CheckIn As Date = Today
    Public Property CheckOut As Date = Today.AddDays(1)
    Public Property NeedPickup As Boolean
    Public ReadOnly ServiceIds As New List(Of Integer)()
    Public ReadOnly ServiceQty As New Dictionary(Of Integer, Integer)()

    Public Sub Reset()
        CustomerId = 0
        CustomerName = String.Empty
        Phone = String.Empty
        Address = String.Empty
        HealthNotes = String.Empty
        CatId = 0
        CatName = String.Empty
        CheckIn = Today
        CheckOut = Today.AddDays(1)
        NeedPickup = False
        ServiceIds.Clear()
        ServiceQty.Clear()
    End Sub

    Public Shared Property Current As New ReservationDraft()
End Class
