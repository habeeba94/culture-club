Imports System.Data.Entity
Imports System.Net
Imports Microsoft.AspNet.Identity

Namespace Controllers

    Public Class ActivitiesController
        Inherits System.Web.Mvc.Controller

        Private db As New ApplicationDbContext


        ' GET: Activities
        Function Index() As ActionResult
            '
            Return View(db.Activities.ToList())
        End Function

        ' GET: Activities/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim activity As Activity = db.Activities.Find(id)
            If IsNothing(activity) Then
                Return HttpNotFound()
            End If
            Return View(activity)
        End Function

        ' GET: Activities/Create
        <Authorize>
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Activities/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <Authorize, HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,AdminId,Name,Description,StartDate,EndDate")> ByVal activity As Activity) As ActionResult
            activity.AdminId = User.Identity.GetUserId()
            If ModelState.IsValid Then
                db.Activities.Add(activity)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(activity)
        End Function

        ' GET: Activities/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim activity As Activity = db.Activities.Find(id)
            If IsNothing(activity) Then
                Return HttpNotFound()
            End If
            Return View(activity)
        End Function

        ' POST: Activities/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,AdminId,Name,Description,StartDate,EndDate")> ByVal activity As Activity) As ActionResult
            If ModelState.IsValid Then
                db.Entry(activity).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(activity)
        End Function

        ' GET: Activities/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim activity As Activity = db.Activities.Find(id)
            If IsNothing(activity) Then
                Return HttpNotFound()
            End If
            Return View(activity)
        End Function

        ' POST: Activities/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim activity As Activity = db.Activities.Find(id)
            db.Activities.Remove(activity)
            db.SaveChanges()
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
