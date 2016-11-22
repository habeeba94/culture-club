@ModelType IndexViewModel
@Code
	ViewBag.Title = "Manage"
End Code

<h2>@ViewBag.Title.</h2>

<p class="text-success">@ViewBag.StatusMessage</p>
<div>
	<h4>Change your account settings</h4>
	<hr />
	<dl class="dl-horizontal">
		<dt>Password:</dt>
		<dd>
			[
			@If Model.HasPassword Then
				@Html.ActionLink("Change your password", "ChangePassword")
			Else
				@Html.ActionLink("Create", "SetPassword")
			End If
			]
		@*</dd>
		<dt>External Logins:</dt>
		<dd>
			@Model.Logins.Count [
			@Html.ActionLink("Manage", "ManageLogins") ]
		</dd>*@
	   
			@*<dt>Phone Number:</dt>
			<dd>
				@(If(Model.PhoneNumber, "None"))
				@If (Model.PhoneNumber <> Nothing) Then
					@<br />
					@<text>[&nbsp;&nbsp;@Html.ActionLink("Change", "AddPhoneNumber")&nbsp;&nbsp;]</text>
					@Using Html.BeginForm("RemovePhoneNumber", "Manage", FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
						@Html.AntiForgeryToken
						@<text>[<input type="submit" value="Remove" class="btn-link" />]</text>
					End Using
				Else
					@<text>[&nbsp;&nbsp;@Html.ActionLink("Add", "AddPhoneNumber") &nbsp;&nbsp;]</text>
				End If
			</dd>*@
	   
	</dl>
</div>
