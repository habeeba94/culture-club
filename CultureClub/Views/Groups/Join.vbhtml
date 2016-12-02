@ModelType JoinViewModel
@Code
    ViewData("Title") = "Join"
End Code

<h3>Are you sure you want to join this?</h3>
<div>
    <h4>Team</h4>
    
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()
        @Model
        @<div class="form-actions no-color">
            <input type="submit" value="Join" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
