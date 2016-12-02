Imports System.ComponentModel.DataAnnotations

Public Class ExternalLoginConfirmationViewModel
    <Required>
    <Display(Name:="Email")>
    Public Property Email As String

    <Required>
    <StringLength(9,MinimumLength := 9)>
    <Display(Name:="University Id")>
    Public Property UniversityId As String

    Public Property LastName As String

    Public Property FirstName As String

End Class
Public Class JoinViewModel
    <Required>
    Public Property GroupId As Integer
End Class
Public Class GroupActivityViewModel
    Public Property Activities As List(Of Activity)
    Public Property Group As Group
End Class
Public Class ExternalLoginListViewModel
    Public Property ReturnUrl As String
End Class

Public Class SendCodeViewModel
    Public Property SelectedProvider As String
    Public Property Providers As ICollection(Of SelectListItem)
    Public Property ReturnUrl As String
    Public Property RememberMe As Boolean
End Class

Public Class VerifyCodeViewModel
    <Required>
    Public Property Provider As String

    <Required>
    <Display(Name:="Code")>
    Public Property Code As String

    Public Property ReturnUrl As String

    <Display(Name:="Remember this browser?")>
    Public Property RememberBrowser As Boolean

    Public Property RememberMe As Boolean
End Class

Public Class ForgotViewModel
    <Required>
    <Display(Name:="Email")>
    Public Property Email As String
End Class

Public Class LoginViewModel
    <Required>
    <Display(Name:="Email")>
    <EmailAddress>
    Public Property Email As String

    <Required>
    <DataType(DataType.Password)>
    <Display(Name:="Password")>
    Public Property Password As String

    <Display(Name:="Remember me?")>
    Public Property RememberMe As Boolean
End Class

Public Class RegisterViewModel

    <Required>
    <EmailAddress>
    <Display(Name:="Email")>
    <RegularExpression("^[a-zA-Z0-9._%+-]+(@student.ksu.edu.sa)$", ErrorMessage:="Registration Emile must be the university email")>
    Public Property Email As String

    <Required>
    <Display(Name:="First Name")>
    <StringLength(10)>
    Public Property FirstName As String

    <Required>
    <Display(Name:="Last Name")>
    <StringLength(10)>
    Public Property LastName As String
    <StringLength(9, MinimumLength:=9)>
    <Display(Name:="UniversityId")>
    Public Property UniversityId As String

    <StringLength(25)>
    <Display(Name:="Major Name")>
    Public Property Name As String
    <Required>
    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=6)>
    <DataType(DataType.Password)>
    <Display(Name:="Password")>
    Public Property Password As String

    <DataType(DataType.Password)>
    <Display(Name:="Confirm password")>
    <Compare("Password", ErrorMessage:="The password and confirmation password do not match.")>
    Public Property ConfirmPassword As String
End Class
Public Class ResetPasswordViewModel
    <Required>
    <EmailAddress>
    <Display(Name:="Email")>
    Public Property Email() As String

    <Required>
    <StringLength(100, ErrorMessage:="The {0} must be at least {2} characters long.", MinimumLength:=6)>
    <DataType(DataType.Password)>
    <Display(Name:="Password")>
    Public Property Password() As String

    <DataType(DataType.Password)>
    <Display(Name:="Confirm password")>
    <Compare("Password", ErrorMessage:="The password and confirmation password do not match.")>
    Public Property ConfirmPassword() As String

    Public Property Code() As String
End Class

Public Class ForgotPasswordViewModel
    <Required>
    <EmailAddress>
    <Display(Name:="Email")>
    Public Property Email() As String
End Class
