@ModelType CultureClub.JoinViewModel
@Code
ViewData("Title") = "Join"
End Code

<h2>Join</h2>
<h3>Are you sure you want to join this?</h3>
<div>
    <h4>Group</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            Group Name
        </dt>

        <dd>
            @*@Html.DisplayFor(Function(model) model.ClubName)*@
        </dd>        

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>

