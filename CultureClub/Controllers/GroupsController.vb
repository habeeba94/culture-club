Imports System.Data.Entity
Imports System.Net

Namespace Controllers
    Public Class GroupsController
        Inherits Controller

        Private ReadOnly _db As New ApplicationDbContext

        Function Index() As ActionResult
            '
            Return View(_db.Groups.ToList())
        End Function

        ' GET: Groups/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim group As Group = _db.Groups.Find(id)
            If IsNothing(group) Then
                Return HttpNotFound()
            End If
            Return View(group)
        End Function

        ' GET: Groups/Join
        Function Join(name As String) As ActionResult
            Dim model = New JoinViewModel()
            model.GroupName = name
            Return View(model)
        End Function

        ' POST: Groups/Join
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Join(model As JoinViewModel) As ActionResult

            Return View()
        End Function

        ' GET: Groups/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Groups/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Name,Department")> ByVal group As Group) As ActionResult
            If ModelState.IsValid Then
                _db.Groups.Add(group)
                _db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(group)
        End Function

        ' GET: Groups/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim group As Group = _db.Groups.Find(id)
            If IsNothing(group) Then
                Return HttpNotFound()
            End If
            Return View(group)
        End Function

        ' POST: Groups/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Name,Department")> ByVal group As Group) As ActionResult
            If ModelState.IsValid Then
                _db.Entry(group).State = EntityState.Modified
                _db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(group)
        End Function

        ' GET: Groups/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim group As Group = _db.Groups.Find(id)
            If IsNothing(group) Then
                Return HttpNotFound()
            End If
            Return View(group)
        End Function

        ' POST: Groups/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim group As Group = _db.Groups.Find(id)
            _db.Groups.Remove(group)
            _db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                _db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace