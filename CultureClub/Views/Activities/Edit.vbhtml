@ModelType CultureClub.Activity
@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
        <h4>Activity</h4>
        @Html.ValidationSummary(True, "", New With { .class = "text-danger" })
        @Html.HiddenFor(Function(model) model.Id)
        @Html.HiddenFor(Function(model) model.AdminId)

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Name, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Name, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.Name, "", New With { .class = "text-danger" })
            </div>
        </div>

         <div class="form-group">
             @Html.LabelFor(Function(model) model.Description, htmlAttributes:=New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @Html.TextAreaFor(Function(model) model.Description, 10, 30, htmlAttributes:=New With {.class = "form-control"})
                 @Html.ValidationMessageFor(Function(model) model.Description, "", New With {.class = "text-danger"})
             </div>
         </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.StartDate, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.StartDate, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.StartDate, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.EndDate, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.EndDate, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.EndDate, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Save" class="btn btn-default" />
            </div>
        </div>
    </div>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@Section Scripts 
    @Scripts.Render("~/bundles/jqueryval")
End Section
