Imports System.Data.Entity
Imports System.Threading.Tasks
Imports System.Net
Imports Microsoft.AspNet.Identity

Namespace Controllers
    Public Class GroupsController
        Inherits System.Web.Mvc.Controller

        Private db As New ApplicationDbContext

        ' GET: Groups
        Async Function Index() As Task(Of ActionResult)
            Return View(Await db.Groups.ToListAsync())
        End Function

        <Authorize(Roles:="Student, StudentAdmin")>
        Function Join(ByVal GroupId As Integer) As ActionResult
            'ViewBag.G = New SelectList(db.Users.Select(Function(e) New With {
            '    .UserId = e.Id,
            '    .Name = $"{e.FirstName} {e.LastName}"
            '}), "UserId", "Name")
            Return View()
        End Function

        <HttpPost, ValidateAntiForgeryToken()>
        Async Function Join(ByVal model As JoinViewModel) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.StudentGroups.Add(New StudentGroup With {
                    .GroupId = model.GroupId,
                    .UserId = User.Identity.GetUserId()
                })
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            Return View(model)
        End Function



        'Get Members testDrive
        Function Members(ByVal GroupId As Integer) As ActionResult
            Return View(db.StudentGroups.Where(Function(e) e.GroupId = GroupId).Include(Function(e) e.Student.Major).Select(Function(e) e.Student).ToList())
        End Function

        ' GET: Groups/Details/5
        Async Function Details(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim group As Group = Await db.Groups.FindAsync(id)
            If IsNothing(group) Then
                Return HttpNotFound()
            End If
            Return View(group)
        End Function

        ' GET: Groups/Create
        <Authorize(Roles:="Admin")>
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Groups/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost(), Authorize(Roles:="Admin")>
        <ValidateAntiForgeryToken()>
        Async Function Create(<Bind(Include:="Id,Name,Description")> ByVal group As Group) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Groups.Add(group)
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            Return View(group)
        End Function

        ' GET: Groups/Edit/5
        <Authorize(Roles:="Admin")>
        Async Function Edit(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim group As Group = Await db.Groups.FindAsync(id)
            If IsNothing(group) Then
                Return HttpNotFound()
            End If
            Return View(group)
        End Function

        ' POST: Groups/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost(), Authorize(Roles:="Admin")>
        <ValidateAntiForgeryToken()>
        Async Function Edit(<Bind(Include:="Id,Name,Description")> ByVal group As Group) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Entry(group).State = EntityState.Modified
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            Return View(group)
        End Function

        ' GET: Groups/Delete/5

        <Authorize(Roles:="Admin")>
        Async Function Delete(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim group As Group = Await db.Groups.FindAsync(id)
            If IsNothing(group) Then
                Return HttpNotFound()
            End If
            Return View(group)
        End Function

        ' POST: Groups/Delete/5
        <HttpPost()>
        <ActionName("Delete"), Authorize(Roles:="Admin")>
        <ValidateAntiForgeryToken()>
        Async Function DeleteConfirmed(ByVal id As Integer) As Task(Of ActionResult)
            Dim group As Group = Await db.Groups.FindAsync(id)
            db.Groups.Remove(group)
            Await db.SaveChangesAsync()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
