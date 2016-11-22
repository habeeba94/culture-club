Public Class HomeController
    Inherits Controller
    Private db As New ApplicationDbContext

    Function Index() As ActionResult
        Dim groups = db.ActivityGroups.Include("Activity").Include("Group").GroupBy(Function(e) e.Group).Select(Function(e) New GroupActivityViewModel With {
             .Group = e.Key,
             .Activities = e.Select(Function(i) i.Activity).ToList()
          }).ToList()
        Return View(groups)
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function
End Class
